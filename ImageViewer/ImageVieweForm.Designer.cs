namespace ImageViewer
{
    partial class ImageVieweForm
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
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.pictureBoxDetail = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btAddTag = new System.Windows.Forms.Button();
            this.btDeleteTag = new System.Windows.Forms.Button();
            this.btUpdateTag = new System.Windows.Forms.Button();
            this.btQueryByTag = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btClearAll = new System.Windows.Forms.Button();
            this.cbImageOnly = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.rb3x4 = new System.Windows.Forms.RadioButton();
            this.rb2x4 = new System.Windows.Forms.RadioButton();
            this.rb1x4 = new System.Windows.Forms.RadioButton();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.rb3x3 = new System.Windows.Forms.RadioButton();
            this.rb3x2 = new System.Windows.Forms.RadioButton();
            this.rb3x1 = new System.Windows.Forms.RadioButton();
            this.rb2x3 = new System.Windows.Forms.RadioButton();
            this.rb2x2 = new System.Windows.Forms.RadioButton();
            this.rb2x1 = new System.Windows.Forms.RadioButton();
            this.rb1x3 = new System.Windows.Forms.RadioButton();
            this.rb1x2 = new System.Windows.Forms.RadioButton();
            this.rb1x1 = new System.Windows.Forms.RadioButton();
            this.lbSelectedFile = new System.Windows.Forms.ListBox();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbOrderByExt = new System.Windows.Forms.RadioButton();
            this.rbOrderBySize = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbOrderByTime = new System.Windows.Forms.RadioButton();
            this.rbOrderByName = new System.Windows.Forms.RadioButton();
            this.btExport = new System.Windows.Forms.Button();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.trackBarProgress = new System.Windows.Forms.TrackBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btLastPage = new System.Windows.Forms.Button();
            this.btNextPage = new System.Windows.Forms.Button();
            this.btPrevPage = new System.Windows.Forms.Button();
            this.btFirstPage = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbTagList = new System.Windows.Forms.CheckedListBox();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "显示：";
            // 
            // gbImage
            // 
            this.gbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbImage.Controls.Add(this.pictureBoxDetail);
            this.gbImage.Controls.Add(this.pictureBox10);
            this.gbImage.Controls.Add(this.pictureBox11);
            this.gbImage.Controls.Add(this.pictureBox12);
            this.gbImage.Controls.Add(this.pictureBox9);
            this.gbImage.Controls.Add(this.pictureBox8);
            this.gbImage.Controls.Add(this.pictureBox7);
            this.gbImage.Controls.Add(this.pictureBox6);
            this.gbImage.Controls.Add(this.pictureBox5);
            this.gbImage.Controls.Add(this.pictureBox4);
            this.gbImage.Controls.Add(this.pictureBox3);
            this.gbImage.Controls.Add(this.pictureBox2);
            this.gbImage.Controls.Add(this.pictureBox1);
            this.gbImage.Location = new System.Drawing.Point(7, 1);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(930, 699);
            this.gbImage.TabIndex = 1;
            this.gbImage.TabStop = false;
            // 
            // pictureBoxDetail
            // 
            this.pictureBoxDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDetail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDetail.Location = new System.Drawing.Point(561, 641);
            this.pictureBoxDetail.Name = "pictureBoxDetail";
            this.pictureBoxDetail.Size = new System.Drawing.Size(178, 38);
            this.pictureBoxDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDetail.TabIndex = 12;
            this.pictureBoxDetail.TabStop = false;
            this.pictureBoxDetail.Visible = false;
            this.pictureBoxDetail.Click += new System.EventHandler(this.pictureBoxDetail_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox10.Location = new System.Drawing.Point(714, 462);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(178, 165);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 11;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Visible = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox11.Location = new System.Drawing.Point(714, 254);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(178, 165);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 10;
            this.pictureBox11.TabStop = false;
            this.pictureBox11.Visible = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox12.Location = new System.Drawing.Point(714, 43);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(178, 165);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 9;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Visible = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox9.Location = new System.Drawing.Point(493, 462);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(178, 165);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.Location = new System.Drawing.Point(267, 462);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(178, 165);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Location = new System.Drawing.Point(35, 462);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(178, 165);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox6.Location = new System.Drawing.Point(493, 254);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(178, 165);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox5.Location = new System.Drawing.Point(267, 254);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(178, 165);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(35, 254);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(178, 165);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(493, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(178, 165);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(267, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(178, 165);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(35, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // gbControl
            // 
            this.gbControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControl.Controls.Add(this.lbTagList);
            this.gbControl.Controls.Add(this.btAddTag);
            this.gbControl.Controls.Add(this.btDeleteTag);
            this.gbControl.Controls.Add(this.btUpdateTag);
            this.gbControl.Controls.Add(this.btQueryByTag);
            this.gbControl.Controls.Add(this.label2);
            this.gbControl.Controls.Add(this.btClearAll);
            this.gbControl.Controls.Add(this.cbImageOnly);
            this.gbControl.Controls.Add(this.label5);
            this.gbControl.Controls.Add(this.cbIncludeSubDir);
            this.gbControl.Controls.Add(this.rb3x4);
            this.gbControl.Controls.Add(this.rb2x4);
            this.gbControl.Controls.Add(this.rb1x4);
            this.gbControl.Controls.Add(this.lblSelectedCount);
            this.gbControl.Controls.Add(this.rb3x3);
            this.gbControl.Controls.Add(this.rb3x2);
            this.gbControl.Controls.Add(this.rb3x1);
            this.gbControl.Controls.Add(this.rb2x3);
            this.gbControl.Controls.Add(this.rb2x2);
            this.gbControl.Controls.Add(this.rb2x1);
            this.gbControl.Controls.Add(this.rb1x3);
            this.gbControl.Controls.Add(this.rb1x2);
            this.gbControl.Controls.Add(this.rb1x1);
            this.gbControl.Controls.Add(this.lbSelectedFile);
            this.gbControl.Controls.Add(this.tbDir);
            this.gbControl.Controls.Add(this.btBrowse);
            this.gbControl.Controls.Add(this.label3);
            this.gbControl.Controls.Add(this.label1);
            this.gbControl.Controls.Add(this.panel1);
            this.gbControl.Location = new System.Drawing.Point(983, 1);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(306, 767);
            this.gbControl.TabIndex = 5;
            this.gbControl.TabStop = false;
            this.gbControl.Enter += new System.EventHandler(this.gbControl_Enter);
            // 
            // btAddTag
            // 
            this.btAddTag.Location = new System.Drawing.Point(55, 183);
            this.btAddTag.Name = "btAddTag";
            this.btAddTag.Size = new System.Drawing.Size(52, 25);
            this.btAddTag.TabIndex = 33;
            this.btAddTag.Text = "增加";
            this.btAddTag.UseVisualStyleBackColor = true;
            this.btAddTag.Click += new System.EventHandler(this.btAddTag_Click);
            // 
            // btDeleteTag
            // 
            this.btDeleteTag.Enabled = false;
            this.btDeleteTag.Location = new System.Drawing.Point(113, 183);
            this.btDeleteTag.Name = "btDeleteTag";
            this.btDeleteTag.Size = new System.Drawing.Size(52, 25);
            this.btDeleteTag.TabIndex = 32;
            this.btDeleteTag.Text = "删除";
            this.btDeleteTag.UseVisualStyleBackColor = true;
            this.btDeleteTag.Click += new System.EventHandler(this.btDeleteTag_Click);
            // 
            // btUpdateTag
            // 
            this.btUpdateTag.Enabled = false;
            this.btUpdateTag.Location = new System.Drawing.Point(176, 183);
            this.btUpdateTag.Name = "btUpdateTag";
            this.btUpdateTag.Size = new System.Drawing.Size(52, 25);
            this.btUpdateTag.TabIndex = 31;
            this.btUpdateTag.Text = "修改";
            this.btUpdateTag.UseVisualStyleBackColor = true;
            this.btUpdateTag.Click += new System.EventHandler(this.btUpdateTag_Click);
            // 
            // btQueryByTag
            // 
            this.btQueryByTag.Location = new System.Drawing.Point(242, 183);
            this.btQueryByTag.Name = "btQueryByTag";
            this.btQueryByTag.Size = new System.Drawing.Size(52, 25);
            this.btQueryByTag.TabIndex = 30;
            this.btQueryByTag.Text = "查询";
            this.btQueryByTag.UseVisualStyleBackColor = true;
            this.btQueryByTag.Click += new System.EventHandler(this.btQueryByTag_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "标签：";
            // 
            // btClearAll
            // 
            this.btClearAll.Enabled = false;
            this.btClearAll.Location = new System.Drawing.Point(210, 521);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(84, 25);
            this.btClearAll.TabIndex = 28;
            this.btClearAll.Text = "全部清除";
            this.btClearAll.UseVisualStyleBackColor = true;
            this.btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // cbImageOnly
            // 
            this.cbImageOnly.AutoSize = true;
            this.cbImageOnly.Location = new System.Drawing.Point(176, 53);
            this.cbImageOnly.Name = "cbImageOnly";
            this.cbImageOnly.Size = new System.Drawing.Size(86, 17);
            this.cbImageOnly.TabIndex = 27;
            this.cbImageOnly.Text = "仅显示图像";
            this.cbImageOnly.UseVisualStyleBackColor = true;
            this.cbImageOnly.CheckedChanged += new System.EventHandler(this.cbImageOnly_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "文件：";
            // 
            // cbIncludeSubDir
            // 
            this.cbIncludeSubDir.AutoSize = true;
            this.cbIncludeSubDir.Location = new System.Drawing.Point(55, 53);
            this.cbIncludeSubDir.Name = "cbIncludeSubDir";
            this.cbIncludeSubDir.Size = new System.Drawing.Size(86, 17);
            this.cbIncludeSubDir.TabIndex = 25;
            this.cbIncludeSubDir.Text = "包含子目录";
            this.cbIncludeSubDir.UseVisualStyleBackColor = true;
            this.cbIncludeSubDir.CheckedChanged += new System.EventHandler(this.cbIncludeSubDir_CheckedChanged);
            // 
            // rb3x4
            // 
            this.rb3x4.AutoSize = true;
            this.rb3x4.Location = new System.Drawing.Point(242, 163);
            this.rb3x4.Name = "rb3x4";
            this.rb3x4.Size = new System.Drawing.Size(50, 17);
            this.rb3x4.TabIndex = 21;
            this.rb3x4.Text = "3 X 4";
            this.rb3x4.UseVisualStyleBackColor = true;
            this.rb3x4.CheckedChanged += new System.EventHandler(this.rb3x4_CheckedChanged);
            // 
            // rb2x4
            // 
            this.rb2x4.AutoSize = true;
            this.rb2x4.Location = new System.Drawing.Point(242, 139);
            this.rb2x4.Name = "rb2x4";
            this.rb2x4.Size = new System.Drawing.Size(50, 17);
            this.rb2x4.TabIndex = 20;
            this.rb2x4.Text = "2 X 4";
            this.rb2x4.UseVisualStyleBackColor = true;
            this.rb2x4.CheckedChanged += new System.EventHandler(this.rb2x4_CheckedChanged);
            // 
            // rb1x4
            // 
            this.rb1x4.AutoSize = true;
            this.rb1x4.Location = new System.Drawing.Point(242, 115);
            this.rb1x4.Name = "rb1x4";
            this.rb1x4.Size = new System.Drawing.Size(50, 17);
            this.rb1x4.TabIndex = 19;
            this.rb1x4.Text = "1 X 4";
            this.rb1x4.UseVisualStyleBackColor = true;
            this.rb1x4.CheckedChanged += new System.EventHandler(this.rb1x4_CheckedChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(12, 528);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(43, 13);
            this.lblSelectedCount.TabIndex = 18;
            this.lblSelectedCount.Text = "选中：";
            // 
            // rb3x3
            // 
            this.rb3x3.AutoSize = true;
            this.rb3x3.Location = new System.Drawing.Point(176, 163);
            this.rb3x3.Name = "rb3x3";
            this.rb3x3.Size = new System.Drawing.Size(50, 17);
            this.rb3x3.TabIndex = 17;
            this.rb3x3.Text = "3 X 3";
            this.rb3x3.UseVisualStyleBackColor = true;
            this.rb3x3.CheckedChanged += new System.EventHandler(this.rb3x3_CheckedChanged);
            // 
            // rb3x2
            // 
            this.rb3x2.AutoSize = true;
            this.rb3x2.Location = new System.Drawing.Point(114, 163);
            this.rb3x2.Name = "rb3x2";
            this.rb3x2.Size = new System.Drawing.Size(50, 17);
            this.rb3x2.TabIndex = 16;
            this.rb3x2.Text = "3 X 2";
            this.rb3x2.UseVisualStyleBackColor = true;
            this.rb3x2.CheckedChanged += new System.EventHandler(this.rb3x2_CheckedChanged);
            // 
            // rb3x1
            // 
            this.rb3x1.AutoSize = true;
            this.rb3x1.Location = new System.Drawing.Point(55, 163);
            this.rb3x1.Name = "rb3x1";
            this.rb3x1.Size = new System.Drawing.Size(50, 17);
            this.rb3x1.TabIndex = 15;
            this.rb3x1.Text = "3 X 1";
            this.rb3x1.UseVisualStyleBackColor = true;
            this.rb3x1.CheckedChanged += new System.EventHandler(this.rb3x1_CheckedChanged);
            // 
            // rb2x3
            // 
            this.rb2x3.AutoSize = true;
            this.rb2x3.Checked = true;
            this.rb2x3.Location = new System.Drawing.Point(176, 139);
            this.rb2x3.Name = "rb2x3";
            this.rb2x3.Size = new System.Drawing.Size(50, 17);
            this.rb2x3.TabIndex = 14;
            this.rb2x3.TabStop = true;
            this.rb2x3.Text = "2 X 3";
            this.rb2x3.UseVisualStyleBackColor = true;
            this.rb2x3.CheckedChanged += new System.EventHandler(this.rb2x3_CheckedChanged);
            // 
            // rb2x2
            // 
            this.rb2x2.AutoSize = true;
            this.rb2x2.Location = new System.Drawing.Point(114, 139);
            this.rb2x2.Name = "rb2x2";
            this.rb2x2.Size = new System.Drawing.Size(50, 17);
            this.rb2x2.TabIndex = 13;
            this.rb2x2.Text = "2 X 2";
            this.rb2x2.UseVisualStyleBackColor = true;
            this.rb2x2.CheckedChanged += new System.EventHandler(this.rb2x2_CheckedChanged);
            // 
            // rb2x1
            // 
            this.rb2x1.AutoSize = true;
            this.rb2x1.Location = new System.Drawing.Point(55, 139);
            this.rb2x1.Name = "rb2x1";
            this.rb2x1.Size = new System.Drawing.Size(50, 17);
            this.rb2x1.TabIndex = 12;
            this.rb2x1.Text = "2 X 1";
            this.rb2x1.UseVisualStyleBackColor = true;
            this.rb2x1.CheckedChanged += new System.EventHandler(this.rb2x1_CheckedChanged);
            // 
            // rb1x3
            // 
            this.rb1x3.AutoSize = true;
            this.rb1x3.Location = new System.Drawing.Point(176, 115);
            this.rb1x3.Name = "rb1x3";
            this.rb1x3.Size = new System.Drawing.Size(50, 17);
            this.rb1x3.TabIndex = 11;
            this.rb1x3.Text = "1 X 3";
            this.rb1x3.UseVisualStyleBackColor = true;
            this.rb1x3.CheckedChanged += new System.EventHandler(this.rb1x3_CheckedChanged);
            // 
            // rb1x2
            // 
            this.rb1x2.AutoSize = true;
            this.rb1x2.Location = new System.Drawing.Point(114, 115);
            this.rb1x2.Name = "rb1x2";
            this.rb1x2.Size = new System.Drawing.Size(50, 17);
            this.rb1x2.TabIndex = 10;
            this.rb1x2.Text = "1 X 2";
            this.rb1x2.UseVisualStyleBackColor = true;
            this.rb1x2.CheckedChanged += new System.EventHandler(this.rb1x2_CheckedChanged);
            // 
            // rb1x1
            // 
            this.rb1x1.AutoSize = true;
            this.rb1x1.Location = new System.Drawing.Point(55, 115);
            this.rb1x1.Name = "rb1x1";
            this.rb1x1.Size = new System.Drawing.Size(50, 17);
            this.rb1x1.TabIndex = 9;
            this.rb1x1.Text = "1 X 1";
            this.rb1x1.UseVisualStyleBackColor = true;
            this.rb1x1.CheckedChanged += new System.EventHandler(this.rb1x1_CheckedChanged);
            // 
            // lbSelectedFile
            // 
            this.lbSelectedFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelectedFile.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSelectedFile.FormattingEnabled = true;
            this.lbSelectedFile.HorizontalScrollbar = true;
            this.lbSelectedFile.ItemHeight = 14;
            this.lbSelectedFile.Location = new System.Drawing.Point(14, 555);
            this.lbSelectedFile.Name = "lbSelectedFile";
            this.lbSelectedFile.ScrollAlwaysVisible = true;
            this.lbSelectedFile.Size = new System.Drawing.Size(281, 200);
            this.lbSelectedFile.TabIndex = 7;
            this.lbSelectedFile.SelectedIndexChanged += new System.EventHandler(this.lbSelectedFile_SelectedIndexChanged);
            // 
            // tbDir
            // 
            this.tbDir.Enabled = false;
            this.tbDir.Location = new System.Drawing.Point(55, 16);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(198, 20);
            this.tbDir.TabIndex = 6;
            // 
            // btBrowse
            // 
            this.btBrowse.Enabled = false;
            this.btBrowse.Location = new System.Drawing.Point(260, 14);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(35, 25);
            this.btBrowse.TabIndex = 5;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "目录：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbOrderByExt);
            this.panel1.Controls.Add(this.rbOrderBySize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rbOrderByTime);
            this.panel1.Controls.Add(this.rbOrderByName);
            this.panel1.Location = new System.Drawing.Point(6, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 28);
            this.panel1.TabIndex = 25;
            // 
            // rbOrderByExt
            // 
            this.rbOrderByExt.AutoSize = true;
            this.rbOrderByExt.Location = new System.Drawing.Point(236, 3);
            this.rbOrderByExt.Name = "rbOrderByExt";
            this.rbOrderByExt.Size = new System.Drawing.Size(49, 17);
            this.rbOrderByExt.TabIndex = 26;
            this.rbOrderByExt.Text = "类型";
            this.rbOrderByExt.UseVisualStyleBackColor = true;
            this.rbOrderByExt.CheckedChanged += new System.EventHandler(this.rbOrderByExt_CheckedChanged);
            // 
            // rbOrderBySize
            // 
            this.rbOrderBySize.AutoSize = true;
            this.rbOrderBySize.Location = new System.Drawing.Point(170, 3);
            this.rbOrderBySize.Name = "rbOrderBySize";
            this.rbOrderBySize.Size = new System.Drawing.Size(49, 17);
            this.rbOrderBySize.TabIndex = 25;
            this.rbOrderBySize.Text = "大小";
            this.rbOrderBySize.UseVisualStyleBackColor = true;
            this.rbOrderBySize.CheckedChanged += new System.EventHandler(this.rbOrderBySize_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "排序：";
            // 
            // rbOrderByTime
            // 
            this.rbOrderByTime.AutoSize = true;
            this.rbOrderByTime.Location = new System.Drawing.Point(108, 3);
            this.rbOrderByTime.Name = "rbOrderByTime";
            this.rbOrderByTime.Size = new System.Drawing.Size(49, 17);
            this.rbOrderByTime.TabIndex = 24;
            this.rbOrderByTime.Text = "时间";
            this.rbOrderByTime.UseVisualStyleBackColor = true;
            this.rbOrderByTime.CheckedChanged += new System.EventHandler(this.rbOrderByTime_CheckedChanged);
            // 
            // rbOrderByName
            // 
            this.rbOrderByName.AutoSize = true;
            this.rbOrderByName.Checked = true;
            this.rbOrderByName.Location = new System.Drawing.Point(49, 3);
            this.rbOrderByName.Name = "rbOrderByName";
            this.rbOrderByName.Size = new System.Drawing.Size(49, 17);
            this.rbOrderByName.TabIndex = 23;
            this.rbOrderByName.TabStop = true;
            this.rbOrderByName.Text = "名称";
            this.rbOrderByName.UseVisualStyleBackColor = true;
            this.rbOrderByName.CheckedChanged += new System.EventHandler(this.rbOrderByName_CheckedChanged);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.Enabled = false;
            this.btExport.Location = new System.Drawing.Point(826, 22);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(98, 33);
            this.btExport.TabIndex = 8;
            this.btExport.Text = "导出";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // gbAction
            // 
            this.gbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAction.Controls.Add(this.btDelete);
            this.gbAction.Controls.Add(this.trackBarProgress);
            this.gbAction.Controls.Add(this.lblProgress);
            this.gbAction.Controls.Add(this.btLastPage);
            this.gbAction.Controls.Add(this.btNextPage);
            this.gbAction.Controls.Add(this.btPrevPage);
            this.gbAction.Controls.Add(this.btFirstPage);
            this.gbAction.Controls.Add(this.btExport);
            this.gbAction.Location = new System.Drawing.Point(7, 700);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(930, 68);
            this.gbAction.TabIndex = 6;
            this.gbAction.TabStop = false;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(714, 22);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(98, 33);
            this.btDelete.TabIndex = 16;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // trackBarProgress
            // 
            this.trackBarProgress.Location = new System.Drawing.Point(477, 14);
            this.trackBarProgress.Name = "trackBarProgress";
            this.trackBarProgress.Size = new System.Drawing.Size(178, 45);
            this.trackBarProgress.TabIndex = 15;
            this.trackBarProgress.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarProgress.Scroll += new System.EventHandler(this.trackBarProgress_Scroll);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(212, 33);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(24, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "0/0";
            // 
            // btLastPage
            // 
            this.btLastPage.Enabled = false;
            this.btLastPage.Location = new System.Drawing.Point(380, 22);
            this.btLastPage.Name = "btLastPage";
            this.btLastPage.Size = new System.Drawing.Size(75, 33);
            this.btLastPage.TabIndex = 12;
            this.btLastPage.Text = "尾页";
            this.btLastPage.UseVisualStyleBackColor = true;
            this.btLastPage.Click += new System.EventHandler(this.btLastPage_Click);
            // 
            // btNextPage
            // 
            this.btNextPage.Enabled = false;
            this.btNextPage.Location = new System.Drawing.Point(287, 22);
            this.btNextPage.Name = "btNextPage";
            this.btNextPage.Size = new System.Drawing.Size(75, 33);
            this.btNextPage.TabIndex = 11;
            this.btNextPage.Text = "下页";
            this.btNextPage.UseVisualStyleBackColor = true;
            this.btNextPage.Click += new System.EventHandler(this.btNextPage_Click);
            // 
            // btPrevPage
            // 
            this.btPrevPage.Enabled = false;
            this.btPrevPage.Location = new System.Drawing.Point(97, 22);
            this.btPrevPage.Name = "btPrevPage";
            this.btPrevPage.Size = new System.Drawing.Size(75, 33);
            this.btPrevPage.TabIndex = 10;
            this.btPrevPage.Text = "上页";
            this.btPrevPage.UseVisualStyleBackColor = true;
            this.btPrevPage.Click += new System.EventHandler(this.btPrevPage_Click);
            // 
            // btFirstPage
            // 
            this.btFirstPage.Enabled = false;
            this.btFirstPage.Location = new System.Drawing.Point(7, 22);
            this.btFirstPage.Name = "btFirstPage";
            this.btFirstPage.Size = new System.Drawing.Size(75, 33);
            this.btFirstPage.TabIndex = 9;
            this.btFirstPage.Text = "首页";
            this.btFirstPage.UseVisualStyleBackColor = true;
            this.btFirstPage.Click += new System.EventHandler(this.btFirstPage_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Red;
            // 
            // lbTagList
            // 
            this.lbTagList.CheckOnClick = true;
            this.lbTagList.FormattingEnabled = true;
            this.lbTagList.Location = new System.Drawing.Point(15, 214);
            this.lbTagList.Name = "lbTagList";
            this.lbTagList.Size = new System.Drawing.Size(280, 304);
            this.lbTagList.TabIndex = 34;
            this.lbTagList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbTagList_ItemCheck);
            this.lbTagList.Click += new System.EventHandler(this.lbTagList_Click);
            this.lbTagList.SelectedIndexChanged += new System.EventHandler(this.lbTagList_SelectedIndexChanged);
            // 
            // ImageVieweForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 777);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbImage);
            this.Name = "ImageVieweForm";
            this.Text = "Image Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.gbImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbSelectedFile;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rb1x3;
        private System.Windows.Forms.RadioButton rb1x2;
        private System.Windows.Forms.RadioButton rb1x1;
        private System.Windows.Forms.RadioButton rb3x3;
        private System.Windows.Forms.RadioButton rb3x2;
        private System.Windows.Forms.RadioButton rb3x1;
        private System.Windows.Forms.RadioButton rb2x3;
        private System.Windows.Forms.RadioButton rb2x2;
        private System.Windows.Forms.RadioButton rb2x1;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.GroupBox gbAction;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btLastPage;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.Button btPrevPage;
        private System.Windows.Forms.Button btFirstPage;
        private System.Windows.Forms.RadioButton rb3x4;
        private System.Windows.Forms.RadioButton rb2x4;
        private System.Windows.Forms.RadioButton rb1x4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.TrackBar trackBarProgress;
        private System.Windows.Forms.PictureBox pictureBoxDetail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rbOrderByTime;
        private System.Windows.Forms.RadioButton rbOrderByName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbIncludeSubDir;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.CheckBox cbImageOnly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbOrderBySize;
        private System.Windows.Forms.RadioButton rbOrderByExt;
        private System.Windows.Forms.Button btClearAll;
        private System.Windows.Forms.Button btAddTag;
        private System.Windows.Forms.Button btDeleteTag;
        private System.Windows.Forms.Button btUpdateTag;
        private System.Windows.Forms.Button btQueryByTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox lbTagList;
    }
}

