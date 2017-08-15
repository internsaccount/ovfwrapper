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
    public delegate void progress_del(int n, string res);
    public partial class Help : Form
    {
        string tex = "",s = "", a = "";
        
        public Help()
        {
            InitializeComponent();
        }
        private static Help instance;
        //Function creates only one instance of the form
        public static Help getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Help();
            else
                instance.BringToFront();
            return instance;
        }
        private void btnrun_Click(object sender, EventArgs e)
        {
            s = "--help " + cmbopt.Text.Trim();
            txtsynx.Text = s;
            tex = "";
            txtres.Text = "";
            progressBar1.Value = 0;
            label3.Text = "0%";

            if (!backgroundWorker1.IsBusy)
            {
                // This method will start the execution asynchronously in the background
                backgroundWorker1.RunWorkerAsync();
            }
        }
        //BackgroundWorker class for executing a time-consuming operation asynchronously
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                a = compute(s, this);
                //backgroundWorker1.ReportProgress(i);
            }
        }
        //ProgressChanged event to report the progress of an asynchronous operation
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = e.ProgressPercentage.ToString() + "%";
            txtres.Text = tex;
        }
        //RunWorkerCompleted event to handle the result of an asynchronous operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtres.Text = a;
            progressBar1.Value = 100;
            label3.Text = "100%";
        }
        private void Help_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.AcceptButton = btnrun;
        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnrun;
        }
        //Function used to connect to the ovftool, pass arguments and get the output
        public String compute(String s, Object frm)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe";
            psi.Arguments = s;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            var proc = Process.Start(psi);
            tex = proc.StandardOutput.ReadToEnd();
            return tex;
        }       
    }
}
