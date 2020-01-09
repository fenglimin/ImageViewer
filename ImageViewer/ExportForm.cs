using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class ExportForm : Form
    {
        public string ExportDir { get; set; }
        public bool NeedExport { get; set; }
        public bool DeleteAfterExport { get; set; }

        public ExportForm()
        {
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog { Description = "请选择文件路径", SelectedPath = tbDir.Text };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            tbDir.Text = dialog.SelectedPath;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            NeedExport = true;
            ExportDir = tbDir.Text;
            DeleteAfterExport = cbDeleteAfterExport.Checked;

            if (!Directory.Exists(ExportDir))
            {
                Directory.CreateDirectory(ExportDir);
            }
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            NeedExport = false;

            tbDir.Text = ExportDir;
            cbDeleteAfterExport.Checked = DeleteAfterExport;
        }
    }
}
