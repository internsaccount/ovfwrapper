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
    public partial class VM_Dowld : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,dis,log="",conf,filename;
        public VM_Dowld()
        {
            InitializeComponent();
        }
        //private static VM_Dowld instance;
        ////Function creates only one instance of the form
        //public static VM_Dowld getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new VM_Dowld();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txttrg.Text = folderBrowserDialog1.SelectedPath;
        }
        private void btnrun_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label9.Text = "0%";
            btnlog.Visible = false;
            try
            {                
                if (txtshi.Text == "")
                {
                    MessageBox.Show("Please enter the source host ID");
                }
                else if (txtpwd.Text == "")
                {
                    MessageBox.Show("Please enter the password");
                }
                else if (txt_v_n.Text == "")
                {
                    MessageBox.Show("Please enter the filename ");
                }
                else if (chklog.Checked && cmblog.Text == "")
                {
                    MessageBox.Show("Please select the logging level");
                }
                else
                {
                    int comp;
                    switch(cmbcomp.Text)
                    {
                        case "Small":
                            comp = 1;
                            break;
                        case "Medium":
                            comp = 5;
                            break;
                        case "Large":
                            comp = 9;
                            break;
                        default:
                            comp = 1;
                            break;
                    }
                    if (chklog.Checked)//Checks whether the logs option is enabled
                    {
                        log = @"--X:logFile="+filename+" --X:logLevel=" + cmblog.Text + " ";
                        s = log + "--compress=" + comp + " --makeDeltaDisks vi://root:" + txtpwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/" + txt_v_n.Text.Trim() + "/ " + txttrg.Text.Trim();
                        dis = log + "--compress=" + comp + " --makeDeltaDisks vi://<username>:<password>@" + txtshi.Text.Trim() + "/" + txt_v_n.Text.Trim() + "/ " + txttrg.Text.Trim();
                    }
                    else
                    {
                        s = "--compress=" + comp + " --makeDeltaDisks vi://root:" + txtpwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/" + txt_v_n.Text.Trim() + "/ " + txttrg.Text.Trim();
                        dis = "--compress=" + comp + " --makeDeltaDisks vi://<username>:<password>@" + txtshi.Text.Trim() + "/" + txt_v_n.Text.Trim() + "/ " + txttrg.Text.Trim();
                    }
                    // s = "--compress=" + cmbcomp.Text.Trim() + " --makeDeltaDisks vi://root:" + txtpwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/"+ txt_v_n.Text.Trim() + "/ " + txttrg.Text.Trim();
                    //ovftool --compress=1 --makeDeltaDisks vi://10.127.132.141/gvm/ C:\Users\schandramoul\downloads\
                    txtsynx.Text = dis;
                    txtres.Text = "Please Wait";
                    if (!backgroundWorker1.IsBusy)
                    {
                        // This method will start the execution asynchronously in the background
                        backgroundWorker1.RunWorkerAsync();
                    }
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
            //main.dum2.upload3(n, res);
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
        //Function calls the Compute 
        public void funcall()
        {
            try
            {
                String res, er; tex = "";

                //OvfClass ovf = new OvfClass();
                res = compute(s, this);
                er = res.Substring(res.Length - 4, 4);
                if (er == "sslf")
                {
                    DialogResult dialogResult = MessageBox.Show(res, "SSL fingerprint", MessageBoxButtons.YesNo);
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
                else
                { }
                if (er == "erro")
                {
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
        private void txtshi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtshi,"Enter the source host id");
        }

        private void txttrg_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txttrg,"Browse target folder to save the file");
        }

        private void cmbcomp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbcomp,"Select the compression ratio");
        }

        private void txt_v_n_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txt_v_n,"Enter the name of the VM to download");
        }

        private void VM_Dowld_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.AcceptButton = btnrun;
            }
        }

        private void VM_Dowld_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
       
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1,"Select the target location");
        }
        //Open the log file
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
                MessageBox.Show("Please select the logging levels");
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
                    if (te.Contains("SSL fingerprint"))
                    {
                        return tex + "sslf";
                    }
                    if (te.Contains("ExtraConfig options exists in source"))
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
