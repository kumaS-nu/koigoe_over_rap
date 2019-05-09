using System;
using NAudio.Wave;
using System.Windows.Forms;
using System.Collections.Generic;


namespace koigoe_over_rap
{
    /// <summary>
    /// 音関係のクラス
    /// </summary>
    class Audio
    {
        /// <param name="outputdevice">     出力する機器の名前（一般に入力機器）</param>
        /// <param name="deviceNum">        何番目の機器か</param>
        /// <param name="waveIn">           オーディオ関連の情報を持ってるクラス</param>
        /// <param name="sample32">         音の波の値</param>
        /// <param name="out_devices">      出力機器の名前</param>
        public string outputdevice { get; private set; }
        public int? deviceNum { get; private set; } = null;
        public Dictionary<string, int> out_devices = new Dictionary<string,int>();
        public Dictionary<string, int> input_devices = new Dictionary<string, int>();
        private WaveIn waveIn;
        public LinkedList<float> sample32 { get; private set; } = new LinkedList<float>();

        public Audio()
        { 
            
            outputdevice = ReadWritePropatysToFile.ReadOutputDevice();

            out_devices.Add("Wave Mapper", 0);
            for(int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var deviceInfo = WaveOut.GetCapabilities(i);
                out_devices.Add(deviceInfo.ProductName, i + 1);
            }

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var deviceInfo = WaveIn.GetCapabilities(i);
                input_devices.Add(deviceInfo.ProductName,i);
                if (outputdevice.StartsWith(deviceInfo.ProductName))
                {
                    deviceNum = i;
                }
            }
            try
            {
                waveIn = new WaveIn() { DeviceNumber = (int)deviceNum };

                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.WaveFormat = new WaveFormat(sampleRate: 48000, channels: 2);
            }
            catch (InvalidOperationException) {
                MessageBox.Show("音声の出力先を特定できませんでした。\nイコライザーのバグチェックは無視されます。",
                                 "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 途中で音声監視先を変える時用の関数
        /// </summary>
        public void DeviceChange(int devnum)
        {
            deviceNum = devnum;
            try
            {
                waveIn = new WaveIn() { DeviceNumber = (int)deviceNum };

                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.WaveFormat = new WaveFormat(sampleRate: 48000, channels: 2);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("音声の出力先を特定できませんでした。\nイコライザーのバグチェックは無視されます。",
                                 "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// 音の波を送るイベント
        /// </summary>
        /// <param name="sender">おまじない</param>
        /// <param name="e">おまじない</param>
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                float sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]) / (float)short.MaxValue;
                while(sample32.Count > 4000)
                {
                    sample32.RemoveFirst();
                }
                sample32.AddLast(sample);
                
            }
        }
        /// <summary>
        /// 音測定開始
        /// </summary>
        public void StartRecording()
        {
            waveIn.StartRecording();
        }


    }
}
