using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;


namespace ImageViewer
{
    public partial class ImageVieweForm : Form
    {
        private int _row = 2, _column = 3;
        private PictureBox[]  _pictureList = new PictureBox[12];
        private RadioButton[] _layoutList = new RadioButton[12];
        private FileInfo[] _fileList;
        private int _imageIndex = 0;
        private int _imageIndexDetail = 0;
        private bool _formLoading = true;
        private int _maxPicturesPerScreen = 12;
        private bool _orderByFileName = true;
        private string _exportDir = string.Empty;
        private bool _deleteAfterExport = false;
        private string _workingDir = string.Empty;
        private Configuration _config = null;
        private string _openedImageByCmd = string.Empty;

        public ImageVieweForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WriteShellRunReg();

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

            _layoutList[0] = rb1x1;
            _layoutList[1] = rb1x2;
            _layoutList[2] = rb1x3;
            _layoutList[3] = rb1x4;
            _layoutList[4] = rb2x1;
            _layoutList[5] = rb2x2;
            _layoutList[6] = rb2x3;
            _layoutList[7] = rb2x4;
            _layoutList[8] = rb3x1;
            _layoutList[9] = rb3x2;
            _layoutList[10] = rb3x3;
            _layoutList[11] = rb3x4;


            for (var index = 0; index < _maxPicturesPerScreen; index++)
            {
                _pictureList[index].MouseWheel += new MouseEventHandler(OnMouseWheel);
                _pictureList[index].MouseMove += new MouseEventHandler(OnMouseMove);
                _pictureList[index].Click += new EventHandler(OnImageClicked);
            }

            pictureBoxDetail.MouseWheel += OnMouseWheel;

            var cmdLine = Environment.GetCommandLineArgs();
            if (cmdLine.Count() == 2)
            {
                var fileInfo = new FileInfo(cmdLine[1]);
                if (fileInfo.Attributes == FileAttributes.Directory)
                    _workingDir = cmdLine[1];
                else
                {
                    _openedImageByCmd = cmdLine[1];
                    _workingDir = fileInfo.DirectoryName;
                }
                
                var map = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(_workingDir, "ImageViewer.xml") };
                _config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            }
            else
            {
                _workingDir = @"C:\Temp\Image";
                _config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            }

            

