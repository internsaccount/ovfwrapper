using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GUI_OVFTOOL
{
    public partial class EULA : Form
    {
        String chk, cmd, tex, log,di;
        public EULA()
        {
            InitializeComponent();            
        }
        //Constructor accepting agreement,syntax,display syntax and log option
        public EULA(String eul_chk, String s,String dis, String lg)
        {
            InitializeComponent();
            txteul.Text = eul_chk;
            cmd = s;
            log = lg;
            di = dis;
        }
        private void btnsub_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label2.Text = "0%";
            btnlog.Visible = false;
            chk = chk_agr();
            if (chk==null)
            {
                MessageBox.Show("Please select whether you agreed are disagree the agreement");                
            }
            if (chk == "Agree")
            {                
                txtsynx.Text = di;
                
                if (!backgroundWorker1.IsBusy)
                {
                    // This method will start the execution asynchronously in the background
                    backgroundWorker1.RunWorkerAsync();
                }                
            }
            else if(chk=="Disagree")
                MessageBox.Show("Agreement is not accepted");
        }
        //Calls the compute function
        public void funcall()
        {
            String res, er,tex="";
           //OvfClass ovf = new OvfClass();
            res = compute(cmd,this);
            er = res.Substring(res.Length - 4, 4);
            if (er == "erro")
            {
                res = res.Remove(res.Length - 4, 4);
                MessageBox.Show(res);
            }
            else
            {
                tex = res;
            }            
        }
        private void btnlog_Click(object sender, EventArgs e)
        {
            try
            {
                String filename = @"C:\Users\Public\upload.log";
                System.IO.File.AppendAllText(@"C:\Users\Public\upload.log", Environment.NewLine + "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                System.Diagnostics.Process.Start(filename);
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }            
        }
        //Checks whether the agreement is accepted or not
        public String chk_agr()
        {
            
            if (radioButton1.Checked)
            {
                return "Agree";
            }
            else if(radioButton2.Checked)
            {
                return "Disagree";
            }
            return null;
        }
        //function checks the value of backgroundworker Reportprogress
        public void progress(int n, String res)
        {
            tex = res;
            if (n <= 95)
            {
                backgroundWorker1.ReportProgress(n);
            }
            return;
        }

        private void EULA_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnsub;
        }

        private void EULA_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.AcceptButton = btnsub;
            }
        }
        //BackgroundWorker class for executing a time-consuming operation asynchronousl
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
            label2.Text = e.ProgressPercentage.ToString() + "%";
            txteul.Text = tex;            
        }
        //RunWorkerCompleted event to handle the result of an asynchronous operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txteul.Text = tex;
            progressBar1.Value = 100;
            label2.Text = "100%";
            UseWaitCursor = false;
            if (log != "")
            {
                btnlog.Visible = true;
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
