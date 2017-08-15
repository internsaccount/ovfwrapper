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
    public partial class Dply_Esxi : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,eul_chk,log="",dis,filename;// Variable s holds main command, tex holds the main output,dis holds the Syntax of the command,filename holds the log files path,
        public Dply_Esxi()
        {
            InitializeComponent();
        }
        //private static Dply_Esxi instance;

        ////Function creates only one instance of the form
        //public static Dply_Esxi getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new Dply_Esxi();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtsrc.Text = openFileDialog1.FileName;
        }
       
        private void btnrun_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label9.Text = "0%";
            btnlog.Visible = false;            
            if (txtdhi.Text== "")
            {
                MessageBox.Show("Please enter the destination host ID");
            }
            else if (txtds.Text== "")
            {
                MessageBox.Show("Please enter the datastore name");
            }
            else if (txtun.Text == "")
            {
                MessageBox.Show("Please enter the username");
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Please enter the password");
            }
            else if(chklog.Checked && cmblog.Text == "")
            {
                MessageBox.Show("Please select the logging level");
            }
            else
            {
                if (chklog.Checked)//Checks whether the logs option is enabled 
                {
                    log = @"--X:logFile="+filename+" --X:logLevel=" + cmblog.Text + " ";
                    s = log + "-ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://root:" + txtpwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                    dis = log + "-ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                }
                else
                {
                    s = "-ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://root:" + txtpwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                    dis = "-ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                }
                //String s = "-ds=" + txtds.Text.Trim() + " \"" + txtsrc.Text.Trim() + "\" " + "vi://root:" + txtpwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                // ovftool -ds=vsanDatastore "C:\Users\schandramoul\Downloads\t1.ova" vi://root:VMware123!@10.127.132.141
                txtsynx.Text = dis;
                OvfClass ovf = new OvfClass();
                eul_chk = ovf.eula_chk("--eula \"" + txtsrc.Text + "\"");//checking whether the manifest file has enduser licence agreement
                if (eul_chk != null)
                {
                    if (log == "")
                    {
                        s = "--acceptAllEulas -ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://root:" + txtpwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                        dis = "--acceptAllEulas -ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                    }
                    else
                    {
                        s = log + "--acceptAllEulas -ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://root:" + txtpwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                        dis = log + "--acceptAllEulas -ds=\"" + txtds.Text.Trim() + "\" \"" + txtsrc.Text.Trim() + "\" " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                    }
                    EULA f16 = new EULA(eul_chk, s,dis, log);//Opens a new form to show the end user's licence agreement
                    f16.Show();
                }
                else
                {
                    txtres.Text = "Please wait";                            
                    if (!backgroundWorker1.IsBusy)
                    {
                        // This method will start the execution asynchronously in the background
                        backgroundWorker1.RunWorkerAsync();
                    }                   
                }    
            }
        }
        //Calls the compute function
        public void funcall()
        {
            try
            {
                String res, er;
                tex = "";
                //OvfClass ovf = new OvfClass();
                res = compute(s, this);
                er = res.Substring(res.Length - 4, 4);

                if (er == "sslf")
                {
                    DialogResult dialogResult = MessageBox.Show(res.Remove(res.Length - 4, 4), "SSL fingerprint", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        s = "--noSSLVerify " + s;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        throw new Exception("Finger print was not accepted");
                    }
                    res = compute(s, this);
                    tex = res;
                }
                else if (er == "Extr")
                {
                    //MessageBox.Show("allow extra config");
                    s = "--allowAllExtraConfig " + s;
                    res = compute(s, this);
                    tex = res;
                }
                else { }
                if (er == "erro")
                {
                    //res = res.Remove(res.Length - 4, 4);
                    throw new Exception("Please provide correct username and password");
                }
                else
                {
                    tex = res;
                }
            }
            catch (Exception a)
            {                
                MessageBox.Show(a.Message);
            }
        }
        //function checks the value of backgroundworker Reportprogress
        public void progress(int n, String res)
        {
            tex = res;
            if (n <= 95)
            {
                backgroundWorker1.ReportProgress(n);
            }
            //main.dum2.upload4(n, res);
            Thread.Sleep(5000);
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
            }
        }
        //ProgressChanged event to report the progress of an asynchronous operation
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label9.Text = e.ProgressPercentage.ToString() + "%";
            txtres.Text = tex;
            //if (label9.Text == "10%")
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
            label9.Text = "100%";
            UseWaitCursor = false;
            if (chklog.Checked)
            {
                btnlog.Visible = true;
            }
        }
        private void btnsrc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnsrc,"Please browse the OVF/OVA file to deploy");
        }
        private void txtds_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtds,"Please enter datastore name of the target host");
        }
        private void txtdhi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtdhi,"Please enter the destination host ID");
        }
        //DrapDrop functionality implemented for source files
        private void txtsrc_DragDrop(object sender, DragEventArgs e)
        {
            Drag dr = new Drag();
            String msg= dr.drop(e);
            if (msg.Substring(msg.Length-4,4) == ".ova"|| msg.Substring(msg.Length - 4, 4)==".ovf")
                txtsrc.Text = msg;
            else
                MessageBox.Show("Please drop only files with extension OVF or OVA");
        }
        private void txtsrc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        private void Dply_Esxi_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.AcceptButton = btnrun;
            }
        }
        private void Dply_Esxi_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
           
        }        
        //Opening the log file
        private void btnlog_Click(object sender, EventArgs e)
        {
            try
            {
                //filename = @"C:\ProgramData\VMware\upload.log";
                System.IO.File.AppendAllText(filename, Environment.NewLine + "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
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
            if (chklog.Checked)
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
                te = proc.StandardOutput.ReadLine();
                tex += te + Environment.NewLine;
                progress(5, tex);
                for (int i = 0; i < 5; i++)
                {
                    if (tf == "Username")
                    {
                        res = "Please enter proper username and password \n" + tex + "erro";

                        return res;
                    }
                    te = proc.StandardOutput.ReadLine();//Reading the output of the ovf tool line by line
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
                    if (te.Contains("SSL fingerprint"))//Catches for ssl fingerprint
                    {
                        return te+"sslf";
                    }
                    if (te.Contains("ExtraConfig options exists in source"))//Catches for Extraconfig
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
                MessageBox.Show(e.Message);
            }
            return tex;
        }
    }
}
