using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Linq;


namespace koigoe_over_rap
{
    partial class Form1 : Form
    {
        private Dates date;
        private int mouse_x;
        private int mouse_y;
        public Form1() { }
   
        public Form1(Dates dates)
        {
            InitializeComponent();
            date = dates;
            //初期設定（データバインドとかイベント設定とか）
            ComboBox[] boxes = { EQset1, EQset2, EQset3, EQset4 };
            for(int i = 0; i < 4; i++) {
                SetComboData(boxes[i], new Dictionary<string, int> { { "無効", 0 }, { "1", 1 }, { "2", 2 }, { "3", 3 }, { "4", 4 } });
                boxes[i].SelectedIndex = (int)date.eq_set[i];
                boxes[i].TextChanged += new EventHandler(TextChangedEQ);
            }
            
            SetComboData(koigoe_output, date.ansync.audio.out_devices);
            koigoe_output.SelectedIndex = (int)date.outPutDevNum;
            koigoe_output.TextChanged += new EventHandler(TextChangeOutput);

            SetComboData(inputDevice, date.ansync.audio.input_devices);
            inputDevice.SelectedIndex = date.ansync.audio.deviceNum ?? 0;
            inputDevice.TextChanged += new EventHandler(date.ansync.TextChangedIutput);


            TextBox[] textBoxs = { koigoe_path, koigoe_set_path };
            for(int i = 0; i < 2; i++)
            {
                SetPath(textBoxs[i], date.path[i]);
                textBoxs[i].Leave += new EventHandler(LeaveTextBox);
                textBoxs[i].PreviewKeyDown += new PreviewKeyDownEventHandler(FocusOutEnter);
            }

            gamefile.Leave += new EventHandler(AddGame);
            gamefile.PreviewKeyDown += new PreviewKeyDownEventHandler(FocusOutEnter);


            deliteGame.DataSource = date.gameprocess;

            delite.Click += new EventHandler(Delite);

            reset_interval.Value = date.reset_interval.Minutes;
            reset_interval.ValueChanged += new EventHandler(ResetIntervalChange);
            reset_interval.KeyDown += new KeyEventHandler(FocusOutEnter);

            TextBox[] textBoxes = { shortcat1, shortcat2, shortcat3 ,shortcat4};
            for(int i = 0; i < 4; i++)
            {
                textBoxes[i].Text = date.shortcat[i].ToString();
                textBoxes[i].KeyDown += new KeyEventHandler(ShortcatKeyDown);
                textBoxes[i].Enter += new EventHandler(SelectAll);
                textBoxes[i].PreviewKeyDown += new PreviewKeyDownEventHandler(FocusOutEnter);
            }

            GroupBox[] groupBoxs = { groupBox1, groupBox2, groupBox3, groupBox4 };
            foreach(var groupBox in groupBoxs)
            {
                groupBox.Click += new EventHandler(GroupBoxClick);
            }

            Label[] labels = {label1,label2,label3,label4,label5,label6,label7,label8,label9,label10,label11,
            label12,label13,label14,label15};
            foreach(var label in labels)
            {
                label.Click += new EventHandler(GroupBoxClick);
            }
        }


        /// <summary>
        /// コンボボックスのデータをつける
        /// </summary>
        /// <param name="combo">張り付けるコンボボックス</param>
        /// <param name="dic">張り付けるデータ</param>
        private void SetComboData(ComboBox combo,Dictionary<string,int> dic)
        {
            combo.Items.Clear();
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";

            combo.DataSource = new BindingSource(dic, null);
        }

        /// <summary>
        /// TextBoxにパスを初期設定
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="path">書きこむパス</param>
        private void SetPath(TextBox textBox,string path)
        {
            if (File.Exists(path))
            {
                textBox.Text = path;
            }
            else
            {
                textBox.Clear();
            }
        }

        /// <summary>
        /// ドラッグで入ってきたときの
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            //ファイルがドラッグされている場合、カーソルを変更する
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// ドラッグで入ってきたときの
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたファイルの一覧を取得
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length <= 0)
            {
                return;
            }

            // ドロップ先がTextBoxであるかチェック
            if (!(sender is TextBox txtTarget))
            {
                return;
            }

