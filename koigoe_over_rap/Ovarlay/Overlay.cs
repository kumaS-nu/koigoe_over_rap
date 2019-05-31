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

namespace Overlay
{
    class Overlay : Form
    {
        public Label lblMessage;
        public string name;
        public int voc_num = 1;
        public Color color = Color.Red;

        public Overlay() { }
        public Overlay(int num, bool ingame, Color initcolor)
        {
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
                Task.Run(IngameAsync);
            }
        }

        private void IngameAsync()
        {
            while (true)
            {
                Invoke((MethodInvoker)(() => TopMost = true));
                Thread.Sleep(1000);
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
                cp.ExStyle |= 0x08000000;
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

    }
}
