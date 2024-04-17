namespace Pidu
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.remainMonths = new System.Windows.Forms.Panel();
            this.monthLabel = new System.Windows.Forms.Label();
            this.months = new System.Windows.Forms.Label();
            this.remainDays = new System.Windows.Forms.Panel();
            this.dayLabel = new System.Windows.Forms.Label();
            this.days = new System.Windows.Forms.Label();
            this.remainHours = new System.Windows.Forms.Panel();
            this.hourLabel = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.Label();
            this.remainMinutes = new System.Windows.Forms.Panel();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.minutes = new System.Windows.Forms.Label();
            this.remainSeconds = new System.Windows.Forms.Panel();
            this.secondLabel = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.Label();
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.remainMonths.SuspendLayout();
            this.remainDays.SuspendLayout();
            this.remainHours.SuspendLayout();
            this.remainMinutes.SuspendLayout();
            this.remainSeconds.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hetkel ei mängi ühtegi pala";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(423, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "0:00/0:00 | 100% | 19.06.2001 00:00:00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(23, 561);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kiirklahvide nägemiseks vajutage F1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(24, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(394, 106);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lisanduvad metaandmed puuduvad";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(232, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(353, 23);
            this.label5.TabIndex = 4;
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.remainMonths);
            this.flowLayoutPanel1.Controls.Add(this.remainDays);
            this.flowLayoutPanel1.Controls.Add(this.remainHours);
            this.flowLayoutPanel1.Controls.Add(this.remainMinutes);
            this.flowLayoutPanel1.Controls.Add(this.remainSeconds);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(215, 279);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(405, 75);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // remainMonths
            // 
            this.remainMonths.Controls.Add(this.monthLabel);
            this.remainMonths.Controls.Add(this.months);
            this.remainMonths.Location = new System.Drawing.Point(3, 3);
            this.remainMonths.Name = "remainMonths";
            this.remainMonths.Size = new System.Drawing.Size(73, 72);
            this.remainMonths.TabIndex = 0;
            // 
            // monthLabel
            // 
            this.monthLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.monthLabel.Location = new System.Drawing.Point(-3, 51);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(76, 23);
            this.monthLabel.TabIndex = 0;
            this.monthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // months
            // 
            this.months.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.months.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.months.Location = new System.Drawing.Point(3, 0);
            this.months.Name = "months";
            this.months.Size = new System.Drawing.Size(67, 59);
            this.months.TabIndex = 1;
            this.months.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainDays
            // 
            this.remainDays.Controls.Add(this.dayLabel);
            this.remainDays.Controls.Add(this.days);
            this.remainDays.Location = new System.Drawing.Point(82, 3);
            this.remainDays.Name = "remainDays";
            this.remainDays.Size = new System.Drawing.Size(73, 72);
            this.remainDays.TabIndex = 1;
            // 
            // dayLabel
            // 
            this.dayLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dayLabel.Location = new System.Drawing.Point(0, 51);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(73, 21);
            this.dayLabel.TabIndex = 0;
            this.dayLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // days
            // 
            this.days.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.days.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.days.Location = new System.Drawing.Point(3, 0);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(67, 59);
            this.days.TabIndex = 1;
            this.days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainHours
            // 
            this.remainHours.Controls.Add(this.hourLabel);
            this.remainHours.Controls.Add(this.hours);
            this.remainHours.Location = new System.Drawing.Point(161, 3);
            this.remainHours.Name = "remainHours";
            this.remainHours.Size = new System.Drawing.Size(73, 72);
            this.remainHours.TabIndex = 2;
            // 
            // hourLabel
            // 
            this.hourLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.hourLabel.Location = new System.Drawing.Point(0, 51);
            this.hourLabel.Name = "hourLabel";
            this.hourLabel.Size = new System.Drawing.Size(73, 21);
            this.hourLabel.TabIndex = 0;
            this.hourLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // hours
            // 
            this.hours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hours.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.hours.Location = new System.Drawing.Point(3, 0);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(67, 59);
            this.hours.TabIndex = 1;
            this.hours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainMinutes
            // 
            this.remainMinutes.Controls.Add(this.minuteLabel);
            this.remainMinutes.Controls.Add(this.minutes);
            this.remainMinutes.Location = new System.Drawing.Point(240, 3);
            this.remainMinutes.Name = "remainMinutes";
            this.remainMinutes.Size = new System.Drawing.Size(73, 72);
            this.remainMinutes.TabIndex = 3;
            // 
            // minuteLabel
            // 
            this.minuteLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.minuteLabel.Location = new System.Drawing.Point(0, 51);
            this.minuteLabel.Name = "minuteLabel";
            this.minuteLabel.Size = new System.Drawing.Size(73, 21);
            this.minuteLabel.TabIndex = 0;
            this.minuteLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // minutes
            // 
            this.minutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minutes.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.minutes.Location = new System.Drawing.Point(3, 0);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(67, 59);
            this.minutes.TabIndex = 1;
            this.minutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainSeconds
            // 
            this.remainSeconds.Controls.Add(this.secondLabel);
            this.remainSeconds.Controls.Add(this.seconds);
            this.remainSeconds.Location = new System.Drawing.Point(319, 3);
            this.remainSeconds.Name = "remainSeconds";
            this.remainSeconds.Size = new System.Drawing.Size(73, 72);
            this.remainSeconds.TabIndex = 4;
            // 
            // secondLabel
            // 
            this.secondLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.secondLabel.Location = new System.Drawing.Point(3, 51);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(70, 23);
            this.secondLabel.TabIndex = 0;
            this.secondLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // seconds
            // 
            this.seconds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seconds.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.seconds.Location = new System.Drawing.Point(3, 0);
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(67, 59);
            this.seconds.TabIndex = 1;
            this.seconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CountdownTimer
            // 
            this.CountdownTimer.Enabled = true;
            this.CountdownTimer.Interval = 1000;
            this.CountdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(803, 614);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.remainMonths.ResumeLayout(false);
            this.remainDays.ResumeLayout(false);
            this.remainHours.ResumeLayout(false);
            this.remainMinutes.ResumeLayout(false);
            this.remainSeconds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel remainMonths;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label months;
        private System.Windows.Forms.Panel remainDays;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label days;
        private System.Windows.Forms.Panel remainHours;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.Label hours;
        private System.Windows.Forms.Panel remainMinutes;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label minutes;
        private System.Windows.Forms.Panel remainSeconds;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label seconds;
        private System.Windows.Forms.Timer CountdownTimer;
    }
}

