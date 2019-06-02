using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Overlay
{
    class Overlay : Form
    {
        public Label lblMessage;
        public string name;
        public int voc_num = 1;
        public Color color = Color.Red;
        private Process game = new Process();

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        const int SWP_NOSIZE = 0x0001;
        const int SWP_NOMOVE = 0x0002;
        const int SWP_SHOWWINDOW = 0x0040;
        const int HWND_TOPMOST = -1;
        const int HWND_TOP = 0;
        const int HWND_NOTOPMOST = -2;
        public Overlay() { }
        public Overlay(int num, bool ingame, Color initcolor)
        {
            InitializeComponent();
            Text = "Overlay";
            voc_num = num;
            color = initcolor;
            ResizeRedraw = true;
            ShowInTaskbar = false;
            name = "装甲明朝";
            InstalledFontCollection ifc = new InstalledFontCollection();
            try
            {
                ifc.Families.Where(x => x.Name == "装甲明朝").First();
            }
            catch (Exception)
            {
                name = "Arial";
            }

            //フォームの境界線をなくす
            FormBorderStyle = FormBorderStyle.None;
            //大きさを適当に変更
            Size = new Size(120, 120);
            //透明を指定する
            AllowTransparency = true;
            TransparencyKey = BackColor;
            Opacity = 0.7;

            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            ChangeColor(color);
            if (ingame)
            {
                var hWnd = GetForegroundWindow();

                GetWindowThreadProcessId(hWnd, out int id);
                game = Process.GetProcessById(id);
                Task.Run(IngameAsync);
            }

            Task.Run(MotherCheckAsync);
        }

        private void IngameAsync()
        {
            Thread.Sleep(3000);
            while (true)
            {
                SetWindowPos(game.MainWindowHandle, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                //SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                Invoke((MethodInvoker)(() => BringToFront()));
                Thread.Sleep(1000);
            }
        }

        private void MotherCheckAsync()
        {
            Thread.Sleep(10000);
            while (true)
            {
                if(FindWindow(null,"koigoe_over_rap") == new IntPtr(0))
                {
                    Environment.Exit(0);
                }
                
                Thread.Sleep(10000);
            }
        }

        public void Change_num(int idx)
        {
            if(idx == 0)
            {
                idx = 4;
            }

            lblMessage = new Label
            {
                Anchor = AnchorStyles.Left,
                Text = idx.ToString(),
                Font = new Font(name, 32f),
                ForeColor = color,
                AutoSize = true
            };

            lblMessage.Left = 0;
            lblMessage.Top = 0;
            Controls.Clear();
            Controls.Add(lblMessage);
            voc_num = idx;
        }

        public void ChangeColor(Color newcolor)
        {
            color = newcolor;

            lblMessage = new Label
            {
                Anchor = AnchorStyles.Left,
                Text = voc_num.ToString(),
                Font = new Font(name, 32f),
                ForeColor = color,
                AutoSize = true
            };

            lblMessage.Left = 0;
            lblMessage.Top = 0;
            Controls.Clear();
            Controls.Add(lblMessage);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                //cp.ExStyle |= 0x08000000;
                return cp;
            }
        }
        
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x400:
                    switch ((int)m.WParam)
                    {
                        case 0x0: Change_num((int)m.LParam); break;
                        case 0x1:
                            switch ((int)m.LParam)
                            {
                                case 0x0: ChangeColor(Color.Blue); break;
                                case 0x1: ChangeColor(Color.Red); break;
                            }
                            break;
                    }
                    break;
            }
            m.Result = IntPtr.Zero;
            base.WndProc(ref m);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Overlay
            // 
            this.ClientSize = new System.Drawing.Size(292, 212);
            this.DoubleBuffered = true;
            this.Name = "Overlay";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
    }
}
