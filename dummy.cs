using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_OVFTOOL
{
    public partial class dummy : Form
    {
        public dummy()
        {
            InitializeComponent();
        }

        private void dummy_Load(object sender, EventArgs e)
        {
            //int prog1, prog2, prog3, prog4, prog5, prog6, prog7, prog8, prog9,i;
            //prog1 = prog2 = prog3 = prog4 = prog5 = prog6 = prog7 = prog8 = prog9 = 0;
            Dictionary<String, int> dict = new Dictionary<String, int>();
            //String tex1, tex2, tex3, tex4, tex5, tex6, tex7, tex8, tex9, tex10, text;
            //tex1 = tex2 = tex3 = tex4 = tex5 = tex6 = tex7 = tex8 = tex9 = tex10 = null;
            int i, prog1;
            String tex9, text;
            prog1 = 1;
            text = "conv";tex9 = "convaaa";
            //if (prog1 > 0) { val = prog1; text = tex1; }
            //else if (prog2 > 0) { val = prog2; text = tex2; }
            //else if (prog3 > 0) { val = prog3; text = tex3; }
            //else if (prog4 > 0) { val = prog4; text = tex4; }
            //else if (prog5 > 0) { val = prog5; text = tex5; }
            //else if (prog6 > 0) { val = prog6; text = tex6; }
            //else if (prog7 > 0) { val = prog7; text = tex7; }
            //else if (prog8 > 0) { val = prog8; text = tex8; }
            //else if (prog9 > 0) { val = prog9; text = tex9; }
            //else if (prog10 > 0) { val = prog10; text = tex10; }
            //prog1 = prog2 = prog3 = prog4 = prog5 = prog6 = prog7 = prog8 = prog9 = prog10 = 0;

            for(i=0;i<10;i++)
            {
                dict.Add(text, prog1);
                prog1++;
                text = text + "a";
            }

            if(dict.Keys.Contains(tex9))
            {
                int b = dict[tex9];
                int c = dict.Values.ElementAt(b);
                String frm= dict.FirstOrDefault(x => x.Value == 2).Key;

                MessageBox.Show("I got text 9!!!!!!!!!!!" + b + c);
            }
        }
    }
}