namespace ImageViewer
{
    partial class TagFrom
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTag = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbShortcut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签";
            // 
            // tbTag
            // 
            this.tbTag.Location = new System.Drawing.Point(15, 35);
            this.tbTag.Name = "tbTag";
            this.tbTag.Size = new System.Drawing.Size(120, 20);
            this.tbTag.TabIndex = 1;
            this.tbTag.TextChanged += new System.EventHandler(this.tbTag_TextChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(174, 71);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(98, 28);
            this.btCancel.TabIndex = 14;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btExport.Location = new System.Drawing.Point(25, 71);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(98, 28);
            this.btExport.TabIndex = 13;
            this.btExport.Text = "确定";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "快捷键";
            // 
            // tbShortcut
            // 
            this.tbShortcut.Location = new System.Drawing.Point(164, 35);
            this.tbShortcut.Name = "tbShortcut";
            this.tbShortcut.Size = new System.Drawing.Size(120, 20);
            this.tbShortcut.TabIndex = 2;
            // 
            // TagFrom
            // 
            this.AcceptButton = this.btExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(296, 110);
            this.Controls.Add(this.tbShortcut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.tbTag);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "标签";
            this.Load += new System.EventHandler(this.TagFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTag;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbShortcut;
    }
}