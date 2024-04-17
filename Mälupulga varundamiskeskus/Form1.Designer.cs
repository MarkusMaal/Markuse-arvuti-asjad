namespace Mälupulga_varundamiskeskus
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.whatConfig = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.whatMisc = new System.Windows.Forms.CheckBox();
            this.whatStuff = new System.Windows.Forms.CheckBox();
            this.whatBatch = new System.Windows.Forms.CheckBox();
            this.whatYUMI = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.howForeground = new System.Windows.Forms.RadioButton();
            this.howBackgroundNotify = new System.Windows.Forms.RadioButton();
            this.howBackground = new System.Windows.Forms.RadioButton();
            this.howLog = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.whereLocation = new System.Windows.Forms.TextBox();
            this.whereBrowse = new System.Windows.Forms.Button();
            this.whereEstimate = new System.Windows.Forms.Label();
            this.mainStart = new System.Windows.Forms.Button();
            this.mainClose = new System.Windows.Forms.Button();
            this.browseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Varundamisvalikud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mida soovite varundada?";
            // 
            // whatConfig
            // 
            this.whatConfig.AutoSize = true;
            this.whatConfig.Checked = true;
            this.whatConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whatConfig.Enabled = false;
            this.whatConfig.Location = new System.Drawing.Point(3, 3);
            this.whatConfig.Name = "whatConfig";
            this.whatConfig.Size = new System.Drawing.Size(224, 17);
            this.whatConfig.TabIndex = 2;
            this.whatConfig.Text = "Kontrollandmed ja konfiguratsioon (vajalik)";
            this.whatConfig.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.whatConfig);
            this.flowLayoutPanel1.Controls.Add(this.whatMisc);
            this.flowLayoutPanel1.Controls.Add(this.whatStuff);
            this.flowLayoutPanel1.Controls.Add(this.whatBatch);
            this.flowLayoutPanel1.Controls.Add(this.whatYUMI);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 128);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // whatMisc
            // 
            this.whatMisc.AutoSize = true;
            this.whatMisc.Checked = true;
            this.whatMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.whatMisc.Enabled = false;
            this.whatMisc.Location = new System.Drawing.Point(3, 26);
            this.whatMisc.Name = "whatMisc";
            this.whatMisc.Size = new System.Drawing.Size(166, 17);
            this.whatMisc.TabIndex = 3;
            this.whatMisc.Text = "Autorun ja muud failid (vajalik)";
            this.whatMisc.UseVisualStyleBackColor = true;
            // 
            // whatStuff
            // 
            this.whatStuff.AutoSize = true;
            this.whatStuff.Location = new System.Drawing.Point(3, 49);
            this.whatStuff.Name = "whatStuff";
            this.whatStuff.Size = new System.Drawing.Size(95, 17);
            this.whatStuff.TabIndex = 4;
            this.whatStuff.Text = "Markuse asjad";
            this.whatStuff.UseVisualStyleBackColor = true;
            this.whatStuff.CheckedChanged += new System.EventHandler(this.WhatStuff_CheckedChanged);
            // 
            // whatBatch
            // 
            this.whatBatch.AutoSize = true;
            this.whatBatch.Location = new System.Drawing.Point(3, 72);
            this.whatBatch.Name = "whatBatch";
            this.whatBatch.Size = new System.Drawing.Size(72, 17);
            this.whatBatch.TabIndex = 5;
            this.whatBatch.Text = "Pakkfailid";
            this.whatBatch.UseVisualStyleBackColor = true;
            this.whatBatch.CheckedChanged += new System.EventHandler(this.WhatBatch_CheckedChanged);
            // 
            // whatYUMI
            // 
            this.whatYUMI.AutoSize = true;
            this.whatYUMI.Location = new System.Drawing.Point(3, 95);
            this.whatYUMI.Name = "whatYUMI";
            this.whatYUMI.Size = new System.Drawing.Size(126, 17);
            this.whatYUMI.TabIndex = 6;
            this.whatYUMI.Text = "YUMI ja opsüsteemid";
            this.whatYUMI.UseVisualStyleBackColor = true;
            this.whatYUMI.CheckedChanged += new System.EventHandler(this.WhatYUMI_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kuidas soovite varundada?";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.howForeground);
            this.flowLayoutPanel2.Controls.Add(this.howBackgroundNotify);
            this.flowLayoutPanel2.Controls.Add(this.howBackground);
            this.flowLayoutPanel2.Controls.Add(this.howLog);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 26);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(258, 125);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // howForeground
            // 
            this.howForeground.AutoSize = true;
            this.howForeground.Checked = true;
            this.howForeground.Location = new System.Drawing.Point(3, 3);
            this.howForeground.Name = "howForeground";
            this.howForeground.Size = new System.Drawing.Size(117, 17);
            this.howForeground.TabIndex = 2;
            this.howForeground.TabStop = true;
            this.howForeground.Text = "Varunda esipaneelil";
            this.howForeground.UseVisualStyleBackColor = true;
            // 
            // howBackgroundNotify
            // 
            this.howBackgroundNotify.AutoSize = true;
            this.howBackgroundNotify.Location = new System.Drawing.Point(3, 26);
            this.howBackgroundNotify.Name = "howBackgroundNotify";
            this.howBackgroundNotify.Size = new System.Drawing.Size(251, 17);
            this.howBackgroundNotify.TabIndex = 0;
            this.howBackgroundNotify.Text = "Varunda taustal ja teavita kui protsess on valmis";
            this.howBackgroundNotify.UseVisualStyleBackColor = true;
            // 
            // howBackground
            // 
            this.howBackground.AutoSize = true;
            this.howBackground.Location = new System.Drawing.Point(3, 49);
            this.howBackground.Name = "howBackground";
            this.howBackground.Size = new System.Drawing.Size(178, 17);
            this.howBackground.TabIndex = 1;
            this.howBackground.Text = "Varunda taustal ilma teavitusteta";
            this.howBackground.UseVisualStyleBackColor = true;
            // 
            // howLog
            // 
            this.howLog.AutoSize = true;
            this.howLog.Location = new System.Drawing.Point(3, 72);
            this.howLog.Name = "howLog";
            this.howLog.Size = new System.Drawing.Size(86, 17);
            this.howLog.TabIndex = 3;
            this.howLog.Text = "Salvesta logi";
            this.howLog.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(265, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 151);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 151);
            this.panel2.TabIndex = 7;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel3.Controls.Add(this.panel2);
            this.flowLayoutPanel3.Controls.Add(this.panel1);
            this.flowLayoutPanel3.Controls.Add(this.panel3);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(15, 53);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(542, 319);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.flowLayoutPanel4);
            this.panel3.Location = new System.Drawing.Point(3, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 151);
            this.panel3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Kuhu soovite varundada?";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label5);
            this.flowLayoutPanel4.Controls.Add(this.panel4);
            this.flowLayoutPanel4.Controls.Add(this.whereEstimate);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(7, 23);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(518, 111);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kaust:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.whereLocation);
            this.panel4.Controls.Add(this.whereBrowse);
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 28);
            this.panel4.TabIndex = 9;
            // 
            // whereLocation
            // 
            this.whereLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whereLocation.Location = new System.Drawing.Point(3, 3);
            this.whereLocation.Name = "whereLocation";
            this.whereLocation.Size = new System.Drawing.Size(422, 20);
            this.whereLocation.TabIndex = 9;
            this.whereLocation.TextChanged += new System.EventHandler(this.WhereLocation_TextChanged);
            // 
            // whereBrowse
            // 
            this.whereBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whereBrowse.Location = new System.Drawing.Point(431, 1);
            this.whereBrowse.Name = "whereBrowse";
            this.whereBrowse.Size = new System.Drawing.Size(75, 23);
            this.whereBrowse.TabIndex = 9;
            this.whereBrowse.Text = "Sirvi";
            this.whereBrowse.UseVisualStyleBackColor = true;
            this.whereBrowse.Click += new System.EventHandler(this.WhereBrowse_Click);
            // 
            // whereEstimate
            // 
            this.whereEstimate.AutoSize = true;
            this.whereEstimate.Location = new System.Drawing.Point(3, 47);
            this.whereEstimate.Name = "whereEstimate";
            this.whereEstimate.Size = new System.Drawing.Size(146, 13);
            this.whereEstimate.TabIndex = 9;
            this.whereEstimate.Text = "Hinnanguline ajakulu: 1 minut";
            // 
            // mainStart
            // 
            this.mainStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainStart.Location = new System.Drawing.Point(483, 391);
            this.mainStart.Name = "mainStart";
            this.mainStart.Size = new System.Drawing.Size(75, 23);
            this.mainStart.TabIndex = 9;
            this.mainStart.Text = "Alusta";
            this.mainStart.UseVisualStyleBackColor = true;
            this.mainStart.Click += new System.EventHandler(this.MainStart_Click);
            // 
            // mainClose
            // 
            this.mainClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainClose.Location = new System.Drawing.Point(402, 391);
            this.mainClose.Name = "mainClose";
            this.mainClose.Size = new System.Drawing.Size(75, 23);
            this.mainClose.TabIndex = 10;
            this.mainClose.Text = "Sule";
            this.mainClose.UseVisualStyleBackColor = true;
            this.mainClose.Click += new System.EventHandler(this.Button3_Click);
            // 
            // browseDialog
            // 
            this.browseDialog.Description = "Vali kaust, kuhu soovid varundatud failid lisada";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 432);
            this.Controls.Add(this.mainClose);
            this.Controls.Add(this.mainStart);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(591, 471);
            this.Name = "Form1";
            this.Text = "Mälupulga varundamiskeskus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox whatConfig;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox whatMisc;
        private System.Windows.Forms.CheckBox whatStuff;
        private System.Windows.Forms.CheckBox whatBatch;
        private System.Windows.Forms.CheckBox whatYUMI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton howForeground;
        private System.Windows.Forms.RadioButton howBackgroundNotify;
        private System.Windows.Forms.RadioButton howBackground;
        private System.Windows.Forms.CheckBox howLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox whereLocation;
        private System.Windows.Forms.Button whereBrowse;
        private System.Windows.Forms.Label whereEstimate;
        private System.Windows.Forms.Button mainStart;
        private System.Windows.Forms.Button mainClose;
        private System.Windows.Forms.FolderBrowserDialog browseDialog;
    }
}

