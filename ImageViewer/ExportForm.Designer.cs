namespace ImageViewer
{
    partial class ExportForm
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
            this.tbDir = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDeleteAfterExport = new System.Windows.Forms.CheckBox();
            this.btExport = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(59, 16);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(305, 20);
            this.tbDir.TabIndex = 9;
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(370, 14);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(35, 25);
            this.btBrowse.TabIndex = 8;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "目录：";
            // 
            // cbDeleteAfterExport
            // 
            this.cbDeleteAfterExport.AutoSize = true;
            this.cbDeleteAfterExport.Location = new System.Drawing.Point(19, 57);
            this.cbDeleteAfterExport.Name = "cbDeleteAfterExport";
            this.cbDeleteAfterExport.Size = new System.Drawing.Size(86, 17);
            this.cbDeleteAfterExport.TabIndex = 10;
            this.cbDeleteAfterExport.Text = "导出后删除";
            this.cbDeleteAfterExport.UseVisualStyleBackColor = true;
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btExport.Location = new System.Drawing.Point(88, 86);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(98, 28);
            this.btExport.TabIndex = 11;
            this.btExport.Text = "确定";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(237, 86);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(98, 28);
            this.btCancel.TabIndex = 12;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            this.AcceptButton = this.btExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(424, 126);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btExport);
            this.Controls.Add(this.cbDeleteAfterExport);
            this.Controls.Add(this.tbDir);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导出";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbDeleteAfterExport;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Button btCancel;
    }
}