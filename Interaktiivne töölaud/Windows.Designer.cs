namespace Interaktiivne_töölaud
{
    partial class Windows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Windows));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ListViewItem1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewItem2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Cpu1Image = new System.Windows.Forms.PictureBox();
            this.Cpu2Image = new System.Windows.Forms.PictureBox();
            this.Cpu4Image = new System.Windows.Forms.PictureBox();
            this.Cpu3Image = new System.Windows.Forms.PictureBox();
            this.Cpu6Image = new System.Windows.Forms.PictureBox();
            this.Cpu5Image = new System.Windows.Forms.PictureBox();
            this.RamImage = new System.Windows.Forms.PictureBox();
            this.HDDImage = new System.Windows.Forms.PictureBox();
            this.NetworkImage = new System.Windows.Forms.PictureBox();
            this.cpu1 = new System.Diagnostics.PerformanceCounter();
            this.cpu2 = new System.Diagnostics.PerformanceCounter();
            this.cpu3 = new System.Diagnostics.PerformanceCounter();
            this.cpu4 = new System.Diagnostics.PerformanceCounter();
            this.cpu5 = new System.Diagnostics.PerformanceCounter();
            this.cpu6 = new System.Diagnostics.PerformanceCounter();
            this.ramUsuage = new System.Diagnostics.PerformanceCounter();
            this.diskUsage = new System.Diagnostics.PerformanceCounter();
            this.PerformanceSet = new System.Windows.Forms.Timer(this.components);
            this.specialToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.desktopLevel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Cpu1Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu2Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu4Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu3Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu6Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu5Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDDImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramUsuage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diskUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.Color.AliceBlue;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListViewItem1,
            this.ListViewItem2,
            this.columnHeader1});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(370, 330);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(533, 335);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ListViewItem1
            // 
            this.ListViewItem1.Text = "Pealkiri";
            this.ListViewItem1.Width = 300;
            // 
            // ListViewItem2
            // 
            this.ListViewItem2.Text = "Olukord";
            this.ListViewItem2.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Protsess";
            this.columnHeader1.Width = 128;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(620, 948);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 46);
            this.button5.TabIndex = 8;
            this.button5.Text = "↓";
            this.InfoTip.SetToolTip(this.button5, "Tagasi eluruumi");
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(393, 671);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Sulge aken";
            this.InfoTip.SetToolTip(this.button1, "Annab programmile sulgemiskäskluse");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(506, 671);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "Peata protsess";
            this.InfoTip.SetToolTip(this.button2, "Peatab sunniviisiliselt programmi protsessi");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InfoTip
            // 
            this.InfoTip.AutomaticDelay = 0;
            this.InfoTip.AutoPopDelay = 10000;
            this.InfoTip.InitialDelay = 1;
            this.InfoTip.ReshowDelay = 1;
            this.InfoTip.UseAnimation = false;
            this.InfoTip.UseFading = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(752, 671);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "Tegumihaldur";
            this.InfoTip.SetToolTip(this.button4, "Käivitab Windowsi tegumihalduri");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 948);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(151, 30);
            this.button6.TabIndex = 13;
            this.button6.Text = "Lülita arvuti välja";
            this.InfoTip.SetToolTip(this.button6, "Salvestab seaded ja lülitab turvaliselt arvuti välja");
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(169, 948);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 30);
            this.button7.TabIndex = 14;
            this.button7.Text = "Taaskäivita";
            this.InfoTip.SetToolTip(this.button7, "Suleb arvuti ja käivitab selle uuesti");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(286, 948);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(161, 30);
            this.button8.TabIndex = 15;
            this.button8.Text = "Taasta vaikeliides";
            this.InfoTip.SetToolTip(this.button8, "Sulgeb Projekt I.T.S ja taasta tavaline Windowsi liides");
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.Black;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(1094, 948);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(174, 30);
            this.button9.TabIndex = 16;
            this.button9.Text = "Taaskäivita I.T.S.";
            this.InfoTip.SetToolTip(this.button9, "Tavakasutajatel: Taaskäivitab selle töölauahalduri\r\nKülaliskontol: Võimaldab välj" +
                    "a logida");
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.BackColor = System.Drawing.Color.Black;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(647, 671);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(99, 30);
            this.button10.TabIndex = 19;
            this.button10.Text = "Tegumid";
            this.InfoTip.SetToolTip(this.button10, "Kuvab minimeeritud või tagumised aknad");
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(453, 948);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 30);
            this.button3.TabIndex = 21;
            this.button3.Text = "Käivita";
            this.InfoTip.SetToolTip(this.button3, "Võimaldab käivitada programmi");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Lucida Console", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 20;
            this.InfoTip.SetToolTip(this.label2, "Kell");
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label2_MouseMove);
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button11.BackColor = System.Drawing.Color.Black;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(541, 948);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(140, 30);
            this.button11.TabIndex = 32;
            this.button11.Text = "Peida ruumid";
            this.InfoTip.SetToolTip(this.button11, "Peidab teisel kuvaril olevad ruumid ning jätab alles ainult selle akna,\r\nSee funk" +
                    "tsioon on saadaval kui on ühendatud vähemalt kaks kuvarit.");
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(747, 948);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "Värskenduskiirus";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ülikiire",
            "Kiire",
            "Keskmine",
            "Aeglane",
            "Väga aeglane"});
            this.comboBox1.Location = new System.Drawing.Point(920, 951);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 25);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Cpu1Image
            // 
            this.Cpu1Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu1Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu1Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu1;
            this.Cpu1Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu1Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu1Image.Location = new System.Drawing.Point(1228, 9);
            this.Cpu1Image.Name = "Cpu1Image";
            this.Cpu1Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu1Image.TabIndex = 22;
            this.Cpu1Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu1Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu1Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // Cpu2Image
            // 
            this.Cpu2Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu2Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu2Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu2;
            this.Cpu2Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu2Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu2Image.Location = new System.Drawing.Point(1228, 55);
            this.Cpu2Image.Name = "Cpu2Image";
            this.Cpu2Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu2Image.TabIndex = 23;
            this.Cpu2Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu2Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu2Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // Cpu4Image
            // 
            this.Cpu4Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu4Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu4Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu4;
            this.Cpu4Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu4Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu4Image.Location = new System.Drawing.Point(1228, 147);
            this.Cpu4Image.Name = "Cpu4Image";
            this.Cpu4Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu4Image.TabIndex = 25;
            this.Cpu4Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu4Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu4Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // Cpu3Image
            // 
            this.Cpu3Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu3Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu3Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu3;
            this.Cpu3Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu3Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu3Image.Location = new System.Drawing.Point(1228, 101);
            this.Cpu3Image.Name = "Cpu3Image";
            this.Cpu3Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu3Image.TabIndex = 24;
            this.Cpu3Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu3Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu3Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // Cpu6Image
            // 
            this.Cpu6Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu6Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu6Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu6;
            this.Cpu6Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu6Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu6Image.Location = new System.Drawing.Point(1228, 239);
            this.Cpu6Image.Name = "Cpu6Image";
            this.Cpu6Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu6Image.TabIndex = 27;
            this.Cpu6Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu6Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu6Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // Cpu5Image
            // 
            this.Cpu5Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cpu5Image.BackColor = System.Drawing.Color.Gray;
            this.Cpu5Image.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.cpu5;
            this.Cpu5Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cpu5Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cpu5Image.Location = new System.Drawing.Point(1228, 193);
            this.Cpu5Image.Name = "Cpu5Image";
            this.Cpu5Image.Size = new System.Drawing.Size(40, 40);
            this.Cpu5Image.TabIndex = 26;
            this.Cpu5Image.TabStop = false;
            this.specialToolTip.SetToolTip(this.Cpu5Image, "Näitab konkreetse protsessorituuma kasutust\r\nPunane - Tuum on täielikult hõivatud" +
                    "\r\nKollane - Tuum on osaliselt hõivatud\r\nRoheline - Tuum pole hõivatud");
            this.Cpu5Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Cpu1Image_MouseMove);
            // 
            // RamImage
            // 
            this.RamImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RamImage.BackColor = System.Drawing.Color.Gray;
            this.RamImage.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.ram;
            this.RamImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RamImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RamImage.Location = new System.Drawing.Point(1182, 9);
            this.RamImage.Name = "RamImage";
            this.RamImage.Size = new System.Drawing.Size(40, 40);
            this.RamImage.TabIndex = 28;
            this.RamImage.TabStop = false;
            this.specialToolTip.SetToolTip(this.RamImage, "Näitab muutmälu kasutust\r\nPunane - Mälukasutus on kõrge\r\nKollane - Mälukasutus on" +
                    " keskmine\r\nRoheline - Mälukasutus on madal");
            this.RamImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RamImage_MouseMove);
            // 
            // HDDImage
            // 
            this.HDDImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HDDImage.BackColor = System.Drawing.Color.Gray;
            this.HDDImage.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.hdd;
            this.HDDImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HDDImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HDDImage.Location = new System.Drawing.Point(1136, 9);
            this.HDDImage.Name = "HDDImage";
            this.HDDImage.Size = new System.Drawing.Size(40, 40);
            this.HDDImage.TabIndex = 29;
            this.HDDImage.TabStop = false;
            this.specialToolTip.SetToolTip(this.HDDImage, "Näitab C: ketta aktiivsust\r\nPunane - Kõrge aktiivsus\r\nKollane - Keskmine aktiivsu" +
                    "s\r\nRoheline - Madal aktiivsus/Aktiivsus puudub");
            this.HDDImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HDDImage_MouseMove);
            // 
            // NetworkImage
            // 
            this.NetworkImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NetworkImage.BackColor = System.Drawing.Color.Gray;
            this.NetworkImage.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.network;
            this.NetworkImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NetworkImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NetworkImage.Location = new System.Drawing.Point(1090, 9);
            this.NetworkImage.Name = "NetworkImage";
            this.NetworkImage.Size = new System.Drawing.Size(40, 40);
            this.NetworkImage.TabIndex = 30;
            this.NetworkImage.TabStop = false;
            this.specialToolTip.SetToolTip(this.NetworkImage, "Näitab, kas olemas on internetiühendus.\r\nPunane - Võrguühendus pole saadaval\r\nKol" +
                    "lane - Võrguühendus on saadaval, kuid juurdepääs internetile puudub\r\nRoheline - " +
                    "Võrguühendus on saadaval");
            this.NetworkImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NetworkImage_MouseMove);
            // 
            // cpu1
            // 
            this.cpu1.CategoryName = "Processor";
            this.cpu1.CounterName = "% Processor Time";
            this.cpu1.InstanceName = "0";
            // 
            // cpu2
            // 
            this.cpu2.CategoryName = "Processor";
            this.cpu2.CounterName = "% Processor Time";
            this.cpu2.InstanceName = "1";
            // 
            // cpu3
            // 
            this.cpu3.CategoryName = "Processor";
            this.cpu3.CounterName = "% Processor Time";
            this.cpu3.InstanceName = "2";
            // 
            // cpu4
            // 
            this.cpu4.CategoryName = "Processor";
            this.cpu4.CounterName = "% Processor Time";
            this.cpu4.InstanceName = "3";
            // 
            // cpu5
            // 
            this.cpu5.CategoryName = "Processor";
            this.cpu5.CounterName = "% Processor Time";
            this.cpu5.InstanceName = "4";
            // 
            // cpu6
            // 
            this.cpu6.CategoryName = "Processor";
            this.cpu6.CounterName = "% Processor Time";
            this.cpu6.InstanceName = "5";
            // 
            // ramUsuage
            // 
            this.ramUsuage.CategoryName = "Memory";
            this.ramUsuage.CounterName = "Available MBytes";
            // 
            // diskUsage
            // 
            this.diskUsage.CategoryName = "LogicalDisk";
            this.diskUsage.CounterName = "% Disk Time";
            this.diskUsage.InstanceName = "C:";
            // 
            // PerformanceSet
            // 
            this.PerformanceSet.Enabled = true;
            this.PerformanceSet.Interval = 1000;
            this.PerformanceSet.Tick += new System.EventHandler(this.PerformanceSet_Tick);
            // 
            // specialToolTip
            // 
            this.specialToolTip.AutomaticDelay = 0;
            this.specialToolTip.AutoPopDelay = 0;
            this.specialToolTip.InitialDelay = 0;
            this.specialToolTip.ReshowDelay = 100;
            this.specialToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.specialToolTip.ToolTipTitle = "Pealkiri";
            this.specialToolTip.UseAnimation = false;
            this.specialToolTip.UseFading = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 31;
            this.label3.Text = "Projekt I.T.S.";
            // 
            // desktopLevel
            // 
            this.desktopLevel.Enabled = true;
            this.desktopLevel.Interval = 1000;
            this.desktopLevel.Tick += new System.EventHandler(this.desktopLevel_Tick);
            // 
            // Windows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Interaktiivne_töölaud.Properties.Resources.aken;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 1005);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NetworkImage);
            this.Controls.Add(this.HDDImage);
            this.Controls.Add(this.RamImage);
            this.Controls.Add(this.Cpu6Image);
            this.Controls.Add(this.Cpu5Image);
            this.Controls.Add(this.Cpu4Image);
            this.Controls.Add(this.Cpu3Image);
            this.Controls.Add(this.Cpu2Image);
            this.Controls.Add(this.Cpu1Image);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Windows";
            this.ShowInTaskbar = false;
            this.Text = "Markuse arvuti töölaud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Windows_FormClosing);
            this.Load += new System.EventHandler(this.Windows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cpu1Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu2Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu4Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu3Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu6Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cpu5Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RamImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HDDImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramUsuage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diskUsage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ListViewItem1;
        private System.Windows.Forms.ColumnHeader ListViewItem2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button10;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox Cpu1Image;
        private System.Windows.Forms.PictureBox Cpu2Image;
        private System.Windows.Forms.PictureBox Cpu4Image;
        private System.Windows.Forms.PictureBox Cpu3Image;
        private System.Windows.Forms.PictureBox Cpu6Image;
        private System.Windows.Forms.PictureBox Cpu5Image;
        private System.Windows.Forms.PictureBox RamImage;
        private System.Windows.Forms.PictureBox HDDImage;
        private System.Windows.Forms.PictureBox NetworkImage;
        private System.Diagnostics.PerformanceCounter cpu1;
        private System.Diagnostics.PerformanceCounter cpu2;
        private System.Diagnostics.PerformanceCounter cpu3;
        private System.Diagnostics.PerformanceCounter cpu4;
        private System.Diagnostics.PerformanceCounter cpu5;
        private System.Diagnostics.PerformanceCounter cpu6;
        private System.Diagnostics.PerformanceCounter ramUsuage;
        private System.Diagnostics.PerformanceCounter diskUsage;
        private System.Windows.Forms.Timer PerformanceSet;
        private System.Windows.Forms.ToolTip specialToolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer desktopLevel;
        private System.Windows.Forms.Button button11;
    }
}