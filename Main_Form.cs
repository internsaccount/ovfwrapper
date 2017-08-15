using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_OVFTOOL
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();            
        }
        //public dash_board dum2 = dash_board.getInstance();
        //private static Main_Form instance;
        //Function creates only one instance of the form
        //public static Main_Form getInstance()
        //{
        //    if (instance == null || instance.IsDisposed)
        //        instance = new Main_Form();
        //    else
        //        instance.BringToFront();
        //    return instance;
        //}
        //Checks if ovftool is installed properlly or not
        private void Main_Form_Load(object sender, EventArgs e)
        {
            OvfClass ovf = new OvfClass();
            String chk= ovf.compute("-h");            
            if(chk.Substring(chk.Length-4,4)=="erro")
            {
                menuStrip1.Enabled = false;
                MessageBox.Show("The software cannot find the OVF Tool\nPlease make sure if the OVF Tool is installed in the default location.");
            }            
        }
         
        private void conversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OVF_Conv f2 = new OVF_Conv();
            f2.Show();
        }
        private void vSphereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mig_Hosts f5 = new Mig_Hosts();
            f5.Show();
        }        
        private void downloadingFromVCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM_DowlVCD f8 = new VM_DowlVCD();
            f8.Show();
        }
        private void deploymentOfOVFOVAToEXSiHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dply_Esxi f10 = new Dply_Esxi();
            f10.Show();
        }          
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help f9 = new Help();
            f9.Show();
        }     
        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OVF_UpldVCD_ondem f14 = new OVF_UpldVCD_ondem();
            f14.Show();
        }

        private void subscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OVF_UpldVCD f13 = new OVF_UpldVCD();
            f13.Show();
        }

        private void onDemandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISO_UpldVCD_ondem f15 = new ISO_UpldVCD_ondem();
            f15.Show();
        }

        private void subscriptionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ISO_UpldVCD f11 = new ISO_UpldVCD();
            f11.Show();
        }

        private void vMFromOnDemandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM_DowlVCD_ondem f16 = new VM_DowlVCD_ondem();
            f16.Show();
        }
        private void vMFromSubscriptonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM_Dowld f6 = new VM_Dowld();
            f6.Show();
        }
        private void downloadfromvcenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VM_Dowld f6 =new VM_Dowld();
            f6.Show();
        }
        //private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    dum2.Show();
        //    dum2.BringToFront();
        //}
        private void supportRequestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.vmware.com/support/contacts/us_support.html");
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message);
            }
        }
        private void migrationToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            migrationToolStripMenuItem.ForeColor = Color.SteelBlue;
        }
        private void migrationToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            migrationToolStripMenuItem.ForeColor = Color.White;
        }
        private void helpToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.SteelBlue;
        }
        private void helpToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.White;
        }
        private void helpToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.SteelBlue;
        }
        private void helpToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.White;
        }
        private void conversionToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            conversionToolStripMenuItem.ForeColor = Color.SteelBlue;
        }
        private void conversionToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            conversionToolStripMenuItem.ForeColor = Color.White;
        }        
    }
}
