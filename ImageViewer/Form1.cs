using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace ImageViewer
{
    public partial class Form1 : Form
    {
        private int _row = 2, _column = 3;
        private PictureBox[]  _pictureList = new PictureBox[12];
        private FileInfo[] _fileList;
        private int _imageIndex = 0;
        private int _imageIndexDetail = 0;
        private bool _formLoading = true;
        private int _maxPicturesPerScreen = 12;
        private bool _orderByFileName = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _pictureList[0] = pictureBox1;
            _pictureList[1] = pictureBox2;
            _pictureList[2] = pictureBox3;
            _pictureList[3] = pictureBox4;
            _pictureList[4] = pictureBox5;
            _pictureList[5] = pictureBox6;
            _pictureList[6] = pictureBox7;
            _pictureList[7] = pictureBox8;
            _pictureList[8] = pictureBox9;
            _pictureList[9] = pictureBox10;
            _pictureList[10] = pictureBox11;
            _pictureList[11] = pictureBox12;

            for (var index = 0; index < _maxPicturesPerScreen; index++)
            {
                _pictureList[index].MouseWheel += new MouseEventHandler(OnMouseWheel);
                _pictureList[index].MouseMove += new MouseEventHandler(OnMouseMove);
                _pictureList[index].Click += new EventHandler(OnImageClicked);
            }

            tbDir.Text = (@"D:\Temp\Image");

            _formLoading = false;
            AdjustSize(true);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (!_formLoading)
                AdjustSize(true);
        }

        private void AdjustSize(bool sizeChanged)
        {
            gbImage.Width = this.Width - gbControl.Width - 40;
            gbAction.Width = gbImage.Width;
           // lbSelectedFile.Height = gbControl.Height - 230;

            pictureBoxDetail.Location = new Point(5, 5);
            pictureBoxDetail.Size = new System.Drawing.Size(gbImage.Size.Width - 10, gbImage.Size.Height - 10);
            pictureBoxDetail.Visible = false;

            OnRowColumnChanged(_row, _column, sizeChanged);
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog { Description = "请选择文件路径", SelectedPath = tbDir.Text };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            tbDir.Text = dialog.SelectedPath;
            ShowImage(tbDir.Text);
        }

        private void gbControl_Enter(object sender, EventArgs e)
        {

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog { Description = "请选择文件路径", SelectedPath = tbDir.Text };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            foreach(var file in lbSelectedFile.Items)
            {
                var fileInfo = new FileInfo(file as string);

                File.Copy(fileInfo.FullName, Path.Combine(dialog.SelectedPath, fileInfo.Name));
            }
        }


        private void OnRowColumnChanged(int row, int column, bool sizeChanged)
        {
            if ((_row == row && _column == column) && !sizeChanged)
                return;

            if (_row == 0 || _column == 0 || _pictureList == null)
                return;

            _row = row;
            _column = column;

            var interval = 5;
            int imageWidth = (gbImage.Width-interval*(_column+1)) / _column;
            int imageHeight = (gbImage.Height-interval*(_row+2)) / _row;
            var pictureSize = new Size(imageWidth, imageHeight);

            int count = _row * _column;
            _imageIndex = (_imageIndex / count) * count;
            int index = 0;
            for ( var i = 0; i < _row; i++ )
            {
                for ( var j = 0; j < _column; j ++)
                {
                    index = i * _column + j;

                    var locX = j * imageWidth + (j + 1) * interval;
                    var locY = i * imageHeight + (i + 2) * interval;

                    _pictureList[index].Location = new Point(locX, locY);
                    _pictureList[index].Size = pictureSize;
                    _pictureList[index].Visible = true;

                    if (_fileList != null && _imageIndex + index < _fileList.Length)
                    {
                        if (_pictureList[index].ImageLocation != _fileList[_imageIndex + index].FullName)
                        {
                            _pictureList[index].ImageLocation = _fileList[_imageIndex + index].FullName;
                            SetImageTipInfo(_pictureList[index]);
                            SetSelectState(_pictureList[index]);
                        }
                    }
                }
            }

            for (index = index + 1; index < _maxPicturesPerScreen; index++)
            {
                _pictureList[index].Visible = false;
                _pictureList[index].ImageLocation = string.Empty;
                SetImageTipInfo(_pictureList[index]);
            }

            SetShowStatus();
            UpdateTrackBar();

        }

        private void SetImageTipInfo(PictureBox pictureBox)
        {
            if (string.IsNullOrEmpty(pictureBox?.ImageLocation) )
                return;

            toolTip1.SetToolTip(pictureBox, pictureBox.ImageLocation);
        }

        private void OnImageClicked(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (string.IsNullOrEmpty(pictureBox.ImageLocation))
                return;

            var mouseE = e as MouseEventArgs;
            if (mouseE.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (pictureBox.BackColor == System.Drawing.SystemColors.ControlDark)
                {
                    lbSelectedFile.Items.Add(pictureBox.ImageLocation);
                    pictureBox.BackColor = Color.Red;
                }
                else
                {
                    lbSelectedFile.Items.Remove(pictureBox.ImageLocation);
                    pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
                }
            }
            else if (mouseE.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pictureBoxDetail.ImageLocation = pictureBox.ImageLocation;
                pictureBoxDetail.Visible = true;
                gbControl.Enabled = false;
                gbAction.Enabled = false;
                
                for (var i = 0; i < _row*_column; i++)
                {
                    if (_fileList[_imageIndex+i].FullName == pictureBox.ImageLocation)
                    {
                        _imageIndexDetail = _imageIndex + i;
                        break;
                    }
                }
            }
        }

        private void ShowImage(string imageDir)
        {
            DirectoryInfo root = new DirectoryInfo(imageDir);
            _fileList = root.GetFiles();

            if (!_orderByFileName)
                _fileList = _fileList.OrderBy(x => x.LastWriteTime).ToArray();

            _imageIndex = -_row * _column;

            ShowNextImageOnScreen();
            UpdateTrackBar();
        }

        private void UpdateTrackBar()
        {
            if (_fileList == null)
                return;

            trackBarProgress.Minimum = 0;
            trackBarProgress.Maximum = _fileList.Length % (_row * _column) == 0 ? _fileList.Length / (_row * _column) - 1 : _fileList.Length / (_row * _column);
            trackBarProgress.Value = _imageIndex / (_row * _column);
        }

        private void ShowOneScreen()
        {
            var imageCount = _row * _column;
            if (imageCount > _fileList.Length - _imageIndex)
                imageCount = _fileList.Length - _imageIndex;

            for (var i = 0; i < imageCount; i++)
            {
                _pictureList[i].ImageLocation = _fileList[_imageIndex + i].FullName;
                SetImageTipInfo(_pictureList[i]);
                SetSelectState(_pictureList[i]);
            }

            for (var i = imageCount; i < _row * _column; i++)
            {
                _pictureList[i].ImageLocation = string.Empty;
                SetImageTipInfo(_pictureList[i]);
                SetSelectState(_pictureList[i]);
            }

            SetShowStatus();
            trackBarProgress.Value = _imageIndex / (_row * _column);
        }

        private void SetShowStatus()
        {
            if (_fileList == null)
                return;

            btFirstPage.Enabled = _imageIndex > 0;
            btPrevPage.Enabled = btFirstPage.Enabled;
            btNextPage.Enabled = _imageIndex < _fileList.Length - _row * _column;
            btLastPage.Enabled = btNextPage.Enabled;

            lblProgress.Text = string.Format("{0} / {1}", _imageIndex / (_row * _column) + 1, (_fileList.Length - 1) / (_row * _column) + 1);
        }

        private void ShowNextImageOnScreen()
        {
            if (_fileList == null)
                return;

            // The index of image that has be shown in the first box 
            if (_imageIndex + _row * _column >= _fileList.Length)
                return;

            _imageIndex += _row * _column;
            ShowOneScreen();
        }

        private void ShowPrevImageOnScreen()
        {
            if (_fileList == null)
                return;

            if (_imageIndex <= 0)
                return;

            _imageIndex -= _row * _column;
            ShowOneScreen();
        }

        private void SetSelectState(PictureBox pictureBox)
        {
            if (lbSelectedFile.Items.Contains(pictureBox.ImageLocation))
            {
                pictureBox.BackColor = Color.Red;
            }
            else
            {
                pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            }
        }

        private void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pictureBoxDetail.Visible)
            {
                if (e.Delta < 0)
                {
                    if (_imageIndexDetail < _fileList.Length - 1)
                        pictureBoxDetail.ImageLocation = _fileList[++_imageIndexDetail].FullName;
                }
                else
                {
                    if (_imageIndexDetail > 0)
                        pictureBoxDetail.ImageLocation = _fileList[--_imageIndexDetail].FullName;
                }
                return;
            }

            if (e.Delta > 0)
            {
                ShowPrevImageOnScreen();
            }
            else
            {
                ShowNextImageOnScreen();
            }
        }

        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            pictureBox.Focus();
        }

        private void lbSelectedFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableShowImage(lbSelectedFile.Text);
        }

        private void EnableShowImage(string imageFullName)
        {
            int i;
            for (i = 0; i < _fileList.Length; i++)
            {
                if (_fileList[i].FullName == imageFullName)
                    break;
            }

            if (i == _fileList.Length)
                return;

            int count = _row * _column;
            _imageIndex = (i / count) * count + count;
            ShowPrevImageOnScreen();
        }

        private void rb1x1_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(1, 1, false);
        }

        private void rb1x2_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(1, 2, false);
        }

        private void rb1x3_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(1, 3, false);
        }

        private void rb2x1_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(2, 1, false);
        }

        private void rb2x2_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(2, 2, false);
        }

        private void rb2x3_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(2, 3, false);
        }

        private void rb3x1_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(3, 1, false);
        }

        private void rb3x2_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(3, 2, false);
        }

        private void rb3x3_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(3, 3, false);
        }

        private void btFirstPage_Click(object sender, EventArgs e)
        {
            _imageIndex = _row * _column;
            ShowPrevImageOnScreen();
        }

        private void btPrevPage_Click(object sender, EventArgs e)
        {
            ShowPrevImageOnScreen();
        }

        private void btNextPage_Click(object sender, EventArgs e)
        {
            ShowNextImageOnScreen();
        }

        private void btLastPage_Click(object sender, EventArgs e)
        {
            var count = _row * _column;
            _imageIndex = _fileList.Length / count * count - count;
            ShowNextImageOnScreen();
        }

        private void rb1x4_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(1, 4, false);
        }

        private void rb2x4_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(2, 4, false);
        }

        private void rb3x4_CheckedChanged(object sender, EventArgs e)
        {
            OnRowColumnChanged(3, 4, false);
        }

        private void trackBarProgress_Scroll(object sender, EventArgs e)
        {
            _imageIndex = (trackBarProgress.Value - 1) * _row * _column;
            ShowNextImageOnScreen();
        }

        private void rbOrderByName_CheckedChanged(object sender, EventArgs e)
        {
            _orderByFileName = true;
            ShowImage(tbDir.Text);
        }

        private void rbOrderByTime_CheckedChanged(object sender, EventArgs e)
        {
            _orderByFileName = false;
            ShowImage(tbDir.Text);
        }

        private void pictureBoxDetail_Click(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (string.IsNullOrEmpty(pictureBox.ImageLocation))
                return;

            var mouseE = e as MouseEventArgs;
            if (mouseE.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pictureBox.Visible = false;
                gbAction.Enabled = true;
                gbControl.Enabled = true;
            }
        }

    }
}
