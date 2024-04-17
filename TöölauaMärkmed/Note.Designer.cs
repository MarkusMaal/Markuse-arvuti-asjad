namespace TöölauaMärkmed
{
    partial class Note
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.muudaTaustavärviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kollaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rohelineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pruunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uusMärgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kustutaSeeMärgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resizeTimer = new System.Windows.Forms.Timer(this.components);
            this.noteColor = new System.Windows.Forms.ColorDialog();
            this.noteFont = new System.Windows.Forms.FontDialog();
            this.firstTimer = new System.Windows.Forms.Timer(this.components);
            this.checkClose = new System.Windows.Forms.Timer(this.components);
            this.checkirunning = new System.Windows.Forms.Timer(this.components);
            this.noirunning = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Märkmik";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(192, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            this.label2.MouseLeave += new System.EventHandler(this.Label2_MouseLeave);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseMove);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "+";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            this.label3.MouseLeave += new System.EventHandler(this.Label3_MouseLeave);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseMove);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(5, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 161);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Honeydew;
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muudaTaustavärviToolStripMenuItem,
            this.uusMärgeToolStripMenuItem,
            this.kustutaSeeMärgeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.ShowItemToolTips = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 70);
            // 
            // muudaTaustavärviToolStripMenuItem
            // 
            this.muudaTaustavärviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kollaneToolStripMenuItem,
            this.punaneToolStripMenuItem,
            this.rohelineToolStripMenuItem,
            this.sinineToolStripMenuItem,
            this.valgeToolStripMenuItem,
            this.hallToolStripMenuItem,
            this.pruunToolStripMenuItem,
            this.lillaToolStripMenuItem});
            this.muudaTaustavärviToolStripMenuItem.Name = "muudaTaustavärviToolStripMenuItem";
            this.muudaTaustavärviToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.muudaTaustavärviToolStripMenuItem.Text = "Paberi värv";
            this.muudaTaustavärviToolStripMenuItem.Click += new System.EventHandler(this.MuudaTaustavärviToolStripMenuItem_Click);
            // 
            // kollaneToolStripMenuItem
            // 
            this.kollaneToolStripMenuItem.Checked = true;
            this.kollaneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kollaneToolStripMenuItem.Name = "kollaneToolStripMenuItem";
            this.kollaneToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.kollaneToolStripMenuItem.Text = "Kollane";
            this.kollaneToolStripMenuItem.Click += new System.EventHandler(this.KollaneToolStripMenuItem_Click);
            // 
            // punaneToolStripMenuItem
            // 
            this.punaneToolStripMenuItem.Name = "punaneToolStripMenuItem";
            this.punaneToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.punaneToolStripMenuItem.Text = "Punane";
            this.punaneToolStripMenuItem.Click += new System.EventHandler(this.PunaneToolStripMenuItem_Click);
            // 
            // rohelineToolStripMenuItem
            // 
            this.rohelineToolStripMenuItem.Name = "rohelineToolStripMenuItem";
            this.rohelineToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.rohelineToolStripMenuItem.Text = "Roheline";
            this.rohelineToolStripMenuItem.Click += new System.EventHandler(this.RohelineToolStripMenuItem_Click);
            // 
            // sinineToolStripMenuItem
            // 
            this.sinineToolStripMenuItem.Name = "sinineToolStripMenuItem";
            this.sinineToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.sinineToolStripMenuItem.Text = "Sinine";
            this.sinineToolStripMenuItem.Click += new System.EventHandler(this.SinineToolStripMenuItem_Click);
            // 
            // valgeToolStripMenuItem
            // 
            this.valgeToolStripMenuItem.Name = "valgeToolStripMenuItem";
            this.valgeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.valgeToolStripMenuItem.Text = "Valge";
            this.valgeToolStripMenuItem.Click += new System.EventHandler(this.ValgeToolStripMenuItem_Click);
            // 
            // hallToolStripMenuItem
            // 
            this.hallToolStripMenuItem.Name = "hallToolStripMenuItem";
            this.hallToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.hallToolStripMenuItem.Text = "Hall";
            this.hallToolStripMenuItem.Click += new System.EventHandler(this.HallToolStripMenuItem_Click);
            // 
            // pruunToolStripMenuItem
            // 
            this.pruunToolStripMenuItem.Name = "pruunToolStripMenuItem";
            this.pruunToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.pruunToolStripMenuItem.Text = "Pruun";
            this.pruunToolStripMenuItem.Click += new System.EventHandler(this.PruunToolStripMenuItem_Click);
            // 
            // lillaToolStripMenuItem
            // 
            this.lillaToolStripMenuItem.Name = "lillaToolStripMenuItem";
            this.lillaToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.lillaToolStripMenuItem.Text = "Lilla";
            this.lillaToolStripMenuItem.Click += new System.EventHandler(this.LillaToolStripMenuItem_Click);
            // 
            // uusMärgeToolStripMenuItem
            // 
            this.uusMärgeToolStripMenuItem.Name = "uusMärgeToolStripMenuItem";
            this.uusMärgeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.uusMärgeToolStripMenuItem.Text = "Uus märge";
            this.uusMärgeToolStripMenuItem.Click += new System.EventHandler(this.UusMärgeToolStripMenuItem_Click);
            // 
            // kustutaSeeMärgeToolStripMenuItem
            // 
            this.kustutaSeeMärgeToolStripMenuItem.Name = "kustutaSeeMärgeToolStripMenuItem";
            this.kustutaSeeMärgeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.kustutaSeeMärgeToolStripMenuItem.Text = "Kustuta see märge";
            this.kustutaSeeMärgeToolStripMenuItem.Click += new System.EventHandler(this.KustutaSeeMärgeToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBox1.Location = new System.Drawing.Point(210, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // resizeTimer
            // 
            this.resizeTimer.Interval = 10;
            this.resizeTimer.Tick += new System.EventHandler(this.ResizeTimer_Tick);
            // 
            // firstTimer
            // 
            this.firstTimer.Tick += new System.EventHandler(this.FirstTimer_Tick);
            // 
            // checkClose
            // 
            this.checkClose.Enabled = true;
            this.checkClose.Tick += new System.EventHandler(this.CheckClose_Tick);
            // 
            // checkirunning
            // 
            this.checkirunning.Enabled = true;
            this.checkirunning.Tick += new System.EventHandler(this.Checkirunning_Tick);
            // 
            // noirunning
            // 
            this.noirunning.Tick += new System.EventHandler(this.Noirunning_Tick);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(218, 205);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Note";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Note_FormClosing);
            this.Load += new System.EventHandler(this.Note_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer resizeTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem muudaTaustavärviToolStripMenuItem;
        private System.Windows.Forms.ColorDialog noteColor;
        private System.Windows.Forms.FontDialog noteFont;
        private System.Windows.Forms.ToolStripMenuItem kollaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rohelineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pruunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lillaToolStripMenuItem;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer firstTimer;
        private System.Windows.Forms.Timer checkClose;
        private System.Windows.Forms.ToolStripMenuItem uusMärgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kustutaSeeMärgeToolStripMenuItem;
        private System.Windows.Forms.Timer checkirunning;
        private System.Windows.Forms.Timer noirunning;
    }
}