using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace GUI_OVFTOOL
{
    public partial class OVF_Conv : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,filename;
        private string[] cmball = new[] { "ovf","ova", "vmx" };
        private string[] cmbovf = new[] { "ova", "vmx" };
        private string[] cmbova = new[] { "ovf", "vmx" };
        private string[] cmbvmx = new[] { "ovf", "ova" };
        public OVF_Conv()
        {
            InitializeComponent();
        }
        //private static OVF_Conv instance;
        ////Function creates only one instance of the form
        //public static OVF_Conv getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new OVF_Conv();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        private void Form2_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
            txt_f_n1.GotFocus += new EventHandler(this.TextGotFocus);
            txt_f_n1.LostFocus += new EventHandler(this.TextLostFocus);
            
        }

        private void btnsrc_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            txtsrc.Text = openFileDialog1.FileName;
        }

        private void btntrg_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txttrg.Text = folderBrowserDialog1.SelectedPath;
        }


        private void btnrun_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label7.Text = "0%";
            btnlog.Visible = false;
            String eul_chk = "", log = "";
            if (txtsrc.Text == null || txtsrc.Text == "Drag and drop source file" || txtsrc.Text == "source location")
            {
                MessageBox.Show("Please browse or drag and drop source file");
            }
            else if (txttrg.Text == "" || txttrg.Text == "Target")
            {
                MessageBox.Show("Please browse the target location");
            }
            else if (txt_f_n1.Text == "" || txt_f_n1.Text == "Enter File Name")
            {
                MessageBox.Show("Please enter the save as file name");
            }
            else if (cmbtrg.Text == "Select extension" || cmbtrg.Text == "")
            {
                MessageBox.Show("Please select the extension for conversion");
            }
            else if (chklog.Checked && cmblog.Text == "")
            {
                MessageBox.Show("Please select the logging level");
            }
            else
            {
                UseWaitCursor = true;
                
                if (chklog.Checked)//Checks whether the logs option is enabled
                {
                    log = @"--X:logFile="+filename+" --X:logLevel="+cmblog.Text+" ";
                    s = log+txtsrc.Text.Trim() + " " + txttrg.Text.Trim() + "\\" + txt_f_n1.Text.Trim() + "." + cmbtrg.Text.Trim();
                    //String s=@"\"vcloud\:\/\/gayatrib@re.com:Cho@p10v1-vcd.vchs.vmware.com/cloud/org/m211057782-9439/?vdc=m211057782&org=M211057782-9439&vappTemplate=test&catalog=SG_Catalog" \"C:\Users\gayatrib\Desktop\exp\"";
                }
                else
                {
                    s = txtsrc.Text.Trim() + " " + txttrg.Text.Trim() + "\\" + txt_f_n1.Text.Trim() + "." + cmbtrg.Text.Trim();
                    //String s=@"\"vcloud\:\/\/gayatrib@re.com:Cho@p10v1-vcd.vchs.vmware.com/cloud/org/m211057782-9439/?vdc=m211057782&org=M211057782-9439&vappTemplate=test&catalog=SG_Catalog" \"C:\Users\gayatrib\Desktop\exp\"";
                }
                txtsynx.Text = s;
                OvfClass ovf = new OvfClass();
                eul_chk = ovf.eula_chk("--eula \"" + txtsrc.Text + "\"");//checking whether the manifest file has enduser licence agreement
                if (eul_chk != null)
                {
                    if (log == "")
                    {                       
                        s =  " --acceptAllEulas " + txtsrc.Text.Trim() + " " + txttrg.Text.Trim() + "\\" + txt_f_n1.Text.Trim() + "." + cmbtrg.Text.Trim();
                    }
                    else
                    {
                        s = log+" --acceptAllEulas " + txtsrc.Text.Trim() + " " + txttrg.Text.Trim() + "\\" + txt_f_n1.Text.Trim() + "." + cmbtrg.Text.Trim();
                    }
                    EULA f16 = new EULA(eul_chk, s,s, log);//Opens a new form to show the end user's licence agreement
                    f16.Show();
                }
                else
                {
                    txtres.Text = "Please Wait";
                    if (!backgroundWorker1.IsBusy)
                    {
                        // This method will start the execution asynchronously in the background
                        backgroundWorker1.RunWorkerAsync();
                    }                    
                }
            }            
        }
        //Function used to fill the details in textbox when it gets focus
        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Enter File Name")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        //Function used to show the the text in the textbox when it loses focus
        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Enter File Name";
                tb.ForeColor = Color.LightGray;
            }
        }
        //Function calls the Compute 
        public void funcall()
        {
            UseWaitCursor = true;tex = "";
            String p = txtsynx.Text;
            //OvfClass ovf = new OvfClass();
            tex= compute(p,this);
            if (tex == "Extr")
            {
                //MessageBox.Show("allow extra config");
                s = "--allowAllExtraConfig " + s;
                tex = compute(s, this);
            }
        }

        private void btnsrc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnsrc, "Browse source location for OVF,OVA or VMX file");
        }

        private void btntrg_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btntrg,"Browse target folder to save the file");
        }

        private void cmbtrg_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbtrg,"Select the conversion extension");
        }
        //function checks the value of backgroundworker Reportprogress
        public void progress(int n, String res)
        {
            tex=res;
            if (n <= 95)
            {
                backgroundWorker1.ReportProgress(n);
            }
            //main.dum2.upload1(n, res);
            //Thread.Sleep(5000);
            return;
        }
        //BackgroundWorker class for executing a time-consuming operation asynchronously
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UseWaitCursor = true;
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                funcall();
                //backgroundWorker1.ReportProgress(i);
            }           
        }
        //ProgressChanged event to report the progress of an asynchronous operation
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label7.Text = e.ProgressPercentage.ToString() + "%";
            txtres.Text = tex;
            //if (label7.Text == "10%")
            //{
            //    main.dum2.Show();
            //    main.dum2.BringToFront();
            //    this.Hide();
            //}
        }
        //RunWorkerCompleted event to handle the result of an asynchronous operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtres.Text = tex;
            progressBar1.Value = 100;
            label7.Text = "100%";
            UseWaitCursor = false;
            if (chklog.Checked)
            {
                btnlog.Visible = true;
            }
        }
        //Opens the log file
        private void btnlog_Click(object sender, EventArgs e)
        {
            try
            {               
                System.IO.File.AppendAllText(filename, Environment.NewLine + "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                System.Diagnostics.Process.Start(filename);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
        //Setting the path for loging files to be placed
        private void chklog_CheckedChanged(object sender, EventArgs e)
        {
            if(chklog.Checked)
            {
                if (!(Directory.Exists(@"C:\ProgramData\VMware")))
                {
                    Directory.CreateDirectory(@"C:\ProgramData\VMware");
                }
                filename = @"C:\ProgramData\VMware\upload.log";
                cmblog.Visible = true;
            }
            else
            {
                cmblog.Visible = false;
            }
        }
        //DrapDrop functionality implemented for source files
        private void txtsrc_DragDrop(object sender, DragEventArgs e)
        {
            Drag dr = new Drag();
            String msg = dr.drop(e);
            String chk = msg.Substring(msg.Length - 4, 4);
            if (chk==".ovf"||chk==".ova"||chk==".vmx")
                txtsrc.Text = msg;
            else
                MessageBox.Show("Please drag and drop only files with extension OVF/OVA/VMX");
        }

        private void txtsrc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        //Function checks for the extension in the source file 
        private void txtsrc_TextChanged(object sender, EventArgs e)
        {
            String msg = "";
            if (txtsrc.Text!="" && txtsrc.Text.Length>=3)
            {
                msg = txtsrc.Text.Substring(txtsrc.Text.Length - 3, 3);
            }            
            if (msg == "ovf" || msg == "ova" || msg == "vmx")
            {
                switch (msg)
                {
                    case "ovf":
                        cmbtrg.Items.Clear();
                        cmbtrg.Items.AddRange(cmbovf);
                        break;
                    case "ova":
                        cmbtrg.Items.Clear();
                        cmbtrg.Items.AddRange(cmbova);
                        break;
                    case "vmx":
                        cmbtrg.Items.Clear();
                        cmbtrg.Items.AddRange(cmbvmx);
                        break;
                    default:
                        cmbtrg.Items.Clear();
                        cmbtrg.Items.AddRange(cmball);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please browse or drag and drop source file");
            }
        }

        private void OVF_Conv_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)//When Enter is clicked the the application runs
            {
                this.AcceptButton = btnrun;
            }
        }
        //Function used to connect to the ovftool, pass arguments and get the output
        public String compute(String s, Object frm)
        {
            String tex = "", res = "";
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe";
                psi.Arguments = s;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                var proc = Process.Start(psi);
                String te = "", tf = "";
                te = proc.StandardOutput.ReadLine();//Reading the output of the ovf tool line by line
                tex += te + Environment.NewLine;
                progress(5, tex);
                for (int i = 0; i < 5; i++)
                {
                    if (tf == "Username")//checking for wrong username and password
                    {
                        res = "Please enter proper username and password \n" + tex + "erro";

                        return res;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                    if (te == null)
                    {
                        break;
                    }
                    if (te == "")
                    {
                        continue;
                    }
                    else
                    {
                        if (te.Length >= 8)
                        {
                            tf = te.Substring(0, 8);
                        }
                    }
                    if (te.Contains("ExtraConfig options exists in source"))//checking for ExtraConfig option in manifest file
                    {
                        return "Extr";
                    }
                }
                te = proc.StandardOutput.ReadLine();
                tex += te + Environment.NewLine;
                progress(10, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(20, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(30, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(40, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(50, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(60, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(70, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(80, tex);
                for (int i = 0; i < 10; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(90, tex);
                for (int i = 0; i < 30; i++)
                {
                    if (te == null)
                    {
                        break;
                    }
                    te = proc.StandardOutput.ReadLine();
                    tex += te + Environment.NewLine;
                }
                progress(100, tex);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tex;
        }
    }
}
