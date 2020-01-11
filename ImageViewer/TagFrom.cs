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
        public string TagShortcut { get; set; }
        public List<ImageVieweForm.ImageTag> TagList { get; set; }

        private bool _formLoading = true;

        public TagFrom()
        {
            InitializeComponent();
        }

        private void TagFrom_Load(object sender, EventArgs e)
        {
            tbTag.Text = TagName;
            tbShortcut.Text = TagShortcut;
            btExport.Enabled = !string.IsNullOrEmpty(tbTag.Text);

            _formLoading = false;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            TagName = tbTag.Text;
            TagShortcut = tbShortcut.Text.ToUpper();
        }

        private void tbTag_TextChanged(object sender, EventArgs e)
        {
            if (_formLoading)
            {
                return;
            }

            if (CheckTagName())
            {
                btExport.Enabled = CheckTagShortcut();
            }
        }

        private void tbShortcut_TextChanged(object sender, EventArgs e)
        {
            if (_formLoading)
            {
                return;
            }

            if (CheckTagShortcut())
            {
                btExport.Enabled = CheckTagName();
            }
        }

        private bool CheckTagName()
        {
            if (string.IsNullOrEmpty(tbTag.Text))
            {
                return false;
            }

            if (TagList != null)
            {
                if (TagList.FindIndex(tag => tag.Name == tbTag.Text) != -1)
                {
                    if (string.IsNullOrEmpty(TagName) || (TagName.CompareTo(tbTag.Text) != 0))
                    {
                        MessageBox.Show("标签名已存在，请重新输入！", "错误");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckTagShortcut()
        {

            if (string.IsNullOrEmpty(tbShortcut.Text))
            {
                return false;
            }

            if (tbShortcut.Text == "a" || tbShortcut.Text == "A")
            {
                MessageBox.Show("A是保留的快捷键，用来选择图像！", "错误");
                tbShortcut.Text = "";
                return false;
            }

            if (TagList != null)
            {
                if (TagList.FindIndex(tag => tag.ShortcutKey.CompareTo(tbShortcut.Text.ToUpper()) == 0) != -1)
                {
                    if (string.IsNullOrEmpty(TagShortcut) || (TagShortcut.CompareTo(tbShortcut.Text.ToUpper()) != 0))
                    {
                        MessageBox.Show("标签快捷键已存在，请重新输入！", "错误");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
