namespace GUI_OVFTOOL
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToCatalogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oVFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iSOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.onDemandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vMFromOnDemandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vMFromSubscriptonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.migrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSphereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadfromvcenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.migrationToolStripMenuItem,
            this.conversionToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToCatalogToolStripMenuItem1,
            this.downloadToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(160, 20);
            this.helpToolStripMenuItem.Text = "vCloud Director Migration";
            this.helpToolStripMenuItem.DropDownClosed += new System.EventHandler(this.helpToolStripMenuItem_DropDownClosed);
            this.helpToolStripMenuItem.DropDownOpening += new System.EventHandler(this.helpToolStripMenuItem_DropDownOpening);
            // 
            // uploadToCatalogToolStripMenuItem1
            // 
            this.uploadToCatalogToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oVFToolStripMenuItem,
            this.iSOToolStripMenuItem1});
            this.uploadToCatalogToolStripMenuItem1.Name = "uploadToCatalogToolStripMenuItem1";
            this.uploadToCatalogToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.uploadToCatalogToolStripMenuItem1.Text = "Catalog Upload";
            // 
            // oVFToolStripMenuItem
            // 
            this.oVFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oNToolStripMenuItem,
            this.subscriptionToolStripMenuItem});
            this.oVFToolStripMenuItem.Name = "oVFToolStripMenuItem";
            this.oVFToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.oVFToolStripMenuItem.Text = "OVF";
            // 
            // oNToolStripMenuItem
            // 
            this.oNToolStripMenuItem.Name = "oNToolStripMenuItem";
            this.oNToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.oNToolStripMenuItem.Text = "On Demand";
            this.oNToolStripMenuItem.Click += new System.EventHandler(this.oNToolStripMenuItem_Click);
            // 
            // subscriptionToolStripMenuItem
            // 
            this.subscriptionToolStripMenuItem.Name = "subscriptionToolStripMenuItem";
            this.subscriptionToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.subscriptionToolStripMenuItem.Text = "Subscription";
            this.subscriptionToolStripMenuItem.Click += new System.EventHandler(this.subscriptionToolStripMenuItem_Click);
            // 
            // iSOToolStripMenuItem1
            // 
            this.iSOToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onDemandToolStripMenuItem,
            this.subscriptionToolStripMenuItem1});
            this.iSOToolStripMenuItem1.Name = "iSOToolStripMenuItem1";
            this.iSOToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.iSOToolStripMenuItem1.Text = "ISO";
            // 
            // onDemandToolStripMenuItem
            // 
            this.onDemandToolStripMenuItem.Name = "onDemandToolStripMenuItem";
            this.onDemandToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.onDemandToolStripMenuItem.Text = "On Demand";
            this.onDemandToolStripMenuItem.Click += new System.EventHandler(this.onDemandToolStripMenuItem_Click);
            // 
            // subscriptionToolStripMenuItem1
            // 
            this.subscriptionToolStripMenuItem1.Name = "subscriptionToolStripMenuItem1";
            this.subscriptionToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.subscriptionToolStripMenuItem1.Text = "Subscription";
            this.subscriptionToolStripMenuItem1.Click += new System.EventHandler(this.subscriptionToolStripMenuItem1_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vMFromOnDemandToolStripMenuItem,
            this.vMFromSubscriptonToolStripMenuItem});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // vMFromOnDemandToolStripMenuItem
            // 
            this.vMFromOnDemandToolStripMenuItem.Name = "vMFromOnDemandToolStripMenuItem";
            this.vMFromOnDemandToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.vMFromOnDemandToolStripMenuItem.Text = "VM from On Demand";
            this.vMFromOnDemandToolStripMenuItem.Click += new System.EventHandler(this.vMFromOnDemandToolStripMenuItem_Click);
            // 
            // vMFromSubscriptonToolStripMenuItem
            // 
            this.vMFromSubscriptonToolStripMenuItem.Name = "vMFromSubscriptonToolStripMenuItem";
            this.vMFromSubscriptonToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.vMFromSubscriptonToolStripMenuItem.Text = "VM from Subscripton";
            this.vMFromSubscriptonToolStripMenuItem.Click += new System.EventHandler(this.vMFromSubscriptonToolStripMenuItem_Click);
            // 
            // migrationToolStripMenuItem
            // 
            this.migrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vSphereToolStripMenuItem,
            this.downloadfromvcenterToolStripMenuItem,
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem});
            this.migrationToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.migrationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.migrationToolStripMenuItem.Name = "migrationToolStripMenuItem";
            this.migrationToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.migrationToolStripMenuItem.Text = "vSphere Migration";
            this.migrationToolStripMenuItem.DropDownClosed += new System.EventHandler(this.migrationToolStripMenuItem_DropDownClosed);
            this.migrationToolStripMenuItem.DropDownOpening += new System.EventHandler(this.migrationToolStripMenuItem_DropDownOpening);
            // 
            // vSphereToolStripMenuItem
            // 
            this.vSphereToolStripMenuItem.Name = "vSphereToolStripMenuItem";
            this.vSphereToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.vSphereToolStripMenuItem.Text = "Between Hosts";
            this.vSphereToolStripMenuItem.Click += new System.EventHandler(this.vSphereToolStripMenuItem_Click);
            // 
            // downloadfromvcenterToolStripMenuItem
            // 
            this.downloadfromvcenterToolStripMenuItem.Name = "downloadfromvcenterToolStripMenuItem";
            this.downloadfromvcenterToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.downloadfromvcenterToolStripMenuItem.Text = "Download from VCenter";
            this.downloadfromvcenterToolStripMenuItem.Click += new System.EventHandler(this.downloadfromvcenterToolStripMenuItem_Click);
            // 
            // deploymentOfOVFOVAToEXSiHostToolStripMenuItem
            // 
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem.Name = "deploymentOfOVFOVAToEXSiHostToolStripMenuItem";
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem.Text = "Deployment [OVF/OVA] - ESXi Host";
            this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem.Click += new System.EventHandler(this.deploymentOfOVFOVAToEXSiHostToolStripMenuItem_Click);
            // 
            // conversionToolStripMenuItem
            // 
            this.conversionToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversionToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.conversionToolStripMenuItem.Name = "conversionToolStripMenuItem";
            this.conversionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.conversionToolStripMenuItem.Text = "Conversion";
            this.conversionToolStripMenuItem.Click += new System.EventHandler(this.conversionToolStripMenuItem_Click);
            this.conversionToolStripMenuItem.MouseLeave += new System.EventHandler(this.conversionToolStripMenuItem_MouseLeave);
            this.conversionToolStripMenuItem.MouseHover += new System.EventHandler(this.conversionToolStripMenuItem_MouseHover);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            this.helpToolStripMenuItem1.MouseLeave += new System.EventHandler(this.helpToolStripMenuItem1_MouseLeave);
            this.helpToolStripMenuItem1.MouseHover += new System.EventHandler(this.helpToolStripMenuItem1_MouseHover);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI_OVFTOOL.Properties.Resources.front_page;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 733);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_Form";
            this.Text = " OVF - MIGRATION TOOL";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conversionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem migrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vSphereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadfromvcenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deploymentOfOVFOVAToEXSiHostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToCatalogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem oVFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iSOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem onDemandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vMFromOnDemandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vMFromSubscriptonToolStripMenuItem;
    }
}

