using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class TagFrom : Form
    {
        public string TagName { get; set; }

        public TagFrom()
        {
            InitializeComponent();
        }

        private void TagFrom_Load(object sender, EventArgs e)
        {
            tbTag.Text = TagName;
            btExport.Enabled = !string.IsNullOrEmpty(tbTag.Text);
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            TagName = tbTag.Text;
        }

        private void tbTag_TextChanged(object sender, EventArgs e)
        {
            btExport.Enabled = !string.IsNullOrEmpty(tbTag.Text);
        }
    }
}
