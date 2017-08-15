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
    public partial class ISO_UpldVCD_ondem : Form
    {
        //Main_Form main = Main_Form.getInstance();
        public String tex, s,dis,filename;// Variable s holds the value of the main command, tex holds the main output, fdn holds the ,dis holds the Syntax of the command
        String url = "";
        int j, i;//Variable lurl holds the length of the destination URL
        public ISO_UpldVCD_ondem()
        {
            InitializeComponent();
        }
        //private static ISO_UpldVCD_ondem instance;
        ////Function creates only one instance of the form
        //public static ISO_UpldVCD_ondem getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new ISO_UpldVCD_ondem();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        private void btnsrc_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtsrc.Text = openFileDialog1.FileName;
        }

        private void btnrun_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            label9.Text = "0%";
            btnlog.Visible = false;
            if (txtsrc.Text == "openFileDialog1" || txtsrc.Text == "")
            {
                MessageBox.Show("Please browse the source file");
            }
            else if (txtui.Text == "")
            {
                MessageBox.Show("Please enter the Username");
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Please enter the Password");
            }
            else if (txtdtn.Text == "")
            {
                MessageBox.Show("Please enter the URL");
            }            
            else if (txtapp.Text == "")
            {
                MessageBox.Show("Please enter the application name");
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
                if (chklog.Checked)//Checks whether the logs option is enabled
                {
                    String log = @"--X:logFile="+filename+" --X:logLevel=" + cmblog.Text + " ";
                    s = log + "--sourceType=\"ISO\" --vCloudTemplate=\"false\" \"" + txtsrc.Text.Trim() + "\" \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&media=" + txtapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\"";
                    dis = log + "--sourceType=\"ISO\" --vCloudTemplate=\"false\" \"" + txtsrc.Text.Trim() + "\" \"vcloud://<username>:<password>@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&media=" + txtapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\"";
                }
                else
                {
                    s = "--sourceType=\"ISO\" --vCloudTemplate=\"false\" \"" + txtsrc.Text.Trim() + "\" \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&media=" + txtapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\"";
                    dis = "--sourceType=\"ISO\" --vCloudTemplate=\"false\" \"" + txtsrc.Text.Trim() + "\" \"vcloud://<username>:<password>@" + url + "?vdc=" + cmbvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&media=" + txtapp.Text.Trim() + "&catalog=" + cmbcat.Text.Trim() + "\"";
                }
                //s = "--sourceType=\"ISO\" --vCloudTemplate=\"false\" \"" + txtsrc.Text.Trim() + "\" \"vcloud://" + txtui.Text.Trim() + ":" + txtpwd.Text.Trim() + "@" + txtdtn.Text.Trim() + "?vdc=" + txtvdc.Text.Trim() + "&org=" + txtorg.Text.Trim() + "&media=" + txtapp.Text.Trim() + "&catalog=" + txtcat.Text.Trim() + "\"";
                //--sourceType="ISO" --vCloudTemplate="false" "C:\Users\narasimhanp\Downloads\FreePBX-64bit-6.12.65.iso" "vcloud://uk-slough-1-6.vchs.vmware.com?vdc=Prashanth&org=74a4550b-87df-4cce-8849-a20d1b92db67&media=1234646&catalog=PRASHNATH_CATALOG"

                txtsynx.Text = dis;
                txtres.Text = "please wait";
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
                cl = "curl -i -k -H \"Accept:application/*+xml;version=6.0\" -u \"" + txtui.Text.Trim() + "@" + txtorg.Text.Trim() + ":" + txtpwd.Text.Trim() + "\" -X POST " + txtdtn.Text.Trim() + "/api/sessions";
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

                cl1 = "curl -i -k -H \"Accept: application/*+xml;version=6.0\" -H \"x-vcloud-authorization: " + auth_id + "\" -X GET " + txtdtn.Text.Trim() + "/api/org";
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

                cl2 = "curl -i -k -H \"Accept: application/*+xml;version=6.0\" -H \"x-vcloud-authorization: " + auth_id + "\" -X GET " + txtdtn.Text.Trim() + "/api/org/" + org_id + "";
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

        private void btn_vdc_cat_Click(object sender, EventArgs e)
        {            
            if (txtsrc.Text == "openFileDialog1" || txtsrc.Text == "")
            {
                MessageBox.Show("Browse the source file");
            }
            else if (txtui.Text == "")
            {
                MessageBox.Show("Please enter the username");
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Please enter the password");
            }
            else if (txtdtn.Text == "")
            {
                MessageBox.Show("Please enter the destination URL");
            }
            else if (txtapp.Text == "")
            {
                MessageBox.Show("Enter the application name");
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
                label3.Enabled = true;
                label6.Enabled = true;
                cmbcat.Enabled = true;
                cmbvdc.Enabled = true;
                UseWaitCursor = false;
            }
        }

        //Function calls the Compute
        public void funcall()
        {
            String res, er;
            //OvfClass ovf = new OvfClass();
            res =compute(s, this);
            er = res.Substring(res.Length - 4, 4);//String matching done to catch the ExtraConfig option in the manifest file
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
        //function checks the value of backgroundworker Reportprogress
        public void progress(int n, String res)
        {
            tex = res;
            if (n <= 95)
            {
                backgroundWorker1.ReportProgress(n);
            }
            //main.dum2.upload6(n, res);
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
        //Function used to remove https:// from the Destination URL	
        public string funrem()
        {
            try
            {
                String test = txtdtn.Text.Trim();
                String result = test.Remove(0, 8);
                return result;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter the proper URL");
                return null;
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
        //DrapDrop functionality implemented for source files
        private void txtsrc_DragDrop(object sender, DragEventArgs e)
        {
            Drag dr = new Drag();
            String msg = dr.drop(e);
            if (msg.Substring(msg.Length - 4, 4) == ".iso")
                txtsrc.Text = msg;
            else
                MessageBox.Show("Please drop only files with extension ISO");
        }

        private void ISO_UpldVCD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.AcceptButton = btnrun;
        }        

        private void ISO_UpldVCD_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
        }

        private void txtsrc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void btnsrc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnsrc, "Browse the source ISO file");
        }

        private void txtui_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtui, "Please provide VCA username");
        }

        private void txtpwd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtpwd, "Please provide VCA password ");
        }

        private void txtdtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtdtn, "Please enter proper destination URL");
        }

        private void txtcat_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmbcat, "Enter the Catalog ID");
        }

        private void help_Click(object sender, EventArgs e)
        {
            new Help_URL_1().Show();
            toolTip1.SetToolTip(help, "Click for help");
        }

        private void txtapp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtapp, "Enter the media name");
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
                for(int i=0;i<10;i++)
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
                for (int i = 0; i < 10; i++)
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
