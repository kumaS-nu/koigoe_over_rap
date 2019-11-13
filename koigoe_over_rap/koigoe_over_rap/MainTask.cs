using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace koigoe_over_rap
{
    static class MainTask
    {
        private static Form2 fm2;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Program_UnhandledException);
            KoigoeControler.SetProcessDPIAware();

            Process.GetProcessesByName("koigoe_over_rap")[0].PriorityClass = ProcessPriorityClass.RealTime;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Dates date = new Dates
            {
                //ここからファイルのデータ読み込み

                path = ReadWritePropatysToFile.ReadPath(),

                outPutDevNum = ReadWritePropatysToFile.ReadOutputDevNum(),

                reset_interval = ReadWritePropatysToFile.ReadResetInterval(),

                eq_set = ReadWritePropatysToFile.ReadEQ(),

                shortcat = ReadWritePropatysToFile.ReadShortcatKeys()
            };
            //ここまで


            //これが二重起動しているなどの場合落ちる
            if (Process.GetProcessesByName("koigoe_over_rap").Length > 1)
            {
                Environment.Exit(2);
            }

            //恋声と一緒に立ち上げる場合が多いだろうから恋声が立ち上がるのを5秒まで待つ
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                Thread.Sleep(100);
                try
                {
                    var temp = Process.GetProcessesByName("koigoe")[0];
                    if (temp != null)
                    {
                        temp.PriorityClass = ProcessPriorityClass.High;
                        try
                        {
                            Process.GetProcessesByName("voicemeeterpro")[0].PriorityClass = ProcessPriorityClass.RealTime;
                        }
                        catch (IndexOutOfRangeException) { }

                        break;
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    if (timer.ElapsedMilliseconds > 5000)
                    {
                        Environment.Exit(1);
                    }
                }

            }
            Thread.Sleep(100);

            KoigoeControler controler = new KoigoeControler(date);
            date.cont = controler;
            controler.Stop();
            //なんかプログラムが走り切らないとポップアップしてくれなかったからそのためのなんやかんや（別のプログラムを起動）
            date.pn = new Process();
            date.pn.StartInfo.FileName = date.path[1];
            date.pn.StartInfo.Arguments = controler.argv_hWnd[0].ToString();
            try
            {
                date.pn.Start();
            }
            catch (Exception)
            {   //これが無くてもどうにかはなるのでエラー通知だけしておいてとばす
                MessageBox.Show("koigoe_setのパスが間違っています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                goto Skip;
            }
            while (!date.pn.HasExited) { }
            Thread.Sleep(200);  //これが無いと早すぎてうまくいかない
            controler.SetWaveStream(date.outPutDevNum);

            Thread.Sleep(100); //これも

            date.pn.StartInfo.Arguments = controler.argv_hWnd[1].ToString();
            date.pn.Start();

            while (!date.pn.HasExited) { }
            Thread.Sleep(200); //これも
            IntPtr close = controler.SetEQSetting(date.eq_set[0]);
            Thread.Sleep(200); //これも
            Skip:


            controler.SendClick(controler.hWnd[0]); //1番のプロファイルをクリック

            controler.Restart();


            OverlayForm overlay = new OverlayForm(date);
            date.overlayForm = overlay;

            while (date.overlayForm.TopMost == false)
            {
                date.overlayForm.TopMost = true;
            }

            date.overlayForm.Show();

            fm2 = new Form2(date);
            date.form2 = fm2;
            ShortcatChange(date);

            AnsyncFunctions ansync = new AnsyncFunctions(date);
            date.ansync = ansync;

            Form1 fm1 = new Form1(date);
            date.form1 = fm1;
            ansync.RunAll();
            Application.Run(fm1);
            controler.Stop();
        }

        public static void ShortcatChange(Dates date)
        {
            fm2.ShortcatChange(date.shortcat);
        }

        //例外捕捉
        public static void Program_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ShowError(ex);
            }
        }
        //これも
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowError(e.Exception);
        }
        //エラー見せる
        private static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message + "\n" + ex.StackTrace.Split('\\').Last() + "\nTwitter:\n@kumaSVTuber1までバグ報告してくれると修正するかも", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(3);
        }

    }
}