            //TextBoxの内容をファイル名に変更
            txtTarget.Text = fileName[0];
        }

        /// <summary>
        /// パス設定の処理。フォーカスが外れた時にやる。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeaveTextBox(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            switch (textBox.Name)
            {
                case "koigoe_path":
                    if (File.Exists(textBox.Text))
                    {
                        date.path[0] = textBox.Text;
                    }
                    else
                    {
                        MessageBox.Show("そのパスは存在しません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "koigoe_set_path":
                    if (File.Exists(textBox.Text))
                    {
                        date.path[1] = textBox.Text;
                        date.pn.StartInfo.FileName = date.path[1];
                    }
                    else
                    {
                        MessageBox.Show("そのパスは存在しません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }

            ReadWritePropatysToFile.WritePath(date.path);
        }

        /// <summary>
        /// 恋声のウィンドウがポップアップするやつを押す
        /// </summary>
        /// <param name="argv">押すやつのintPtr(stringで)</param>
        private void StartProcess(string argv)
        {
            Process p = new Process();
            p.StartInfo.FileName = date.path[1];
            p.StartInfo.Arguments = argv;
            try
            {
                p.Start();
            }
            catch (Exception)
            {   //これが無くてもどうにかはなるのでエラー通知だけしておいてとばす
                MessageBox.Show("koigoe_setのパスが間違っています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            while (!p.HasExited) { }
            
        }

        /// <summary>
        /// EQ設定が変更されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedEQ(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            
            switch (senderComboBox.Name)
            {
                case "EQset1":
                    date.eq_set[0] = (uint)(int)senderComboBox.SelectedValue;
                    Trace.WriteLine(date.voc_num);
                    if (date.voc_num == 1) {
                        try
                        {
                            StartProcess(date.cont.argv_hWnd[1].ToString());
                            Thread.Sleep(200);
                            date.cont.SetEQSetting(date.eq_set[0]);
                        }
                        catch (Exception) { }
                    } break;

                case "EQset2":
                    date.eq_set[1] = (uint)(int)senderComboBox.SelectedValue;
                    if (date.voc_num == 2) {
                        try
                        {
                            StartProcess(date.cont.argv_hWnd[1].ToString());
                            Thread.Sleep(200);
                            date.cont.SetEQSetting(date.eq_set[1]);
                        }
                        catch (Exception) { }
                    } break;

                case "EQset3":
                    date.eq_set[2] = (uint)(int)senderComboBox.SelectedValue;
                    if (date.voc_num == 3) {
                        try
                        {
                            StartProcess(date.cont.argv_hWnd[1].ToString());
                            Thread.Sleep(200);
                            date.cont.SetEQSetting(date.eq_set[2]);
                        }
                        catch (Exception) { }
                    } break;

                case "EQset4":
                    date.eq_set[3] = (uint)(int)senderComboBox.SelectedValue;
                    if (date.voc_num == 4) {
                        try
                        {
                            StartProcess(date.cont.argv_hWnd[1].ToString());
                            Thread.Sleep(200);
                            date.cont.SetEQSetting(date.eq_set[3]);
                        }
                        catch (Exception) { }
                    } break;
            }

            ReadWritePropatysToFile.WriteEQ(date.eq_set);
            
            
        }

        /// <summary>
        /// 恋声の出力先を変更した時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangeOutput(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            date.outPutDevNum = (uint)(int)senderComboBox.SelectedValue;

            date.cont.Stop();
            try
            {
                StartProcess(date.cont.argv_hWnd[0].ToString());
                Thread.Sleep(200);
                date.cont.SetWaveStream(date.outPutDevNum);
            }
            catch (Exception) { }
            Thread.Sleep(100);
            date.cont.Restart();

            ReadWritePropatysToFile.WriteOutputDevNum(date.outPutDevNum);
        }

        /// <summary>
        /// リセット間隔が変わったときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetIntervalChange(object sender, EventArgs e)
        {
            NumericUpDown reset_interval = (NumericUpDown)sender;
            if (reset_interval.Value < 0 || reset_interval.Value > 59)
            {
                reset_interval.ResetText();
            }

            date.reset_interval = new TimeSpan(0, (int)reset_interval.Value, 0);
            ReadWritePropatysToFile.WriteResetInterval((int)reset_interval.Value);
            Trace.WriteLine((int)reset_interval.Value);
            
        }

        /// <summary>
        /// ショートカットが変更されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShortcatKeyDown(object sender,KeyEventArgs e)
        {

            date.form2.keysetting = true;
            TextBox box = (TextBox)sender;
            var valid = date.shortcat.Where(x => x == e.KeyCode);
            if (valid.Count() == 0)
            {
                switch (box.Name)
                {
                    case "shortcat1": date.shortcat[0] = e.KeyCode; break;
                    case "shortcat2": date.shortcat[1] = e.KeyCode; break;
                    case "shortcat3": date.shortcat[2] = e.KeyCode; break;
                    case "shortcat4": date.shortcat[3] = e.KeyCode; break;
                }

                box.Text = e.KeyCode.ToString();
                ReadWritePropatysToFile.WriteShortcatKeys(date.shortcat);

                MainTask.ShortcatChange(date);
            }
            else
            {
                MessageBox.Show("指定されたキーは被っています。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            button1.Focus();
        }

        /// <summary>
        /// ショートカットキーのところ全選択に
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.SelectAll();
            Trace.WriteLine("SelectAll");
        }

        /// <summary>
        /// エンターキー押されたらフォーカスを放す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusOutEnter(object sender,PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
            
        }

        /// <summary>
        /// フォーカス外すやつ二つ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupBoxClick(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void FocusOutEnter(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
            
        }

        /// <summary>
        /// ゲームの登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGame(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text != "")
            {
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = textBox.Text;
                    p.Start();
                    string gamename = p.ProcessName;
                    p.Kill();
                    date.gameprocess.Add(gamename);
                    MessageBox.Show("ゲームを登録しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    deliteGame.DataSource = null;
                    deliteGame.DataSource = date.gameprocess;
                    ReadWritePropatysToFile.WriteGameProcess(date.gameprocess.ToArray());
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("起動できませんでした。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                textBox.Text = "";
            }
        }

        /// <summary>
        /// ゲームの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delite(object sender, EventArgs e)
        {
            var num = deliteGame.SelectedIndex;

            date.gameprocess.RemoveAt(num);
            deliteGame.DataSource = null;
            deliteGame.DataSource = date.gameprocess;
            ReadWritePropatysToFile.WriteGameProcess(date.gameprocess.ToArray());
            MessageBox.Show(deliteGame.Text + "はゲームとして認識されなくなりました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
