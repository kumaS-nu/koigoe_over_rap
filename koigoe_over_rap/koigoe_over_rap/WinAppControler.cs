using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using HongliangSoft.Utilities.Gui;


namespace koigoe_over_rap
{
    class KoigoeControler
    {
        //ただの定数
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int MK_LBUTTON = 0x0001;
        public const int CB_SETCURSEL = 0x014E;


        /// <param name="start_hWnd">   変換開始のハンドラ                             </param>
        /// <param name="stop_hWnd">    変換終了のハンドラ                             </param>
        /// <param name="argv_hWnd">    ウィンドウをポップアップさせるボタンのハンドラ </param>
        /// <param name="hWnd">         メイン画面の数字ボタンのハンドラ               </param>
        /// <param name="ingame">       ゲームのフルスクリーンかどうか</param>
        /// <param name="voc_num">      今のセッティングは何番目のか                   </param>
        /// <param name="eq">           EQがonかoffか                                  </param>
        /// <param name="reset_interval">リセットの間隔を入れてる                      </param>
        public IntPtr start_hWnd;
        public IntPtr stop_hWnd;
        public IntPtr[] argv_hWnd = new IntPtr[2];
        public IntPtr[] hWnd = new IntPtr[4];

        /// <param name="mother_window">恋声のウィンドウのハンドラ                     </param>
        public Process mother_window { get; private set; }

        private Dates date;


        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();



        public KoigoeControler(Dates dates)
        {
            Handler_Setup();
            date = dates;
            date.gameprocess = ReadWritePropatysToFile.ReadGameProcess();
        }

        /// <summary>
        /// クリックしたということを送る
        /// </summary>
        /// <param name="intPtr">送り先のハンドラ</param>
        public void SendClick(IntPtr intPtr)
        {
            SendMessage(intPtr, WM_LBUTTONDOWN, MK_LBUTTON, 0x000A000A);
            SendMessage(intPtr, WM_LBUTTONUP, 0x00000000, 0x000A000A);
        }

