using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace GUI_OVFTOOL
{
    public partial class dash_board : Form
    {
       // String tex1,tex2,tex3,tex4,tex5,tex6,tex7,tex8,tex9,tex10,text,chk="",cho="";
       // int prog1,prog2,prog3,prog4,prog5,prog6,prog7,prog8,prog9,prog10,val,choice=0,progress=0;
        //private static dash_board instance;
        //Dictionary<string, int> dict = new Dictionary<string, int>();
        //public static dash_board getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new dash_board();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        public dash_board()
        {
            InitializeComponent();            
        }           
        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{                
            //    int b;
            //    cho = get_form();
            //    if (cho != "")
            //    {
            //        if (choice == 0)
            //        {
            //            choice = get_pros();
            //            dict.Add(cho, choice);
            //            progress = choice;
            //        }
            //        else if(!(chk.Contains(cho)))
            //        {
            //            choice = get_pros();
            //            dict.Add(cho, choice);
            //            progress = choice;
            //        }
            //        else if (dict.Keys.Contains(cho))
            //        {
            //            b = dict[cho];                       
            //            progress = b;
            //        }

            //        chk += cho + " ";
            //        backgroundWorker1.RunWorkerAsync();
            //    }
            //}
            //catch (Exception a)
            //{
            //    MessageBox.Show(a.Message);
            //}
        }
        public String get_form()
        {
            //String frm = "";
            //if (prog1 > 0) { val = prog1; text = tex1; frm = "Conversion"; }
            //else if (prog2 > 0) { val = prog2; text = tex2; frm = "Migration_bw_Host"; }
            //else if (prog3 > 0) { val = prog3; text = tex3; frm = "Down_vCenter"; }
            //else if (prog4 > 0) { val = prog4; text = tex4; frm = "Dep_Esxi_Host"; }
            //else if (prog5 > 0) { val = prog5; text = tex5; frm = "OVF_OnDem_up"; }
            //else if (prog6 > 0) { val = prog6; text = tex6; frm = "ISO_OnDem_up"; }
            //else if (prog7 > 0) { val = prog7; text = tex7; frm = "OVF_MySub_up"; }
            //else if (prog8 > 0) { val = prog8; text = tex8; frm = "ISO_MySub_up"; }
            //else if (prog9 > 0) { val = prog9; text = tex9; frm = "Down_OnDem"; }
            //else if (prog10 > 0) { val = prog10; text = tex10; frm = "Down_MySub"; }

            //prog1 = prog2 = prog3 = prog4 = prog5 = prog6 = prog7 = prog8 = prog9 = prog10 = 0;
            //return frm;
            return null;
        }
        public int get_pros()
        {
            int proc=0;
            if (progressBar1.Value == 0) { proc = 1; }
            else if (progressBar2.Value == 0) { proc = 2; }
            else if (progressBar3.Value == 0) { proc = 3; }
            else if (progressBar4.Value == 0) { proc = 4; }
            else if (progressBar5.Value == 0) { proc = 5; }
            else if (progressBar6.Value == 0) { proc = 6; }
            else if (progressBar7.Value == 0) { proc = 7; }
            else if (progressBar8.Value == 0) { proc = 8; }
            else if (progressBar9.Value == 0) { proc = 9; }
            else if (progressBar10.Value == 0) { proc = 10; }
            return proc;
        }
        
        public void funcall()
        {            
            Thread.Sleep(1000);
            backgroundWorker1.ReportProgress(1);                       
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {           
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                funcall();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {            
            //switch (progress)
            //{
            //    case 1:
            //        progressBar1.Value = val;
            //        label1.Text = val.ToString() + "%";
            //        String frms = dict.FirstOrDefault(x => x.Value == 1).Key;
            //        label11.Text = frms;
            //        label11.Visible = true;
            //        label1.Visible = true;
            //        progressBar1.Visible = true;
            //        btnshow1.Visible = true;
            //        btnref1.Visible = true;
            //        break;
            //    case 2:
            //        progressBar2.Value = val;
            //        label2.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 2).Key;
            //        label12.Text = frms;
            //        label12.Visible = true;
            //        label2.Visible = true;
            //        progressBar2.Visible = true;
            //        btnshow2.Visible = true;
            //        btnref2.Visible = true;
            //        break;
            //    case 3:
            //        progressBar3.Value = val;
            //        label3.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 3).Key;
            //        label13.Text = frms;
            //        label13.Visible = true;
            //        label3.Visible = true;
            //        progressBar3.Visible = true;
            //        btnshow3.Visible = true;
            //        btnref3.Visible = true;
            //        break;
            //    case 4:
            //        progressBar4.Value = val;
            //        label4.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 4).Key;
            //        label14.Text = frms;
            //        label14.Visible = true;
            //        label4.Visible = true;
            //        progressBar4.Visible = true;
            //        btnshow4.Visible = true;
            //        btnref4.Visible = true;
            //        break;
            //    case 5:
            //        progressBar5.Value = val;
            //        label5.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 4).Key;
            //        label15.Text = frms;
            //        label15.Visible = true;
            //        label5.Visible = true;
            //        progressBar5.Visible = true;
            //        btnshow5.Visible = true;
            //        btnref5.Visible = true;
            //        break;
            //    case 6:
            //        progressBar6.Value = val;
            //        label6.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 6).Key;
            //        label16.Text = frms;
            //        label16.Visible = true;
            //        label6.Visible = true;
            //        progressBar6.Visible = true;
            //        btnshow6.Visible = true;
            //        btnref6.Visible = true;
            //        break;
            //    case 7:
            //        progressBar7.Value = val;
            //        label7.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 7).Key;
            //        label17.Text = frms;
            //        label17.Visible = true;
            //        label7.Visible = true;
            //        progressBar7.Visible = true;
            //        btnshow7.Visible = true;
            //        btnref7.Visible = true;
            //        break;
            //    case 8:
            //        progressBar8.Value = val;
            //        label8.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 8).Key;
            //        label18.Text = frms;
            //        label18.Visible = true;
            //        label8.Visible = true;
            //        progressBar8.Visible = true;
            //        btnshow8.Visible = true;
            //        btnref8.Visible = true;
            //        break;
            //    case 9:
            //        progressBar9.Value = val;
            //        label9.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 9).Key;
            //        label19.Text = frms;
            //        label19.Visible = true;
            //        label9.Visible = true;
            //        progressBar9.Visible = true;
            //        btnshow9.Visible = true;
            //        btnref9.Visible = true;
            //        break;
            //    case 10:
            //        progressBar10.Value = val;
            //        label10.Text = val.ToString() + "%";
            //        frms = dict.FirstOrDefault(x => x.Value == 10).Key;
            //        label20.Text = frms;
            //        label20.Visible = true;
            //        label10.Visible = true;
            //        progressBar10.Visible = true;
            //        btnshow10.Visible = true;
            //        btnref1.Visible = true;
            //        break;
            //    default: break;
            //}        
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private void btnref1_Click(object sender, EventArgs e)
        {
            //String txt="";
            //String frms = dict.FirstOrDefault(x => x.Value == 1).Key;
            //if (frms== "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnref2_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 2).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnref3_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 3).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnref4_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 4).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnref5_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 5).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }        
        private void btnref6_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 6).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnref7_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 7).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }

        private void btnref8_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 8).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }

        private void btnref9_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 9).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }

        private void btnref10_Click(object sender, EventArgs e)
        {
            //String txt = "";
            //String frms = dict.FirstOrDefault(x => x.Value == 10).Key;
            //if (frms == "Conversion") { txt = tex1; }
            //else if (frms == "Migration_bw_Host") { txt = tex2; }
            //else if (frms == "Down_vCenter") { txt = tex3; }
            //else if (frms == "Dep_Esxi_Host") { txt = tex4; }
            //else if (frms == "OVF_OnDem_up") { txt = tex5; }
            //else if (frms == "ISO_OnDem_up") { txt = tex6; }
            //else if (frms == "OVF_MySub_up") { txt = tex7; }
            //else if (frms == "ISO_MySub_up") { txt = tex8; }
            //else if (frms == "Down_OnDem") { txt = tex9; }
            //else if (frms == "Down_MySub") { txt = tex10; }
            //textBox1.Clear();
            //textBox1.Text = txt;
        }
        private void btnshow1_Click_1(object sender, EventArgs e)
        {
            //OVF_Conv f2 = OVF_Conv.getInstance();
            //f2.Show();
        }

        private void btnshow2_Click(object sender, EventArgs e)
        {
            //Mig_Hosts f5 = Mig_Hosts.getInstance();
            //f5.Show();
        }

        private void btnshow3_Click(object sender, EventArgs e)
        {
            //VM_Dowld f6 = VM_Dowld.getInstance();
            //f6.Show();
        }

        private void btnshow4_Click(object sender, EventArgs e)
        {
            //Dply_Esxi f10 = Dply_Esxi.getInstance();
            //f10.Show();            
        }

        private void btnshow5_Click(object sender, EventArgs e)
        {
            //OVF_UpldVCD_ondem f14 = OVF_UpldVCD_ondem.getInstance();
            //f14.Show();
        }

        private void btnshow6_Click(object sender, EventArgs e)
        {
            //ISO_UpldVCD_ondem f15 = ISO_UpldVCD_ondem.getInstance();
            //f15.Show();            
        }

        private void btnshow7_Click(object sender, EventArgs e)
        {
            //OVF_UpldVCD f13 = OVF_UpldVCD.getInstance();
            //f13.Show();
        }
        private void btnshow8_Click(object sender, EventArgs e)
        {
            //ISO_UpldVCD f11 = ISO_UpldVCD.getInstance();
            //f11.Show();
        }

        private void btnshow9_Click(object sender, EventArgs e)
        {
            //VM_DowlVCD_ondem f16 = VM_DowlVCD_ondem.getInstance();
            //f16.Show();
        }

        private void btnshow10_Click(object sender, EventArgs e)
        {
            //VM_DowlVCD f8 = VM_DowlVCD.getInstance();
            //f8.Show();
        }

        public void upload1(int n,String res)
        {
            //prog1 = n;            
            //tex1 =Environment.NewLine+ res;
        }
        public void upload2(int n, String res)
        {
            //prog2 = n;
            //tex2 = Environment.NewLine + res;
        }
        public void upload3(int n, String res)
        {
            //prog3 = n;
            //tex3 = Environment.NewLine + res;
        }
        public void upload4(int n, String res)
        {
            //prog4 = n;
            //tex4 = Environment.NewLine + res;
        }
        public void upload5(int n, String res)
        {
            //prog5 = n;
            //tex5 = Environment.NewLine + res;
        }
        public void upload6(int n, String res)
        {
            //prog6 = n;
            //tex6 = Environment.NewLine + res;
        }
        public void upload7(int n, String res)
        {
            //prog7 = n;
            //tex7 = Environment.NewLine + res;
        }
        public void upload8(int n, String res)
        {
            //prog8 = n;
            //tex8 = Environment.NewLine + res;            
        }
        public void upload9(int n, String res)
        {
            //prog9 = n;
            //tex9 = Environment.NewLine + res;           
        }
        public void upload10(int n, String res)
        {
        //    prog10 = n;
        //    tex10 = Environment.NewLine + res;            
        }
        private void btnshow_Click(object sender, EventArgs e)
        {
            this.Hide();
        }       
        private void dummy2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }            
    }    
}