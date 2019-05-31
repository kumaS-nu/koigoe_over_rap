using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Overlay
{
    static class Program
    {
        static Overlay overlay;
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProcessDPIAware();
            int.TryParse(argv[0], out int voc_num);
            if(voc_num == 0)
            {
                voc_num = 4;
            }
            Color color = new Color();
            bool ingame;
            if (argv[2] == "Blue")
            {
                color = Color.Blue;
            }
            else if (argv[2] == "Red")
            {
                color = Color.Red;
            }

            if (argv[1] == "true")
            {
                ingame = true;
            }
            else
            {
                ingame = false;
            }
            overlay = new Overlay(voc_num,ingame,color);
            overlay.Show();
            Application.Run();
        }

        
    }

}
