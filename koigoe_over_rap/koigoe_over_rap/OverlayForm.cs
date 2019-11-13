using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Linq;
using System;

namespace koigoe_over_rap
{
    class OverlayForm : Form
    {
        public Label lblMessage;
        public string name;
        private Color color = Color.Red;
        public Dates date;

        public OverlayForm() { }
        public OverlayForm(Dates dates)
        {
            date = dates;
            name = "装甲明朝";
            InstalledFontCollection ifc = new InstalledFontCollection();
            try
            {
                ifc.Families.Where(x => x.Name == "装甲明朝").First();
            }catch(Exception)
            {
                name = "Arial";
            }
            ShowInTaskbar = false;
            //フォームの境界線をなくす
            FormBorderStyle = FormBorderStyle.None;
            //大きさを適当に変更
            Size = new Size(512, 512);
            //透明を指定する
            TransparencyKey = BackColor;
            Opacity = 0.7;

            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);

             lblMessage = new Label
            {
                Anchor = AnchorStyles.Left,
                Text = "1",
                Font = new Font(name, 32f),
                ForeColor = color,
                AutoSize = true
            };
            
            lblMessage.Left = 0;
            lblMessage.Top = 0;

            Controls.Add(lblMessage);
            
        }

        public void Change_num(int idx)
        {
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
        }

       public void ChangeColor(Color newcolor)
        {
            color = newcolor;
            int num;
            if (date.voc_num != 0)
            {
                num = date.voc_num;
            }
            else
            {
                num = 4;
            }

            lblMessage = new Label
            {
                Anchor = AnchorStyles.Left,
                Text = num.ToString(),
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
                return cp;
            }
        }
        
    }
}