            LoadConfig();
            _formLoading = false;
            AdjustSize(true);
            ShowImage(tbDir.Text, _imageIndex);
        }

        private void LoadConfig()
        {
            tbDir.Text = LoadSetting("ImageDir", _workingDir);
            _orderByFileName = LoadSetting("OrderByName", "1") == "1";
            _imageIndex = int.Parse(LoadSetting("ImageIndex", "0"));
            if (_imageIndex < 0)
                _imageIndex = 0;
            _row = int.Parse(LoadSetting("Row", "2"));
            _column = int.Parse(LoadSetting("Column", "3"));
            var selectedFiles = LoadSetting("SelectedFiles", "");
            object[] fileList = selectedFiles.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            lbSelectedFile.Items.AddRange(fileList);

            rbOrderByName.Checked = _orderByFileName;
            rbOrderByTime.Checked = !_orderByFileName;

            cbIncludeSubDir.Checked = LoadSetting("IncludeSubDir", "0") == "1";
            cbImageOnly.Checked = LoadSetting("ImageOnly", "1") == "1";

            _exportDir = LoadSetting("ExportDir", @"C:\");
            _deleteAfterExport = LoadSetting("DeleteAfterExport", "0") == "1";

            if (_openedImageByCmd != string.Empty)
            {
                _row = 1;
                _column = 1;
                cbImageOnly.Checked = false;

            }

            _layoutList[(_row - 1) * 4 + _column - 1].Checked = true;
        }

        private string LoadSetting(string key, string defaultValue)
        {
            var setting = _config.AppSettings.Settings[key];
            return setting == null ? defaultValue : setting.Value;
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

            _openedImageByCmd = string.Empty;
            tbDir.Text = dialog.SelectedPath;
            ShowImage(tbDir.Text, 0);
        }

        private void gbControl_Enter(object sender, EventArgs e)
        {

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            var exportForm = new ExportForm
            {
                ExportDir = _exportDir,
                DeleteAfterExport = _deleteAfterExport
            };

            exportForm.ShowDialog();
            if (!exportForm.NeedExport)
                return;

            _exportDir = exportForm.ExportDir;
            _deleteAfterExport = exportForm.DeleteAfterExport;

            var selectedFiles = new object[lbSelectedFile.Items.Count];
            lbSelectedFile.Items.CopyTo(selectedFiles, 0);

            foreach (var file in selectedFiles)
            {
                var fileInfo = new FileInfo(file as string);
                CopyFile(fileInfo.FullName, Path.Combine(_exportDir, fileInfo.Name));
                lbSelectedFile.Items.Remove(file);
            }

            if (_deleteAfterExport)
            {
                if (MessageBox.Show("导出完成，确定要删除这些文件吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var file in selectedFiles)
                    {
                        File.Delete(file as string);
                    }

                    ShowImage(tbDir.Text, 0);
                }
            }
            else
            {
                for (var index = 0; index < _maxPicturesPerScreen; index++)
                {
                    _pictureList[index].BackColor = System.Drawing.SystemColors.ControlDark;
                }
            }
        }

        private void CopyFile(string srcFile, string destFile)
        {
            try
            {
                if (File.Exists(destFile))
                {
                    var fileInfo = new FileInfo(destFile);
                    destFile = Path.Combine(fileInfo.DirectoryName, DateTime.Now.ToBinary() + fileInfo.Name);
                }
                File.Copy(srcFile, destFile);
            }
            catch (Exception)
            {

            }
        }

        private void OnRowColumnChanged(int row, int column, bool sizeChanged)
        {
            if (_formLoading)
                return;

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

                    if (_fileList != null && _imageIndex + index < _fileList.Length && _imageIndex + index > 0)
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
            if (pictureBox == null || string.IsNullOrEmpty(pictureBox.ImageLocation) )
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

                btExport.Enabled = btDelete.Enabled = lbSelectedFile.Items.Count > 0;
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

        private void ShowImage(string imageDir, int currentIndex)
        {
            if (!Directory.Exists(imageDir))
                return;

            var root = new DirectoryInfo(imageDir);
            _fileList = root.GetFiles("*.*", cbIncludeSubDir.Checked? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            if (!_fileList.Any())
                return;

            if (cbImageOnly.Checked)
            {
                var supportedImageFiles = ".png;.bmp;.gif;.jpg;.jpeg".Split(';');
                _fileList = (from fileInfo in _fileList from supportedImageFile in supportedImageFiles where supportedImageFile == fileInfo.Extension.ToLower() select fileInfo).ToArray();
            }
            
            if (!_orderByFileName)
                _fileList = _fileList.OrderBy(x => x.LastWriteTime).ToArray();
            else
                _fileList = _fileList.OrderBy(x => x.FullName).ToArray();

            //_fileList = _fileList.OrderBy(x => x.Length).ToArray();

            if (string.IsNullOrEmpty(_openedImageByCmd))
                _imageIndex = currentIndex - _row*_column;
            else
                _imageIndex = FindImageIndex(_openedImageByCmd)-2;

            ShowNextImageOnScreen();
            UpdateTrackBar();
        }

        private void UpdateTrackBar()
        {
            if (_fileList == null || _fileList.Count() == 0)
                return;

            trackBarProgress.Minimum = 0;
            trackBarProgress.Maximum = _fileList.Length % (_row * _column) == 0 ? _fileList.Length / (_row * _column) - 1 : _fileList.Length / (_row * _column);
            var pos = _imageIndex / (_row * _column);
            if (pos < trackBarProgress.Minimum)
                pos = trackBarProgress.Minimum;
            if (pos > trackBarProgress.Maximum)
                pos = trackBarProgress.Maximum;
            trackBarProgress.Value = pos;
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

            btExport.Enabled = btDelete.Enabled = lbSelectedFile.Items.Count > 0;
        }

        private void ShowNextImageOnScreen()
        {
            if (_fileList == null)
                return;

            // The index of image that has be shown in the first box 
            if (_imageIndex + _row * _column >= _fileList.Length)
                return;

            _imageIndex += _row * _column;
            UpdateTrackBar();
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

        private int FindImageIndex(string imageFullName)
        {
            int i;
            for (i = 0; i < _fileList.Length; i++)
            {
                if (_fileList[i].FullName == imageFullName)
                    break;
            }

            if (i == _fileList.Length)
                return -1;

            int count = _row * _column;
            return (i / count) * count + count; 
        }

        private void EnableShowImage(string imageFullName)
        {
            var index = FindImageIndex(imageFullName);
            if (index != -1)
            {
                _imageIndex = index;
                ShowPrevImageOnScreen();
            }
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
            if (!_formLoading)
            {
                _orderByFileName = rbOrderByName.Checked;
                ShowImage(tbDir.Text, 0);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (MessageBox.Show("需要保存图像浏览记录吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;

            SaveSetting("ImageDir", tbDir.Text);
            SaveSetting("OrderByName", rbOrderByName.Checked? "1" : "0");
            if (_imageIndex < 0)
                _imageIndex = 0;
            SaveSetting("ImageIndex", _imageIndex.ToString(CultureInfo.InvariantCulture));
            SaveSetting("Row", _row.ToString(CultureInfo.InvariantCulture));
            SaveSetting("Column", _column.ToString(CultureInfo.InvariantCulture));

            var selectedFiles = lbSelectedFile.Items.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + ";"));
            SaveSetting("SelectedFiles", selectedFiles);

            SaveSetting("IncludeSubDir", cbIncludeSubDir.Checked ? "1" : "0");
            SaveSetting("ImageOnly", cbImageOnly.Checked ? "1" : "0");

            SaveSetting("ExportDir", _exportDir);
            SaveSetting("DeleteAfterExport", _deleteAfterExport ? "1" : "0");

            _config.Save(ConfigurationSaveMode.Minimal);
        }

        private void SaveSetting(string key, string value)
        {
            _config.AppSettings.Settings.Remove(key);
            _config.AppSettings.Settings.Add(key, value);
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
                pictureBox.ImageLocation = string.Empty;
                gbAction.Enabled = true;
                gbControl.Enabled = true;
            }
        }

        private void cbIncludeSubDir_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;

            ShowImage(tbDir.Text, 0);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除这些文件吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var selectedFiles = new object[lbSelectedFile.Items.Count];
            lbSelectedFile.Items.CopyTo(selectedFiles, 0);

            foreach (var file in selectedFiles)
            {
                File.Delete(file as string);
                lbSelectedFile.Items.Remove(file);
            }

            ShowImage(tbDir.Text, 0);
        }

        private void cbImageOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;

            ShowImage(tbDir.Text, 0);
        }

        private void WriteShellRunReg()
        {
            var root = Registry.ClassesRoot;
            
            var command = root.CreateSubKey(@"Folder\shell\ImageViewer\command");
            command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");

            command = root.CreateSubKey(@"*\shell\ImageViewer\Command");
            command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
        }

    }
}
