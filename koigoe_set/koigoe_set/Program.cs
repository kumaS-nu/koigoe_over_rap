using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace koigoe_set
{
    static class Program
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int MK_LBUTTON = 0x0001;
       
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            int.TryParse(argv[0], out int temp);
            IntPtr intPtr = (IntPtr)temp;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Killme();

            SendMessage(intPtr, WM_LBUTTONDOWN, MK_LBUTTON, 0x000A000A);
            SendMessage(intPtr, WM_LBUTTONDOWN, MK_LBUTTON, 0x000A000A);
            SendMessage(intPtr, WM_LBUTTONUP, 0x00000000, 0x000A000A);

        }

        public static async void Killme()
        {
            await Task.Run(() => Killme_f());
        }

        public static void Killme_f()
        {
            Thread.Sleep(50);
            Environment.Exit(0);
        }

        

    }

   
}
