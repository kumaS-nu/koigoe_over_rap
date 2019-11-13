using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace koigoe_over_rap
{
    /// <summary>
    /// 非同期でやるやつまとめた。
    /// </summary>
    class AnsyncFunctions
    {

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern uint SetWindowLong(IntPtr hWnd,int nIndex,uint dwLong );

        private const int HWND_TOPMOST = -1;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOOWNERZORDER = 0x0200;

        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;

        private const uint WS_POPUP = 0x80000000;
        private const uint WS_EX_TOPMOST = 0x8;

        public Audio audio { get; private set; }
        private Dates date;

        public AnsyncFunctions(Dates dates)
        {
            audio = new Audio();
            date = dates;
        }

        public void RunAll()
        {
            Reset();
            RunCheck();
            CheckInGame();
            EQcheck();
        }
        /// <summary>
        /// 定期的にリセット
        /// </summary>
        public Task Reset()
        {

            return Task.Run(() => Reset_f());
        }

        private void Reset_f()
        {
            while (true)
            {
                Thread.Sleep(date.reset_interval);

                if (date.reset_interval != new TimeSpan(0, 0, 0))
                {
                    date.cont.Restart();
                }
            }
        }

        /// <summary>
        /// 恋声が動いているかチェックする
        /// </summary>
        public Task RunCheck()
        {
            return Task.Run(() => RunChecker_f());
        }


        /// <summary>
        /// RunCheckの関数部分
        /// </summary>
        private void RunChecker_f()
        {

            while (true)
            {

                if (!date.cont.mother_window.Responding)
                {
                    MessageBox.Show("恋声が落ちたため再起動します", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    date.cont.KillKoigoe();
                    date.cont.RunApp(date.path);
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// ゲーム中か調べる
        /// </summary>
        /// <returns></returns>
        public Task CheckInGame()
        {
            return Task.Run(() => CheckInGame_f());
        }

        private void CheckInGame_f()
        {

            IntPtr hWnd;
            string name;
            Process process;
            Process gamep = new Process();

            while (true)
            {
                
                hWnd = GetForegroundWindow();

                GetWindowThreadProcessId(hWnd, out int id);
                process = Process.GetProcessById(id);
                name = process.ProcessName;

                foreach (var game in date.gameprocess)
                {
                    if (name == game)
                    {
                        date.ingame = true;
                        break;
                    }
                    else if (date.gameprocess.Last() == game)
                    {
                        date.ingame = false;
                    }
                }

                

                if (date.ingame == true)
                {
                    
                    var temp1 = GetWindowLong(process.MainWindowHandle, GWL_STYLE);
                    var temp2 = GetWindowLong(process.MainWindowHandle, GWL_EXSTYLE);
                    Trace.WriteLine("window style =" + temp1.ToString("x"));
                    Trace.WriteLine("window Exstyle = " + temp2.ToString("x"));
                    temp1 |= WS_POPUP;
                    temp2 &= WS_EX_TOPMOST;
                    SetWindowLong(process.MainWindowHandle, GWL_STYLE, temp1);
                    SetWindowLong(process.MainWindowHandle, GWL_EXSTYLE, temp2);
                    
                    date.overlayForm.Invoke((MethodInvoker)(() => {
                        date.overlayForm.TopMost = true;
                    }));
                    
                }
                
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// イコライザーがバグってないか監視
        /// </summary>
        public Task EQcheck()
        {
            if (audio.deviceNum != null)
            {
                audio.StartRecording();

                return Task.Run(() => EQcheck_f());
            }

            return null;
        }

        private void EQcheck_f()
        {
            int eq_time = 0;
            int stop_time = 0;
            double db1 = 0, db2;
            while (true)
            {
                Thread.Sleep(1000);


                db2 = CalcDB(db1);

                if (Math.Abs(db1 - db2) < 5 && db2 > -40 && date.form1.checkBox1.Checked)
                {
                    ++eq_time;
                }
                else
                {
                    eq_time = 0;
                }

                if (db2 < -80 && date.form1.checkBox2.Checked)
                {
                    ++stop_time;
                }
                else
                {
                    stop_time = 0;
                }

                if (eq_time > 30)
                {
                    MessageBox.Show("音声が出力されておりません。EQバグの可能性があるため再起動します。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date.cont.KillKoigoe();
                    date.cont.RunApp(date.path);
                }

                if (stop_time > 30)
                {
                    ButtonTextCustomizableMessageBox msbox = new ButtonTextCustomizableMessageBox();
                    msbox.ButtonText.Cancel = "無視する";
                    var result = msbox.Show("音声が出力されていません。", "情報", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    stop_time = 0;
                    if (result == DialogResult.Cancel)
                    {
                        date.form1.Invoke((MethodInvoker)(() => date.form1.checkBox2.Checked = false));
                    }
                }


                db1 = db2;
            }
        }

        private float[] dump;
        /// <summary>
        /// 音量を計算
        /// </summary>
        /// <returns>dbで返す</returns>
        private double CalcDB(double before)
        {

            double accumulatedSquareSum = 0;
            try
            {
                dump = audio.sample32.ToArray();
            }
            catch (Exception) { return before; }

            foreach (var audioSample in dump)
            {
                accumulatedSquareSum += audioSample * audioSample;
            }

            double meanSquare = accumulatedSquareSum / (dump.Length / 2);

            double rms = Math.Sqrt(meanSquare);

            return 20 * Math.Log10(rms);

        }

        /// <summary>
        /// 音を監視するデバイスを変える時のやつ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextChangedIutput(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            audio.DeviceChange((int)senderComboBox.SelectedValue);
            ReadWritePropatysToFile.WriteOutputDevice(audio.input_devices.Skip(audio.deviceNum ?? 0).First().Key);
            Trace.WriteLine("Write: " + audio.input_devices.Skip(audio.deviceNum ?? 0).First().Key);
        }
    }
}
