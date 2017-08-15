using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace GUI_OVFTOOL
{
    public partial class VM_DowlVCD_ondem : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex,s,dis;
        String url="";
        int j, i;
        public VM_DowlVCD_ondem()
        {
            InitializeComponent();
        }
        private static VM_DowlVCD_ondem instance;
        public static VM_DowlVCD_ondem getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new VM_DowlVCD_ondem();
            else
                instance.BringToFront();
            return instance;
        }
        private void btntrg_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txttrg.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
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
            else if (chklog.Checked && cmblog.Text == "")
            {
                MessageBox.Show("Please select the logging level");
            }
            else if (cmbcat.Text == "")
            {
                MessageBox.Show("Please select the Catalog name");
            }
            else if (cmbvdc.Text == "")
            {
                MessageBox.Show("Please select VDC name");
            }
            else
            {                
                url = funrem();
                if (chklog.Checked)
                {
                    String log = @"--X:logFile=C:\Users\Public\upload.log --X:logLevel="+cmblog.Text+" ";
                    s =log+ " \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                    dis= log + " \"vcloud://<username>:<password>@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                }
                else
                {
                    s = " \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
                    dis= " \"vcloud://<username>:<password>@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&vappTemplate=" + txtvapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\" \"" + txttrg.Text.Trim() + "\"";
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

        public void curlcall()
        {
            try
            {
                String cl, cl1, cl2, auth = "", auth_id, org, org_id, vdc, catlg, vdc_catlg;
                //string f = "https://au-south-1-15.vchs.vmware.com/api/compute";
                cl = "curl -i -k -H \"Accept:application/*+xml;version=6.0\" -u \"" + txtui.Text.Trim() + "@" + txtorg.Text.Trim() + ":" + txtpwd.Text.Trim() + "\" -X POST " + txturl.Text.Trim() + "/api/sessions";
                auth = curlApi(cl);
                if (auth.Substring(9, 6) != "200 OK")
                {
                    MessageBox.Show("Please check weather your user name,password,url or org id is correct");
                }
                //auth = File.ReadAllText(@"C:\Users\gayatrib\Desktop\exp\trial\auth.txt");
                int au_fn = auth.IndexOf("x-vcloud-authorization: ") + 24;
                int au_ln = 0;
                for (i = au_fn; i < au_fn + 50; i++)
                {
                    //char a = auth[i];
                    if (auth[i] == '\n')
                    {
                        au_ln = i - 1;
                        break;
                    }
                }
                auth_id = auth.Substring(au_fn, au_ln - au_fn);
                //auth_id = "6db408a8beff408090e82a7ec77bca29";

                cl1 = "curl -i -k -H \"Accept: application/*+xml;version=6.0\" -H \"x-vcloud-authorization: " + auth_id + "\" -X GET " + txturl.Text.Trim() + "/api/org";
                org = curlApi(cl1);
                //org= File.ReadAllText(@"C:\Users\gayatrib\Desktop\exp\trial\auth.txt");
                int or_fn, or_ln = 0;
                or_fn = org.IndexOf("<Org href=");
                org = org.Remove(0, or_fn);
                or_fn = org.IndexOf("org/") + 4;
                for (i = or_fn; i < or_fn + 50; i++)
                {
                    //char a = org[i];
                    if (org[i] == '"')
                    {
                        or_ln = i;
                        break;
                    }
                }
                org_id = org.Substring(or_fn, or_ln - or_fn);
                //org_id = "b4062166-c720-4833-95c8-f8a546945f44";

                cl2 = "curl -i -k -H \"Accept: application/*+xml;version=6.0\" -H \"x-vcloud-authorization: " + auth_id + "\" -X GET " + txturl.Text.Trim() + "/api/org/" + org_id + "";
                //org = File.ReadAllText(@"C:\Users\gayatrib\Desktop\exp\trial\auth.txt");
                vdc_catlg = curlApi(cl2);
                vdc = vdc_catlg;
                int vc_fn, vc_ln;
                vc_fn = vdc.IndexOf("<Link rel");
                vdc = vdc.Remove(0, vc_fn);
                vc_ln = vdc.IndexOf("tasksList/");
                vdc = vdc.Remove(vc_ln);
                int a = 0, b = 0, count;                
                count = vdc.Length - vdc.Replace("\n", string.Empty).Length;
                String[] arr = new String[count];
                for (i = 0; i < count; i++)
                {
                    a = vdc.IndexOf("name");
                    vdc = vdc.Insert(a + 1, "1");
                    for (j = a + 7; j < a + 50; j++)
                    {
                        //char c = vdc[j];
                        if (vdc[j] == '"')
                        {
                            b = j;
                            break;
                        }
                    }
                    arr[i] = vdc.Substring(a + 7, b - (a + 7));                    
                }                
                cmbvdc.Items.Clear();
                cmbvdc.Items.AddRange(arr);

                //catlg = File.ReadAllText(@"C:\Users\gayatrib\Desktop\exp\trial\auth.txt");
                int cat_fn, cat_ln;
                cmbcat.Items.Clear();
                catlg = vdc_catlg;
                cat_fn = catlg.IndexOf("tasksList/");
                catlg = catlg.Remove(0, cat_fn);
                cat_ln = catlg.IndexOf("network");
                catlg = catlg.Remove(cat_ln);
                a = 0; b = 0; count = 0;
                count = catlg.Length - catlg.Replace("\n", string.Empty).Length;
                for (i = 0; i < count; i++)
                {
                    a = catlg.IndexOf("name");
                    if (a != -1)
                    {
                        catlg = catlg.Insert(a + 1, "1");
                        for (j = a + 7; j < a + 50; j++)
                        {
                            char c = catlg[j];
                            if (catlg[j] == '"')
                            {
                                b = j;
                                break;
                            }
                        }
                        cmbcat.Items.Add(catlg.Substring(a + 7, b - (a + 7)));
                    }
                }
            }
            catch (Exception a)
            {
                if (a.Message == "The system cannot find the file specified")
                {
                    MessageBox.Show("Please make sure curl application is present in specified path");
                }
                else
                {
                    MessageBox.Show(a.Message);
                }
            }
        }

        public String curlApi(String cl)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files\curl-7.53.1\src\curl.exe";
            psi.Arguments = cl;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            var proc = Process.Start(psi);
            String auth = proc.StandardOutput.ReadToEnd();
            return auth;
        }
        
        public void progress(int n, String res)
        {
            tex = res;
            if (n <= 95)
            {
                backgroundWorker1.ReportProgress(n);
            }
            //main.dum2.upload9(n, res);
            //Thread.Sleep(5000);
            return;
        }
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
        public void funcall()
        {
            String res, er;tex = "";            
            //OvfClass ovf = new OvfClass();
            res = compute(s,this);
            er = res.Substring(res.Length - 4, 4);
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtui.Text == "")
            {
                MessageBox.Show("Please enter the username");
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Please enter the password");
            }            
            else if (chklog.Checked && cmblog.Text == "")
            {
                MessageBox.Show("Please select the logging level");
            }
            else if (txtorg.Text == "")
            {
                MessageBox.Show("Please Enter the org name");
            }
            else
            {
                UseWaitCursor = true;
                curlcall();
                label4.Enabled = true;
                label6.Enabled = true;
                cmbcat.Enabled = true;
                cmbvdc.Enabled = true;
                UseWaitCursor = false;
            }
        }

        private void chklog_CheckedChanged(object sender, EventArgs e)
        {
            if (chklog.Checked)
            {
                cmblog.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select the logging levels");
            }
        }
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
            new Help_URL_1().Show();            
        }

        private void btnlog_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = @"C:\Users\Public\upload.log";
                System.Diagnostics.Process.Start(filename);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }
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