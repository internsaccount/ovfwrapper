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
    public partial class Mig_Hosts : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,dis,log="",filename;
        public Mig_Hosts()
        {
            InitializeComponent();
        }
        //private static Mig_Hosts instance;
        ////Function creates only one instance of the form
        //public static Mig_Hosts getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new Mig_Hosts();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                label12.Text = "0%";
                btnlog.Visible = false;
                if (txtdtstr.Text == "")
                {
                    MessageBox.Show("Please enter the datastore name");
                }
                else if (txtshi.Text == "")
                {
                    MessageBox.Show("Please enter the source host ID");
                }
                else if (txtsrc_un.Text == "")
                {
                    MessageBox.Show("Please enter the username");
                }
                else if (txtsrc_pwd.Text == "")
                {
                    MessageBox.Show("Please enter the password");
                }
                else if (txtsrc_vm.Text == "")
                {
                    MessageBox.Show("Please enter the filename ");
                }
                else if (txtdtn_un.Text == "")
                {
                    MessageBox.Show("Please enter the destination username");
                }
                else if (txtdtn_pwd.Text == "")
                {
                    MessageBox.Show("Please enter the password");
                }
                else if (txtdhi.Text == "")
                {
                    MessageBox.Show("Please enter the destination host ID");
                }
                else if (chklog.Checked && cmblog.Text == "")
                {
                    MessageBox.Show("Please select the logging level");
                }
                else
                {
                    if (chklog.Checked)//Checks whether the logs option is enabled
                    {
                        log = @"--X:logFile="+filename+" --X:logLevel=" + cmblog.Text + " ";
                        s = log + "-ds=\"" + txtdtstr.Text.Trim() + "\" vi://root:" + txtsrc_pwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/" + txtsrc_vm.Text.Trim() + " " + "vi://root:" + txtdtn_pwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                        dis = log + "-ds=\"" + txtdtstr.Text.Trim() + "\" vi://<username>:<password>@" + txtshi.Text.Trim() + "/" + txtsrc_vm.Text.Trim() + " " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                    }
                    else
                    {
                        s = "-ds=\"" + txtdtstr.Text.Trim() + "\" vi://root:" + txtsrc_pwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/" + txtsrc_vm.Text.Trim() + " " + "vi://root:" + txtdtn_pwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                        dis = "-ds=\"" + txtdtstr.Text.Trim() + "\" vi://<username>:<password>@" + txtshi.Text.Trim() + "/" + txtsrc_vm.Text.Trim() + " " + "vi://<username>:<password>@" + txtdhi.Text.Trim();
                    }
                    //this.timer1.Start(); 
                    // s = "-ds=" + txtdtstr.Text.Trim() + " vi://root:" + txtsrc_pwd.Text.Trim() + "@" + txtshi.Text.Trim() + "/" + txtsrc_vm.Text.Trim() + " " + "vi://root:" + txtdtn_pwd.Text.Trim() + "@" + txtdhi.Text.Trim();
                    // ovftool.exe -ds=vsanDatastore vi://root:VMware123!@10.127.128.219/cmdtest vi://root:VMware123!@10.127.132.141
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
            //main.dum2.upload2(n, res);
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
            label12.Text = e.ProgressPercentage.ToString() + "%";
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
            label12.Text = "100%";
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
                res = compute(s);
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
                    res = compute(s);
                    tex = res;
                }
                else if (er == "Extr")
                {
                    //MessageBox.Show("allow extra config");
                    s = "--allowAllExtraConfig " + s;
                    res = compute(s);
                    tex = res;
                }
                else
                { }
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

        private void txtdtstr_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtdtstr,"Enter the datastore ID of the target host ");
        }

        private void txtshi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtshi, "Enter the source host ID");
        }

        private void txtdhi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtdhi, "Enter the destination ID");
        }

        private void txtsrc_vm_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtsrc_vm,"Enter the name of the VM to migrate");
        }

        private void Mig_Hosts_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.AcceptButton = btn_run;
            }
        }

        private void Mig_Hosts_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btn_run;
        }
        //Opens the log file
        private void button1_Click(object sender, EventArgs e)
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
                cmblog.Visible = false;
            }
        }
        //Function used to connect to the ovftool, pass arguments and get the output
        public String compute(String s)
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
                //te = proc.StandardOutput.ReadLine();
                //tex += te + Environment.NewLine;
                //progress(5, tex);
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
                        return te + "sslf";
                    }
                    if (te.Contains("ExtraConfig options exists in source"))
                    {
                        return "Extr";
                    }
                }
                progress(5, tex);
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
