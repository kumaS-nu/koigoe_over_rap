using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace koigoe_over_rap
{
    class Dates
    {
        /// <param name="eq_set">       イコライザーのセッティングを保存               </param>
        /// <param name="fm">           オーバーレイの画面                             </param>
        /// <param name="pn">           他のプログラム立ち上げる用のプロセス           </param>
        /// <param name="path">         パス関連のいろいろ                             </param>
        /// <param name="reset_interval">リセットの間隔を入れてる                      </param>
        public uint[] eq_set = new uint[4];
        public Process overlay;
        public IntPtr layptr;
        public uint outPutDevNum = new uint();
        public Process pn;
        public string[] path = new string[2];
        public TimeSpan reset_interval;
        public Keys[] shortcat = new Keys[4];
        public bool ingame = false;
        public bool laygame = false;
        public int voc_num = 1;
        public bool eq = false;
        public List<string> gameprocess = new List<string>();
        public KoigoeControler cont;
        public AnsyncFunctions ansync;
        public Form2 form2;
        public Form1 form1;
    }
}
