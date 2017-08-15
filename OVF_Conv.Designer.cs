namespace GUI_OVFTOOL
{
    partial class OVF_Conv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OVF_Conv));
            this.btnsrc = new System.Windows.Forms.Button();
            this.btntrg = new System.Windows.Forms.Button();
            this.txtsrc = new System.Windows.Forms.TextBox();
            this.txttrg = new System.Windows.Forms.TextBox();
            this.btnrun = new System.Windows.Forms.Button();
            this.txtsynx = new System.Windows.Forms.TextBox();
            this.txtres = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbtrg = new System.Windows.Forms.ComboBox();
            this.txt_f_n1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chklog = new System.Windows.Forms.CheckBox();
            this.btnlog = new System.Windows.Forms.Button();
            this.cmblog = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsrc
            // 
            this.btnsrc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsrc.Location = new System.Drawing.Point(43, 10);
            this.btnsrc.Name = "btnsrc";
            this.btnsrc.Size = new System.Drawing.Size(141, 30);
            this.btnsrc.TabIndex = 0;
            this.btnsrc.Text = "Browse Source File";
            this.btnsrc.UseVisualStyleBackColor = true;
            this.btnsrc.Click += new System.EventHandler(this.btnsrc_Click);
            this.btnsrc.MouseHover += new System.EventHandler(this.btnsrc_MouseHover);
            // 
            // btntrg
            // 
            this.btntrg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntrg.Location = new System.Drawing.Point(43, 62);
            this.btntrg.Name = "btntrg";
            this.btntrg.Size = new System.Drawing.Size(141, 30);
            this.btntrg.TabIndex = 2;
            this.btntrg.Text = "Browse Target Folder";
            this.btntrg.UseVisualStyleBackColor = true;
            this.btntrg.Click += new System.EventHandler(this.btntrg_Click);
            this.btntrg.MouseHover += new System.EventHandler(this.btntrg_MouseHover);
            // 
            // txtsrc
            // 
            this.txtsrc.AllowDrop = true;
            this.txtsrc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsrc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtsrc.Location = new System.Drawing.Point(278, 15);
            this.txtsrc.Name = "txtsrc";
            this.txtsrc.Size = new System.Drawing.Size(523, 22);
            this.txtsrc.TabIndex = 1;
            this.txtsrc.Text = "Drag and drop source file";
            this.txtsrc.TextChanged += new System.EventHandler(this.txtsrc_TextChanged);
            this.txtsrc.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtsrc_DragDrop);
            this.txtsrc.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtsrc_DragEnter);
            // 
            // txttrg
            // 
            this.txttrg.Enabled = false;
            this.txttrg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txttrg.Location = new System.Drawing.Point(278, 67);
            this.txttrg.Name = "txttrg";
            this.txttrg.Size = new System.Drawing.Size(270, 22);
            this.txttrg.TabIndex = 0;
            this.txttrg.Text = "Target";
            // 
            // btnrun
            // 
            this.btnrun.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrun.Location = new System.Drawing.Point(48, 17);
            this.btnrun.Name = "btnrun";
            this.btnrun.Size = new System.Drawing.Size(141, 30);
            this.btnrun.TabIndex = 0;
            this.btnrun.Text = "Run ";
            this.btnrun.UseVisualStyleBackColor = true;
            this.btnrun.Click += new System.EventHandler(this.btnrun_Click);
            // 
            // txtsynx
            // 
            this.txtsynx.BackColor = System.Drawing.SystemColors.Window;
            this.txtsynx.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsynx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtsynx.Location = new System.Drawing.Point(283, 22);
            this.txtsynx.Name = "txtsynx";
            this.txtsynx.ReadOnly = true;
            this.txtsynx.Size = new System.Drawing.Size(523, 22);
            this.txtsynx.TabIndex = 1;
            this.txtsynx.Text = "Syntax";
            // 
            // txtres
            // 
            this.txtres.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtres.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtres.Location = new System.Drawing.Point(164, 375);
            this.txtres.Multiline = true;
            this.txtres.Name = "txtres";
            this.txtres.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtres.Size = new System.Drawing.Size(758, 315);
            this.txtres.TabIndex = 5;
            this.txtres.Text = "Output";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Source";
            this.openFileDialog1.Filter = "OVF Files (*.ovf)|*.ovf|OVA Files (*.ova)|*.ova|VMX Files (*.vmx)|*.vmx";
            // 
            // cmbtrg
            // 
            this.cmbtrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtrg.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbtrg.FormattingEnabled = true;
            this.cmbtrg.Items.AddRange(new object[] {
            "ova",
            "vmx"});
            this.cmbtrg.Location = new System.Drawing.Point(715, 67);
            this.cmbtrg.Name = "cmbtrg";
            this.cmbtrg.Size = new System.Drawing.Size(86, 23);
            this.cmbtrg.TabIndex = 4;
            this.cmbtrg.MouseHover += new System.EventHandler(this.cmbtrg_MouseHover);
            // 
            // txt_f_n1
            // 
            this.txt_f_n1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_f_n1.Location = new System.Drawing.Point(576, 67);
            this.txt_f_n1.Name = "txt_f_n1";
            this.txt_f_n1.Size = new System.Drawing.Size(108, 22);
            this.txt_f_n1.TabIndex = 3;
            this.txt_f_n1.Text = "Enter File Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(498, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = " Conversion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(554, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(690, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "*";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(257, 359);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(571, 10);
            this.progressBar1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(500, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Overall Progress";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // chklog
            // 
            this.chklog.AutoSize = true;
            this.chklog.BackColor = System.Drawing.Color.Transparent;
            this.chklog.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklog.ForeColor = System.Drawing.Color.Blue;
            this.chklog.Location = new System.Drawing.Point(177, 313);
            this.chklog.Name = "chklog";
            this.chklog.Size = new System.Drawing.Size(92, 19);
            this.chklog.TabIndex = 1;
            this.chklog.Text = "Enable Logs";
            this.chklog.UseVisualStyleBackColor = false;
            this.chklog.CheckedChanged += new System.EventHandler(this.chklog_CheckedChanged);
            // 
            // btnlog
            // 
            this.btnlog.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlog.Location = new System.Drawing.Point(794, 306);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(141, 30);
            this.btnlog.TabIndex = 3;
            this.btnlog.Text = "Export Diagnostic Logs";
            this.btnlog.UseVisualStyleBackColor = true;
            this.btnlog.Visible = false;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // cmblog
            // 
            this.cmblog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblog.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmblog.FormattingEnabled = true;
            this.cmblog.Items.AddRange(new object[] {
            "verbose",
            "trivia"});
            this.cmblog.Location = new System.Drawing.Point(412, 307);
            this.cmblog.Name = "cmblog";
            this.cmblog.Size = new System.Drawing.Size(194, 23);
            this.cmblog.TabIndex = 2;
            this.cmblog.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_f_n1);
            this.groupBox1.Controls.Add(this.cmbtrg);
            this.groupBox1.Controls.Add(this.txttrg);
            this.groupBox1.Controls.Add(this.txtsrc);
            this.groupBox1.Controls.Add(this.btntrg);
            this.groupBox1.Controls.Add(this.btnsrc);
            this.groupBox1.Location = new System.Drawing.Point(134, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtsynx);
            this.groupBox2.Controls.Add(this.btnrun);
            this.groupBox2.Location = new System.Drawing.Point(134, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // OVF_Conv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI_OVFTOOL.Properties.Resources.template;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 741);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmblog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnlog);
            this.Controls.Add(this.chklog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtres);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OVF_Conv";
            this.Text = "OVF - Migration Tool";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OVF_Conv_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsrc;
        private System.Windows.Forms.Button btntrg;
        private System.Windows.Forms.TextBox txtsrc;
        private System.Windows.Forms.TextBox txttrg;
        private System.Windows.Forms.Button btnrun;
        private System.Windows.Forms.TextBox txtsynx;
        private System.Windows.Forms.TextBox txtres;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cmbtrg;
        private System.Windows.Forms.TextBox txt_f_n1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chklog;
        private System.Windows.Forms.Button btnlog;
        private System.Windows.Forms.ComboBox cmblog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}