        /// <summary>
        /// メイン画面のボタンのハンドラをとってくる
        /// </summary>
        /// <param name="top">恋声のウィンドウ</param>
        private void FindTargetButton(Window top)
        {
            var all = SearchWindow.GetAllChildWindows(top, new List<Window>());

            for (int i = 1; i < 5; i++)
            {
                hWnd[i - 1] = all.Where(x => x.ClassName == "Button" && (x.Title == i.ToString())).First().hWnd;
            }

            start_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == "LIVE")).First().hWnd;
            stop_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == "STOP")).First().hWnd;
            argv_hWnd[0] = all.Where(x => x.ClassName == "Button" && (x.Title == "設定")).First().hWnd;
            argv_hWnd[1] = all.Where(x => x.ClassName == "Button" && (x.Title == "Effect")).First().hWnd;
        }

        /// <summary>
        /// イコライザーの設定を変更
        /// </summary>
        /// <param name="num">何番目の設定を使うか</param>
        public IntPtr SetEQSetting(uint num)
        {

            var c_window = FindWindow("#32770", "Sound Effect (Graphic Equalizer & Reverb)");
            while (AnsyncFunctions.GetWindowLong(c_window, AnsyncFunctions.GWL_STYLE) % 0x20000000 / 0x10000000 == 0)
            {
                Thread.Sleep(100);
                c_window = FindWindow("#32770", "Sound Effect (Graphic Equalizer & Reverb)");
            }
            var top = SearchWindow.GetWindow(c_window);

            var all = SearchWindow.GetAllChildWindows(top, new List<Window>());
            if (num != 0)
            {
                IntPtr num_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == num.ToString())).First().hWnd;
                SendClick(num_hWnd);
                Thread.Sleep(1);
            }

            IntPtr eq_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == "EQを有効にする")).First().hWnd;

            if (date.eq == (num == 0))
            {
                SendClick(eq_hWnd);
                Thread.Sleep(1);
                date.eq = !date.eq;
            }
            IntPtr close_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == "閉じる")).First().hWnd;

            SendClick(close_hWnd);
            Thread.Sleep(1);
            return c_window;
        }

        /// <summary>
        /// 音声の出力先を変更
        /// </summary>
        public IntPtr SetWaveStream(uint out_idx)
        {
            var c_window = FindWindow("#32770", "恋声の設定");
            while(c_window == (IntPtr)0)
            {
                Thread.Sleep(100);
                c_window = FindWindow("#32770", "恋声の設定");
            }
            var top = SearchWindow.GetWindow(c_window);

            var all = SearchWindow.GetAllChildWindows(top, new List<Window>());
            var temp = all.Where(x => x.ClassName == "ComboBox").ToArray();
            foreach (var t in temp)
            {
                Trace.WriteLine(t);
            }
            IntPtr combo_hWnd = all.Where(x => x.ClassName == "ComboBox" && (x.Title == null)).Skip(2).First().hWnd;
            IntPtr ok_hWnd = all.Where(x => x.ClassName == "Button" && (x.Title == "OK")).First().hWnd;

            SendMessage(combo_hWnd, CB_SETCURSEL, out_idx, 0);
            Thread.Sleep(1);
            SendClick(ok_hWnd);
            Thread.Sleep(1);
            return ok_hWnd;
        }




        /// <summary>
        /// （落とさないで）リセットする
        /// </summary>
        public void Restart()
        {
            SendClick(stop_hWnd);
            SendClick(start_hWnd);
        }

        public void Stop()
        {
            SendClick(stop_hWnd);
        }

        /// <summary>
        /// ボイチェンのセットを変更
        /// </summary>
        public void ChangeVoc(Process pn, uint[] eq_set, OverlayForm fm)
        {
            SendClick(hWnd[date.voc_num]);
            try
            {
                pn.Start();
            }
            catch (Exception) { goto pass; }
            while (!pn.HasExited) { }
            Thread.Sleep(200);
            SetEQSetting(eq_set[date.voc_num]);
            pass:
            fm.Change_num(date.voc_num + 1);
            if (++date.voc_num > 3)
            {
                date.voc_num = 0;
            }
        }

        /// <summary>
        /// 恋声の今のセットを一つ戻す
        /// </summary>
        public void ChangeVocDec()
        {
            if (date.voc_num < 1)
            {
                date.voc_num += 4;
            }

            --date.voc_num;
        }



        /// <summary>
        /// 恋声を落とす
        /// </summary>
        public void KillKoigoe()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("taskkill /pid " + mother_window.Id.ToString() + " /f");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            while (!mother_window.HasExited)
            {

            }
        }


        /// <summary>
        /// アプリを起動
        /// </summary>
        public void RunApp(string[] path)
        {


            Process koigoe = new Process();
            koigoe.StartInfo.FileName = path[0];

            koigoe.Start();
            koigoe.WaitForInputIdle();

            Application.Restart();
        }



        /// <summary>
        /// ハンドラーをセット
        /// </summary>
        public void Handler_Setup()
        {
            mother_window = Process.GetProcessesByName("koigoe")[0];

            var main_window_handler = mother_window.MainWindowHandle;
            // 対象のボタンを探す
            FindTargetButton(SearchWindow.GetWindow(main_window_handler));
        }

        public enum ProcessDPIAwareness
        {
            ProcessDPIUnaware = 0,
            ProcessSystemDPIAware = 1,
            ProcessPerMonitorDPIAware = 2
        }

    }

    class Window
    {
        public string ClassName;
        public string Title;
        public IntPtr hWnd;
    }

    static class SearchWindow
    {
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        // 指定したウィンドウの全ての子孫ウィンドウを取得し、リストに追加する
        public static List<Window> GetAllChildWindows(Window parent, List<Window> dest)
        {
            dest.Add(parent);
            EnumChildWindows(parent.hWnd).ToList().ForEach(x => GetAllChildWindows(x, dest));
            return dest;
        }

        private static IEnumerable<Window> EnumChildWindows(IntPtr hParentWindow)
        {
            IntPtr hWnd = IntPtr.Zero;
            while ((hWnd = FindWindowEx(hParentWindow, hWnd, null, null)) != IntPtr.Zero) { yield return GetWindow(hWnd); }
        }

        // ウィンドウハンドルを渡すと、ウィンドウテキスト（ラベルなど）、クラス、スタイルを取得してWindowsクラスに格納して返す
        public static Window GetWindow(IntPtr hWnd)
        {
            int textLen = GetWindowTextLength(hWnd);
            string windowText = null;
            if (0 < textLen)
            {
                //ウィンドウのタイトルを取得する
                StringBuilder windowTextBuffer = new StringBuilder(textLen + 1);
                GetWindowText(hWnd, windowTextBuffer, windowTextBuffer.Capacity);
                windowText = windowTextBuffer.ToString();
            }

            //ウィンドウのクラス名を取得する
            StringBuilder classNameBuffer = new StringBuilder(256);
            GetClassName(hWnd, classNameBuffer, classNameBuffer.Capacity);

            return new Window() { hWnd = hWnd, Title = windowText, ClassName = classNameBuffer.ToString() };
        }
    }

    /// <summary>
    /// ショートカットキーを利用するためのクラス
    /// </summary>
    partial class Form2 : Form
    {
        private KeyboardHook keyHook;
        private bool isWork = false;
        private bool invalid = false;
        public bool keysetting = false;
        private Dates date;

        public Form2(Dates dates)
        {
            keyHook = new KeyboardHook();
            keyHook.KeyboardHooked += new KeyboardHookedEventHandler(KeyHook_Up);
            date = dates;
        }

        public void ShortcatChange(Keys[] keys)
        {
            date.shortcat = keys;
        }


        private void KeyHook_Up(object sender, KeyboardHookedEventArgs e)
        {

            if (!isWork && !keysetting)
            {

                if (!invalid)
                {

                    if (e.KeyCode == date.shortcat[0] && e.UpDown == KeyboardUpDown.Up)
                    {
                        isWork = true;
                        date.cont.ChangeVoc(date.pn, date.eq_set, date.overlayForm);
                        isWork = false;
                    }

                    if (e.KeyCode == date.shortcat[1] && e.UpDown == KeyboardUpDown.Up)
                    {
                        isWork = true;
                        date.cont.Restart();
                        isWork = false;
                    }

                    if (e.KeyCode == date.shortcat[2] && e.UpDown == KeyboardUpDown.Up)
                    {
                        if (!date.ingame)
                        {
                            isWork = true;
                            date.cont.KillKoigoe();
                            date.cont.RunApp(date.path);
                            isWork = false;
                        }
                    }
                }

                if (e.KeyCode == date.shortcat[3] && e.UpDown == KeyboardUpDown.Up)
                {
                    isWork = true;
                    invalid = !invalid;
                    if (invalid == true)
                    {
                        date.overlayForm.ChangeColor(System.Drawing.Color.Blue);
                    }
                    else
                    {
                        date.overlayForm.ChangeColor(System.Drawing.Color.Red);
                    }
                    isWork = false;
                }
            }

            keysetting = false;
        }

    }

}
