﻿using System;
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
    public partial class VM_DowlVCD : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,dis,filename;// Variable s holds the value of the main command, tex holds the main output, fdn holds the ,dis holds the Syntax of the command
        String surl, vcd = "", sorg = "", input = "", output = "",url="";
        int lurl, j, i, k;//Variable lurl holds the length of the destination URL
        public VM_DowlVCD()
        {
            InitializeComponent();
        }
        //private static VM_DowlVCD instance;
        ////Function creates only one instance of the form
        //public static VM_DowlVCD getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new VM_DowlVCD();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        private void btntrg_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txttrg.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label9.Text = "0%";
            btnlog.Visible = false;
            if (txtui.Text == "")
            {
                MessageBox.Show("Please enter the username");
            }
             else if (txtpwd.Text == "")
             {
                 MessageBox.Show("Please enter the password");
             }
            else if (txturl.Text == "")
            {
                MessageBox.Show("Please enter the URL");
            }
            else if(txtvapp.Text== "")
            {
                MessageBox.Show("Please enter the vApp template name");
            }
            else if (txtcat.Text == "")
            {
                MessageBox.Show("Please enter the catalog name");
            }
            else if (chklog.Checked && cmblog.Text == "")
            {
                MessageBox.Show("Please select the logging level");
            }
            else
            {
                //Pulling organization name
                if (txtorg.Text == "" || txtorg.Text == " ")
                {
                    output = orgcall();
                    if (output == null)
                    {
                        MessageBox.Show("Please make sure URL is proper with a / at last ");
                    }
                    else
                        txtorg.Text = output.ToUpper();
                }
                //Pulling VCD name
                if (txtvdc.Text == "" || txtvdc.Text == " ")
                {
                    vcd = vcdcall();
                    if (vcd == null)
                    {
                        MessageBox.Show("Please make sure URL is proper with a / at last ");

                    }
                    else
                        txtvdc.Text = vcd.ToLower();
                }
                url = funrem();
                if (chklog.Checked)//Checks whether the logs option is enabled
                {
                    String log = @"--X:logFile="+filename+" --X:logLevel="+cmblog.Text+" ";
                    s =log+ " \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + txtvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + txtcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                    dis= log + " \"vcloud://<username>:<password>@" + url + "?vdc=" + txtvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + txtcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                }
                else
                {
                    s = " \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + txtvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + txtcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                    dis= " \"vcloud://<username>:<password>@" + url + "?vdc=" + txtvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + txtcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                    // "vcloud://p10v1-vcd.vchs.vmware.com/cloud/org/m211057782-9439/?vdc=m211057782&org=M211057782-9439&vappTemplate=test&catalog=SG_Catalog" "C:\gayatri\vswork
                }
                txtsynx.Text = dis;                
                txtres.Text = "Please Wait";                
                if (!backgroundWorker1.IsBusy)
                {
                    // This method will start the execution asynchronously in the background
                    backgroundWorker1.RunWorkerAsync();
                }               
            }
        }
        //Function used to match the VCD org id from the URL
        public String orgcall()
        {
            try
            {
                surl = txturl.Text.Trim();
                lurl = surl.Length;
                if (surl[lurl - 1] == '/')
                {
                    for (i = lurl - 2; i >= 0; i--)
                    {
                        if (surl[i] == '/')
                        {
                            break;
                        }
                        sorg = sorg + surl[i].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the proper URL refer the help button for more information");
                    return null;
                }

                input = sorg;
                for (k = input.Length - 1; k >= 0; k--)
                {
                    output += input[k];
                }
                return output;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                return null;
            }
        }
        //Function used to match the VDC id from the URL
        public String vcdcall()
        {
            try
            {
                output = txtorg.Text.Trim();
                if (output == null)
                {
                    return null;
                }
                for (j = 0; j < output.Length; j++)
                {
                    if (output[j] == '-')
                    {
                        break;
                    }
                    vcd = vcd + output[j];
                }
                return vcd;
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                return null;
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
            //main.dum2.upload10(n, res);
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
            String res, er;tex = "";            
            //OvfClass ovf = new OvfClass();
            res = compute(s,this);
            er = res.Substring(res.Length - 4, 4);//String matching done to catch the ExtraConfig option in the manifest file

            if (er == "Extr")
            {
                //MessageBox.Show("allow extra config");
                s = "--allowAllExtraConfig " + s;
                res = compute(s, this);
                tex = res;
            }
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

        private void VM_DowlVCD_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.AcceptButton = btnrun;
            }
        }

        private void VM_DowlVCD_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
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
        //Function used to remove https:// from the Destination URL
        public string funrem()
        {
            try
            {
                string test = txturl.Text.Trim();
                string result = test.Remove(0, 8);
                return result;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter the proper URL");
                return null;
            }            
        }

        private void txtui_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtui, "Please provide VCA username");
        }

        private void txtpwd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtpwd, "Please provide VCA password");
        }

        private void txturl_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txturl, "Please provide VCA URL");
        }

        private void btntrg_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btntrg,"Please select target folder to save file");
        }
        private void help_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(help, "Click for help");
        }
        private void help_Click(object sender, EventArgs e)
        {
            new Help_URL().Show();            
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