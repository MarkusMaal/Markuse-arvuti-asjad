
namespace StreamSystem
{
    partial class Previews
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screenDisp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.osdDisp = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.combinedVideo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.screenDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osdDisp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinedVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // screenDisp
            // 
            this.screenDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screenDisp.Location = new System.Drawing.Point(12, 12);
            this.screenDisp.Name = "screenDisp";
            this.screenDisp.Size = new System.Drawing.Size(294, 167);
            this.screenDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.screenDisp.TabIndex = 0;
            this.screenDisp.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Screen";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "OSD";
            // 
            // osdDisp
            // 
            this.osdDisp.BackColor = System.Drawing.Color.Magenta;
            this.osdDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.osdDisp.Location = new System.Drawing.Point(12, 237);
            this.osdDisp.Name = "osdDisp";
            this.osdDisp.Size = new System.Drawing.Size(294, 167);
            this.osdDisp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.osdDisp.TabIndex = 2;
            this.osdDisp.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // combinedVideo
            // 
            this.combinedVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combinedVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.combinedVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.combinedVideo.Location = new System.Drawing.Point(312, 12);
            this.combinedVideo.Name = "combinedVideo";
            this.combinedVideo.Size = new System.Drawing.Size(439, 425);
            this.combinedVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.combinedVideo.TabIndex = 4;
            this.combinedVideo.TabStop = false;
            // 
            // Previews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(763, 457);
            this.Controls.Add(this.combinedVideo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.osdDisp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screenDisp);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Previews";
            this.Text = "Previews";
            this.Load += new System.EventHandler(this.Previews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.screenDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osdDisp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combinedVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox screenDisp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox osdDisp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox combinedVideo;
    }
}

