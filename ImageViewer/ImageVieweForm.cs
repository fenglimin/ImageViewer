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
        public class ImageTag
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ShortcutKey { get; set; }

            public ImageTag(string value)
            {
                var valueList = value.Split(';');
                if (valueList.Length == 1)
                {
                    Id = 0;
                    Name = value;
                    ShortcutKey = "";
                }
                else
                {
                    Id = Convert.ToInt32(valueList[0]);
                    Name = valueList[1];
                    ShortcutKey = valueList[2];
                }
            }

            public override string ToString()
            {
                return Id + ";" + Name + ";" + ShortcutKey;
            }

            public string DisplayString()
            {
                return Name + " （" + ShortcutKey + "）";
            }
        }

        public class TaggedImage
        {
            public string ImageName { get; set; }
            public string TagList { get; set; }

            public TaggedImage(string value)
            {
                var valueList = value.Split(':');
                if (valueList.Length == 1)
                {
                    ImageName = value;
                    TagList = "";
                }
                else
                {
                    ImageName = valueList[0];
                    TagList = valueList[1];
                }
            }

            public override string ToString()
            {
                return string.IsNullOrEmpty(TagList)? string.Empty : ImageName + ":" + TagList;
            }

            public void AddTag(int tagId)
            {
                var findString = ";" + TagList;
                if (!findString.Contains(";" + tagId + ";"))
                {
                    TagList += tagId + ";";
                }
            }

            public void DeleteTag(int tagId)
            {
                var findString = ";" + TagList;
                if (findString.Contains(";" + tagId + ";"))
                {
                    TagList = TagList.Replace(tagId + ";", "");
                }
            }

            public bool HasTag(string tagIdListString)
            {
                var findString = ";" + TagList;
                if (tagIdListString[tagIdListString.Length - 1] == ';')
                {
                    tagIdListString = tagIdListString.Substring(0, tagIdListString.Length - 1);
                }
                
                var tagIdList = tagIdListString.Split(';');
                return tagIdList.Any(tagId => findString.Contains(";" + tagId + ";"));
            }
        }

        private int _row = 2, _column = 3;
        private PictureBox[]  _pictureList = new PictureBox[12];
        private RadioButton[] _layoutList = new RadioButton[12];
        private FileInfo[] _fileList;
        private int _imageIndex = 0;
        private int _imageIndexDetail = 0;
        private bool _formLoading = true;
        private bool _ignoreOnlyUntaggedEvent = false;
        private int _maxPicturesPerScreen = 12;
        private int _orderBy = 0;
        private string _exportDir = string.Empty;
        private bool _deleteAfterExport = false;
        private string _workingDir = string.Empty;
        private Configuration _config = null;
        private string _openedImageByCmd = string.Empty;
        private List<ImageTag> _tagList = new List<ImageTag>();
        private List<TaggedImage> _taggedImageList = new List<TaggedImage>();
        private List<int> _lastSelectedIndices = new List<int>();
        private bool _ignoreCheck;

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
            pictureBoxDetail.Click += OnImageClicked;

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
                _workingDir = Application.StartupPath;
                _config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                btBrowse.Enabled = true;
            }

            if (!_workingDir.EndsWith("\\"))
            {
                _workingDir += "\\";
            }

            var ret = LoadConfig();
            _formLoading = false;
            AdjustSize(true);
            SetPictureBoxVisible(true);


            ShowImage(tbDir.Text, _imageIndex);

            Text = "Image Viewer - " + tbDir.Text;
            SetSelectedCount();

            if (!ret && !btBrowse.Enabled)
            {
                MessageBox.Show("当前目录与配置文件中的目录不一致，默认加载配置文件中的目录 - " + tbDir.Text, "信息", MessageBoxButtons.OK);
            }
        }

        private void SetPictureBoxVisible(bool visible)
        {
            for (var i = 0; i < _row * _column; i++)
            {
                _pictureList[i].Visible = visible;
            }
        }

        private bool LoadConfig()
        {
            var ret = true;
            var dir = LoadSetting("ImageDir", _workingDir);
            if (!Directory.Exists(dir))
            {
                dir = _workingDir;
            }
            else
            {
                if (dir != _workingDir)
                {
                    ret = false;
                }
            }

            if (!dir.EndsWith("\\"))
            {
                dir += "\\";
            }

            tbDir.Text = dir;
            _orderBy = int.Parse(LoadSetting("OrderBy", "0"));
            _imageIndex = int.Parse(LoadSetting("ImageIndex", "0"));
            if (_imageIndex < 0)
                _imageIndex = 0;
            _row = int.Parse(LoadSetting("Row", "2"));
            _column = int.Parse(LoadSetting("Column", "3"));
            var selectedFiles = LoadSetting("SelectedFiles", "");
            object[] fileList = selectedFiles.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            lbSelectedFile.Items.AddRange(fileList);

            rbOrderByName.Checked = _orderBy == 0;
            rbOrderByTime.Checked = _orderBy == 1;
            rbOrderBySize.Checked = _orderBy == 2;
            rbOrderByExt.Checked = _orderBy == 3;


            cbIncludeSubDir.Checked = LoadSetting("IncludeSubDir", "0") == "1";
            cbImageOnly.Checked = LoadSetting("ImageOnly", "1") == "1";

            cbOnlyUntagged.Checked = LoadSetting("UntaggedOnly", "0") == "1";
            _exportDir = LoadSetting("ExportDir", @"C:\");
            _deleteAfterExport = LoadSetting("DeleteAfterExport", "0") == "1";

            if (_openedImageByCmd != string.Empty)
            {
                _row = 1;
                _column = 1;
                cbImageOnly.Checked = false;

            }

            _layoutList[(_row - 1) * 4 + _column - 1].Checked = true;

            var tagStringList = LoadSetting("TagList", "");
            if (!string.IsNullOrEmpty(tagStringList))
            {
                var tagList = tagStringList.Split(':');
                for (var i = 0; i < tagList.Length-1; i++)
                {
                    var tag = new ImageTag(tagList[i]);
                    _tagList.Add(tag);
                }

                RefreshTagList();
            }

            
            var taggedImageListString = LoadSetting("TaggedImageList", "");
            if (!string.IsNullOrEmpty(taggedImageListString))
            {
                var taggedImageList = taggedImageListString.Split('*');
                for (var i = 0; i < taggedImageList.Length - 1; i++)
                {
                    var taggedImage = new TaggedImage(taggedImageList[i]);
                    _taggedImageList.Add(taggedImage);
                }
            }

            return ret;
        }

        private void RefreshTagList()
        {
            lbTagList.Items.Clear();
            _tagList.Sort((tag1, tag2) => { return tag1.ShortcutKey.CompareTo(tag2.ShortcutKey); });
            for (var i = 0; i < _tagList.Count - 1; i++)
            {
                lbTagList.Items.Add(_tagList[i].DisplayString());
            }
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
            if (lbSelectedFile.Items.Count > 0)
            {
                if (MessageBox.Show("更改图像目录将清除已选文件，继续吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            var dialog = new FolderBrowserDialog { Description = "请选择文件路径", SelectedPath = tbDir.Text };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            lbSelectedFile.Items.Clear();
            _openedImageByCmd = string.Empty;
            tbDir.Text = dialog.SelectedPath + "\\";
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
                CopyFile(Path.Combine(tbDir.Text, file as string), Path.Combine(_exportDir, file as string));
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
                else
                {
                    var dirList = destFile.Split('\\');
                    var dir = dirList[0];
                    for (var i = 1; i < dirList.Length - 1; i++)
                    {
                        dir += ("\\" + dirList[i]);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }
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
            List<string> commonTagList = null;
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

                    if (_fileList != null && _imageIndex + index < _fileList.Length && _imageIndex + index >= 0)
                    {
                        if (_pictureList[index].ImageLocation != _fileList[_imageIndex + index].FullName)
                        {
                            _pictureList[index].ImageLocation = _fileList[_imageIndex + index].FullName;
                            SetImageTipInfo(_pictureList[index]);
                            var tagList = SetSelectState(_pictureList[index]);
                            if (tagList != null)
                            {
                                commonTagList = GetCommonTagList(commonTagList, tagList);
                            }
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

            SetShowStatus(commonTagList);
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
                var fileName = pictureBox.ImageLocation.Substring(tbDir.Text.Length);
                if (pictureBox.BackColor == System.Drawing.SystemColors.ControlDark)
                {
                    if (!lbSelectedFile.Items.Contains(fileName))
                    {
                        lbSelectedFile.Items.Add(fileName);
                    }
                    pictureBox.BackColor = Color.MediumBlue;
                }
                else
                {
                    lbSelectedFile.Items.Remove(fileName);
                    pictureBox.BackColor = SystemColors.ControlDark;
                }

                RefreshUi();
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

                SetPictureBoxVisible(false);
            }
            else if (mouseE.Button == MouseButtons.Middle)
            {
                Close();
            }
        }

        private void RefreshUi()
        {
            var imageCount = _row * _column;
            List<string> commonTagList = null;
            for (var i = 0; i < imageCount; i++)
            {
                if (_pictureList[i].BackColor == Color.MediumBlue)
                {
                    var fileName1 = _pictureList[i].ImageLocation;
                    if (!string.IsNullOrEmpty(fileName1))
                    {
                        fileName1 = fileName1.Substring(tbDir.Text.Length);
                    }

                    var targetImage = _taggedImageList.Find(taggedImage => taggedImage.ImageName == fileName1);
                    var tagList = (targetImage != null) ? targetImage.TagList.Split(';').ToList() : new List<string>();
                    if (tagList != null)
                    {
                        commonTagList = GetCommonTagList(commonTagList, tagList);
                    }
                }
            }
            SetShowStatus(commonTagList);
        }

        private List<string> GetAllTagIdList()
        {
            var allTagIdList = new List<string>();
            _tagList.ForEach(tag => allTagIdList.Add(tag.Id.ToString()));
            return allTagIdList;
        }

        private bool ShowImage(string imageDir, int currentIndex, bool queryByTag = false)
        {
            if (!Directory.Exists(imageDir))
                return false;

            var root = new DirectoryInfo(imageDir);
            try
            {
                _fileList = root.GetFiles("*.*",
                    cbIncludeSubDir.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            for (var i = 0; i < _row * _column; i++)
            {
                _pictureList[i].ImageLocation = string.Empty;
                SetImageTipInfo(_pictureList[i]);
                SetSelectState(_pictureList[i]);
            }

            _fileList = _fileList.Where(file => file.Name != "ImageViewer.xml").ToArray();

            if (!_fileList.Any())
                return false;

            if (cbImageOnly.Checked)
            {
                var supportedImageFiles = ".png;.bmp;.gif;.jpg;.jpeg".Split(';');
                _fileList = (from fileInfo in _fileList from supportedImageFile in supportedImageFiles where supportedImageFile == fileInfo.Extension.ToLower() select fileInfo).ToArray();
            }
            
            if (_orderBy == 0)
                _fileList = _fileList.OrderBy(x => x.FullName).ToArray();
            else if (_orderBy == 1)
                _fileList = _fileList.OrderBy(x => x.LastWriteTime).ToArray();
            else if (_orderBy == 2)
                _fileList = _fileList.OrderBy(x => x.Length).ToArray();
            else
                _fileList = _fileList.OrderBy(x => x.Extension).ToArray();

            if (string.IsNullOrEmpty(_openedImageByCmd))
                _imageIndex = currentIndex - _row*_column;
            else
                _imageIndex = FindImageIndex(_openedImageByCmd)-2;

            if (queryByTag)
            {
                var tagIdListString = GetCheckedTagIdListString();
                if (!string.IsNullOrEmpty(tagIdListString))
                {
                    var targetFileList = new List<string>();
                    foreach (var taggedImage in _taggedImageList)
                    {
                        if (taggedImage.HasTag(tagIdListString))
                        {
                            targetFileList.Add(taggedImage.ImageName);
                        }
                    }

                    _fileList = _fileList.Where(file =>
                    {
                        var fileName = file.FullName.Substring(tbDir.Text.Length);
                        return targetFileList.FindIndex(targetfile => targetfile == fileName) != -1;
                    }).ToArray();
                }
                else
                {
                    FilterByUntagged();
                }
            }
            else
            {
                FilterByUntagged();
            }

            ShowNextImageOnScreen();
            UpdateTrackBar();

            return true;
        }

        private void FilterByUntagged()
        {
            if (cbOnlyUntagged.Checked)
            {
                _fileList = _fileList.Where(file =>
                {
                    var imageName = file.FullName.Substring(tbDir.Text.Length);
                    return _taggedImageList.FindIndex(taggedImage => taggedImage.ImageName == imageName) == -1;
                }).ToArray();
            }
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

            List<string> commonTagList = null;
            for (var i = 0; i < imageCount; i++)
            {
                _pictureList[i].ImageLocation = _fileList[_imageIndex + i].FullName;

                var image = _pictureList[i];

                SetImageTipInfo(_pictureList[i]);
                var tagList = SetSelectState(_pictureList[i]);
                if (tagList != null)
                {
                    commonTagList = GetCommonTagList(commonTagList, tagList);
                }
            }

            for (var i = imageCount; i < _row * _column; i++)
            {
                _pictureList[i].ImageLocation = string.Empty;
                SetImageTipInfo(_pictureList[i]);
                SetSelectState(_pictureList[i]);
            }

            SetShowStatus(commonTagList);
            trackBarProgress.Value = _imageIndex / (_row * _column);
        }

        private List<string> GetCommonTagList(List<string> commonTagList, List<string> tagList)
        {
            if (commonTagList == null)
            {
                return tagList;
            }

            var newList = new List<string>();
            for (var i = 0; i < commonTagList.Count; i++)
            {
                if (tagList.Contains(commonTagList[i]))
                {
                    newList.Add(commonTagList[i]);
                }
            }

            return newList;
        }

        private void SetShowStatus(List<string> commonTagList)
        {
            if (_fileList == null)
                return;

            btFirstPage.Enabled = _imageIndex > 0;
            btPrevPage.Enabled = btFirstPage.Enabled;
            btNextPage.Enabled = _imageIndex < _fileList.Length - _row * _column;
            btLastPage.Enabled = btNextPage.Enabled;

            lblProgress.Text = string.Format("{0} / {1}", _imageIndex / (_row * _column) + 1, (_fileList.Length - 1) / (_row * _column) + 1);

            btExport.Enabled = btDelete.Enabled = lbSelectedFile.Items.Count > 0;

            if (commonTagList != null &&  commonTagList.Count != 0)
            {
                for (var j = 0; j < lbTagList.Items.Count; j++)
                {
                    var tagName = ParseTagNameFormTagListString(lbTagList.Items[j].ToString());
                    var tagId = _tagList.Find(tag => tag.Name == tagName).Id;
                    var tagFound = commonTagList.FindIndex(tag => tag == tagId.ToString()) != -1;
                    SetTagCheck(j, tagFound);
                    //lbTagList.SetItemChecked(j, tagFound);
                }
            }
            else
            {
                for (var j = 0; j < lbTagList.Items.Count; j++)
                {
                    SetTagCheck(j, false);
                    //lbTagList.SetItemChecked(j, false);
                }
            }

            SetTagButtonStatus();
            SetSelectedCount();
            _lastSelectedIndices = GetCheckedTagIndexList();//lbTagList.SelectedIndices.Cast<int>().ToList();
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
            if (_imageIndex >= 0)
            {
                ShowOneScreen();
            }
        }

        private List<string> SetSelectState(PictureBox pictureBox)
        {
            var fileName = pictureBox.ImageLocation;
            if (!string.IsNullOrEmpty(fileName))
            {
                fileName = fileName.Substring(tbDir.Text.Length);
            }

            if (lbSelectedFile.SelectedItem != null && lbSelectedFile.SelectedItem.ToString() == fileName)
            {
                pictureBox.BackColor = Color.MediumBlue;
                var targetImage = _taggedImageList.Find(taggedImage => taggedImage.ImageName == fileName);
                return (targetImage != null) ? targetImage.TagList.Split(';').ToList() : new List<string>();
            }
            else
            {
                pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            }

            return null;
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

                var tagList = SetSelectState(pictureBoxDetail);
                SetShowStatus(tagList);
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

        private void DoKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (IsAnyPictureSelected())
                {
                    DoUnselectAll();
                }
                else
                {
                    DoSelectAll();
                }
            }
            else
            {
                for (var i = 0; i < lbTagList.Items.Count; i++)
                {
                    var dataList = lbTagList.Items[i].ToString().Split('（');
                    var tagShortcut = dataList[1].Substring(0, 1);
                    var key = (Keys) Enum.Parse(typeof(Keys), tagShortcut, true);
                    if (key == e.KeyCode)
                    {
                        var oldState = lbTagList.GetItemChecked(i);
                        SetTagCheck(i, !oldState);
                        DoTagCheckChanged();
                        break;
                    }
                }
            }
        }

        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            pictureBox.Focus();
        }

        private void lbSelectedFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbSelectedFile.Text))
            {
                EnableShowImage(tbDir.Text + lbSelectedFile.Text);
            }
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
            else
            {
                MessageBox.Show("在当前文件列表中没有这个文件", "定位文件");

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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (MessageBox.Show("需要保存图像浏览记录吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;

            SaveConfig();
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

                SetPictureBoxVisible(true);
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

            var count = lbSelectedFile.Items.Count;
            var selectedFiles = new object[count];
            lbSelectedFile.Items.CopyTo(selectedFiles, 0);

            foreach (var file in selectedFiles)
            {
                try
                {
                    File.Delete(tbDir.Text + (file as string));
                    lbSelectedFile.Items.Remove(file);
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show("删除文件失败！ - " + ex.Message + "\r\n要继续吗？", "错误", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    count--;
                }
            }

            _imageIndex -= count;
            if (_imageIndex < 0)
            {
                _imageIndex = 0;
            }
            ShowImage(tbDir.Text, _imageIndex);
        }

        private void cbImageOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoading)
                return;

            _orderBy = 0;
            ShowImage(tbDir.Text, 0);
        }

        private void rbOrderByTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!_formLoading)
            {
                _orderBy = 1;
                ShowImage(tbDir.Text, 0);
            }
        }

        private void rbOrderBySize_CheckedChanged(object sender, EventArgs e)
        {
            if (!_formLoading)
            {
                _orderBy = 2;
                ShowImage(tbDir.Text, 0);
            }
        }

        private void rbOrderByName_CheckedChanged(object sender, EventArgs e)
        {
            if (!_formLoading)
            {
                _orderBy = 0;
                ShowImage(tbDir.Text, 0);
            }
        }

        private void rbOrderByExt_CheckedChanged(object sender, EventArgs e)
        {
            if (!_formLoading)
            {
                _orderBy = 3;
                ShowImage(tbDir.Text, 0);
            }
        }

        private void WriteShellRunReg()
        {
            var root = Registry.ClassesRoot;
            
            var command = root.CreateSubKey(@"Folder\shell\ImageViewer\command");
            command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");

            command = root.CreateSubKey(@"*\shell\ImageViewer\Command");
            command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
        }

        private void SaveConfig()
        {
            SaveSetting("ImageDir", tbDir.Text);
            SaveSetting("OrderBy", rbOrderByName.Checked ? "0" : rbOrderByTime.Checked ? "1" : "2");
            if (_imageIndex < 0)
                _imageIndex = 0;
            SaveSetting("ImageIndex", _imageIndex.ToString(CultureInfo.InvariantCulture));
            SaveSetting("Row", _row.ToString(CultureInfo.InvariantCulture));
            SaveSetting("Column", _column.ToString(CultureInfo.InvariantCulture));

            var selectedFiles = lbSelectedFile.Items.Cast<object>().Aggregate(string.Empty, (current, item) => current + (item + ";"));
            SaveSetting("SelectedFiles", selectedFiles);

            SaveSetting("IncludeSubDir", cbIncludeSubDir.Checked ? "1" : "0");
            SaveSetting("ImageOnly", cbImageOnly.Checked ? "1" : "0");
            SaveSetting("UntaggedOnly", cbOnlyUntagged.Checked ? "1" : "0");

            SaveSetting("ExportDir", _exportDir);
            SaveSetting("DeleteAfterExport", _deleteAfterExport ? "1" : "0");

            SaveSetting("TagList", GetTagList());
            SaveSetting("TaggedImageList", GetTaggedImageList());

            _config.Save(ConfigurationSaveMode.Minimal);
        }

        private string GetTagList()
        {
            var ret = string.Empty;
            _tagList.ForEach(tag => ret += (tag.ToString() + ":"));
            return ret;
        }

        private string GetTaggedImageList()
        {
            var ret = string.Empty;
            _taggedImageList.ForEach(taggedImage =>
            {
                var value = taggedImage.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    ret += (value + "*");
                }
            });
            return ret;
        }

        private void btClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要全部清除吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lbSelectedFile.Items.Clear();
                SetSelectedCount();
                ShowImage(tbDir.Text, _imageIndex);
            }
        }

        private void SetSelectedCount()
        {
            lblSelectedCount.Text = string.Format("选中 {0} 个图像", lbSelectedFile.Items.Count);
            var enabled = lbSelectedFile.Items.Count > 0;
            btClearAll.Enabled = enabled;
            btExport.Enabled = enabled;
            btDelete.Enabled = enabled;
        }

        private void btAddTag_Click(object sender, EventArgs e)
        {
            var tagForm = new TagFrom
            {
                TagName = string.Empty,
                TagShortcut = string.Empty,
                TagList = _tagList
            };

            if (tagForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            
            var newTag = new ImageTag(tagForm.TagName)
            {
                ShortcutKey = tagForm.TagShortcut, Id = _tagList.Count == 0 ? 1 : _tagList.Max(tag => tag.Id) + 1
            };
            lbTagList.Items.Add(newTag.DisplayString());
            _tagList.Add(newTag);

            RefreshTagList();
        }

        private void btDeleteTag_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除这些标签吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var tagNameList = GetCheckedTagStringList();
            foreach (var tagName in tagNameList)
            {
                foreach (var taggedImage in _taggedImageList)
                {
                    DeleteTagFromImage(taggedImage.ImageName, tagName);
                }

                var deleteTag = _tagList.Find(tag => tag.Name == tagName);
                lbTagList.Items.Remove(deleteTag.DisplayString());
                _tagList.Remove(deleteTag);
            }
        }

        private void btUpdateTag_Click(object sender, EventArgs e)
        {
            var oldTagName = GetCheckedTagStringList()[0];//lbTagList.SelectedItem.ToString();
            var index = _tagList.FindIndex(tag => tag.Name == oldTagName);
            var tagForm = new TagFrom
            {
                TagName = _tagList[index].Name,
                TagShortcut = _tagList[index].ShortcutKey,
                TagList = _tagList
            };

            if (tagForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            _tagList[index].Name = tagForm.TagName;
            _tagList[index].ShortcutKey = tagForm.TagShortcut;
            RefreshTagList();
        }

        private void btQueryByTag_Click(object sender, EventArgs e)
        {
            _ignoreOnlyUntaggedEvent = true;
            cbOnlyUntagged.Checked = false;
            ShowImage(tbDir.Text, 0, true);
            _ignoreOnlyUntaggedEvent = false;
        }

        private void AddTagToImage(string imageName, string tagName)
        {
            var tagId = _tagList.Find(tag => tag.Name == tagName).Id;
            var targetImage = _taggedImageList.Find(taggedImage => taggedImage.ImageName == imageName);
            if (targetImage == null)
            {
                targetImage = new TaggedImage(imageName);
                _taggedImageList.Add(targetImage);
            }
            targetImage.AddTag(tagId);
        }

        private void DeleteTagFromImage(string imageName, string tagName)
        {
            var tagId = _tagList.Find(tag => tag.Name == tagName).Id;
            var targetImage = _taggedImageList.Find(taggedImage => taggedImage.ImageName == imageName);
            targetImage.DeleteTag(tagId);
        }

        private string ParseTagNameFormTagListString(string tagNameAndShortcut)
        {
            return tagNameAndShortcut.Split('（')[0].TrimEnd();
        }

        private string GetSelectedTagName()
        {
            var currentSelectedIndices = GetCheckedTagIndexList();//lbTagList.SelectedIndices.Cast<int>().ToList();
            for (var i = 0; i < _lastSelectedIndices.Count; i++)
            {
                if (_lastSelectedIndices[i] != currentSelectedIndices[i])
                {
                    return ParseTagNameFormTagListString(lbTagList.Items[currentSelectedIndices[i]].ToString());
                }
            }

            return ParseTagNameFormTagListString(lbTagList.Items[currentSelectedIndices[_lastSelectedIndices.Count]].ToString());
        }

        private void SetTagButtonStatus()
        {
            var selectCount = GetCheckedTagIndexList().Count;//lbTagList.SelectedItems.Count;
            btDeleteTag.Enabled = selectCount != 0;
            btUpdateTag.Enabled = selectCount == 1;
        }

        private string GetUnselectedTagName()
        {
            var currentSelectedIndices = GetCheckedTagIndexList();//lbTagList.SelectedIndices.Cast<int>().ToList();
            for (var i = 0; i < currentSelectedIndices.Count; i++)
            {
                if (_lastSelectedIndices[i] != currentSelectedIndices[i])
                {
                    return ParseTagNameFormTagListString(lbTagList.Items[_lastSelectedIndices[i]].ToString());
                }
            }

            return ParseTagNameFormTagListString(lbTagList.Items[_lastSelectedIndices[currentSelectedIndices.Count]].ToString());
        }

        private void lbTagList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (lbTagList.IndexFromPoint(
                    lbTagList.PointToClient(Cursor.Position).X,
                    lbTagList.PointToClient(Cursor.Position).Y) == -1 && !_ignoreCheck)
            {
                e.NewValue = e.CurrentValue;
                return;
            }


        }

        private string GetCheckedTagIdListString()
        {
            var ret = string.Empty;

            for (var i = 0; i < lbTagList.Items.Count; i++)
            {
                if (lbTagList.GetItemChecked(i))
                {
                    var tagName = ParseTagNameFormTagListString(lbTagList.Items[i].ToString());
                    var id = _tagList.Find(tag => tag.Name == tagName).Id;
                    ret += (id + ";");
                }
            }

            return ret;
        }

        private List<string> GetCheckedTagStringList()
        {
            var ret = new List<string>();
            for (var i = 0; i < lbTagList.Items.Count; i++)
            {
                if (lbTagList.GetItemChecked(i))
                {
                    ret.Add(ParseTagNameFormTagListString(lbTagList.Items[i].ToString()));
                }
            }

            return ret;
        }

        private void lbTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoTagCheckChanged();
        }

        private void DoTagCheckChanged()
        {
            SetTagButtonStatus();
            var currentSelectedIndices = lbTagList.CheckedIndices.Cast<int>().ToList(); ;//lbTagList.SelectedIndices.Cast<int>().ToList();

            if (currentSelectedIndices.Count == _lastSelectedIndices.Count)
            {
                return;
            }
            var addNewTag = currentSelectedIndices.Count > _lastSelectedIndices.Count;

            for (var i = 0; i < _row * _column; i++)
            {
                if (_pictureList[i].BackColor != SystemColors.ControlDark)
                {
                    var imageName = _pictureList[i].ImageLocation.Substring(tbDir.Text.Length);
                    if (addNewTag)
                    {
                        AddTagToImage(imageName, GetSelectedTagName());
                    }
                    else
                    {
                        DeleteTagFromImage(imageName, GetUnselectedTagName());
                    }
                }
            }
            _lastSelectedIndices = currentSelectedIndices;
        }

        private List<int> GetCheckedTagIndexList()
        {
            var ret = new List<int>();
            for (var i = 0; i < lbTagList.Items.Count; i++)
            {
                if (lbTagList.GetItemChecked(i))
                {
                    ret.Add(i);
                }
            }

            return ret;
        }

        private void cbOnlyUntagged_CheckedChanged(object sender, EventArgs e)
        {
            if (_formLoading || _ignoreOnlyUntaggedEvent)
                return;

            ShowImage(tbDir.Text, 0);
        }

        private void DoSelectAll()
        {
            for (var i = 0; i < _row * _column; i++)
            {
                if (string.IsNullOrEmpty(_pictureList[i].ImageLocation))
                {
                    break;
                }

                _pictureList[i].BackColor = Color.MediumBlue;
                var fileName = _pictureList[i].ImageLocation.Substring(tbDir.Text.Length);
                if (!lbSelectedFile.Items.Contains(fileName))
                {
                    lbSelectedFile.Items.Add(fileName);
                }
            }

            RefreshUi();
        }

        private bool IsAnyPictureSelected()
        {
            for (var i = 0; i < _row * _column; i++)
            {
                if (_pictureList[i].BackColor == Color.MediumBlue)
                {
                    return true;
                }
            }

            return false;
        }

        private void DoUnselectAll()
        {
            for (var i = 0; i < _row * _column; i++)
            {
                if (string.IsNullOrEmpty(_pictureList[i].ImageLocation))
                {
                    break;
                }

                _pictureList[i].BackColor = SystemColors.ControlDark;
                var fileName = _pictureList[i].ImageLocation.Substring(tbDir.Text.Length);
                lbSelectedFile.Items.Remove(fileName);
            }

            RefreshUi();
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            DoSelectAll();
        }

        private void btUnselectAll_Click(object sender, EventArgs e)
        {
            DoUnselectAll();
        }

        private void ImageVieweForm_KeyDown(object sender, KeyEventArgs e)
        {
            DoKeyDown(e);
        }

        private void SetTagCheck(int j, bool check)
        {
            _ignoreCheck = true;
            lbTagList.SetItemChecked(j, check);
            _ignoreCheck = false;
        }
    }
}
