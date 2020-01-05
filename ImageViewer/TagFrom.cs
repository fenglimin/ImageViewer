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

        public bool Cancelled { get; set; }

        public TagFrom()
        {
            InitializeComponent();
        }

        private void TagFrom_Load(object sender, EventArgs e)
        {
            Cancelled = true;
            tbTag.Text = TagName;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            TagName = tbTag.Text;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
