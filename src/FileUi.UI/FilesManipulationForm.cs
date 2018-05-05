using FileUi.Domain.Helpers;
using FileUi.Domain.Models;
using System;
using System.Windows.Forms;
using FileUi.Domain.Helpers.ProgressBarHelper;

namespace FileUi.UI
{
    public partial class FilesManipulationForm : MetroFramework.Forms.MetroForm
    {
        private ProgressBarForm _progressForm;
        private readonly IFileTransfer _fileTransfer;
        private readonly Settings _settings;

        private int CurrentPercent { get; set; }

        public FilesManipulationForm(IFileTransfer fileTransfer)
        {
            InitializeComponent();

            _fileTransfer = fileTransfer;
            _settings = new Settings();

            SignProgressEvents();
            FormatTransferType();
        }

        #region Messages

        private void ShowMessageSuccess()
        {
            MessageBox.Show("Operação realizada com sucesso", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowMessageError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Events

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                CleanFields();
            }
            catch (Exception ex)
            {

                ShowMessageError(ex);
            }
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            try
            {
                GetSource();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            try
            {
                GetDestPath();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                Transfer();
            }
            catch (Exception ex)
            {
                EndProcess();
                ShowMessageError(ex);
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                _fileTransfer.Pause = !_fileTransfer.Pause;
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _fileTransfer.Stop = true;
                EndProcess();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        #endregion

        #region Controls Manipulation

        private void FillClass(Settings settings)
        {
            settings.CreateSubdirectory = chkCreateFolder.Checked;
            settings.EnumerateFiles = chkEnumerateFiles.Checked;
            settings.CopyFilesInSubfolders = chkCopyFilesInSubfolders.Checked;
            settings.IgnoreDuplicates = chkIgnoreDuplicates.Checked;
            settings.PlaySound = chkReproduceSound.Checked;
            settings.SourcePath = txtSource.Text;
            settings.DestinationPath = txtTarget.Text;
            settings.TranferType = (TransferTypeEnum) cbProcessType.SelectedIndex;
        }

        private void FormatTransferType()
        {
            cbProcessType.DataSource = TransferType.GetTypes();
            cbProcessType.DisplayMember = "Description";
            cbProcessType.ValueMember = "Id";
            cbProcessType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CleanFields()
        {
            txtSource.Text = txtTarget.Text = string.Empty;
            cbProcessType.SelectedValue = (int)TransferTypeEnum.None;
        }

        #endregion

        #region GetPaths

        private void GetSource()
        {
            var type = cbProcessType.SelectedIndex;
            if (type.Equals((int)TransferTypeEnum.Copy) || type.Equals((int)TransferTypeEnum.Move))
                GetSourceFile();
            else
                GetSourceFolder();
        }

        private void GetSourceFile()
        {
            var fileDialog = new OpenFileDialog { Multiselect = false };
            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            txtSource.Text = fileDialog.FileName;
        }

        private void GetSourceFolder()
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() != DialogResult.OK) return;
            txtSource.Text = folderDialog.SelectedPath;
        }

        private void GetDestPath()
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() != DialogResult.OK) return;
            txtTarget.Text = folderDialog.SelectedPath;
        }

        #endregion

        private void Transfer()
        {
            FillClass(_settings);

            if (TransferTypeEnum.None.Equals(_settings.TranferType))
                throw new Exception("Selecione um tipo de transferência");

            _fileTransfer.CopyFile(_settings);
            _fileTransfer.MoveFile(_settings);
            _fileTransfer.CopyAll(_settings);
            _fileTransfer.MoveAll(_settings);
        }

        #region ProgressEvents

        private void SignProgressEvents()
        {
            _fileTransfer.OnStartProcess += _fileTransfer_OnStartProcess;
            _fileTransfer.OnEdnProcess += _fileTransfer_OnEdnProcess;
            _fileTransfer.OnProcess += _fileTransfer_OnProcess;
        }

        private void _progressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CurrentPercent == decimal.Zero) return;

                _fileTransfer.Stop = true;
                EndProcess();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void _fileTransfer_OnStartProcess(object sender, ProcessArgs args)
        {
            try
            {
                _progressForm = new ProgressBarForm();
                _progressForm.FormClosing += _progressForm_FormClosing;
                _progressForm.Show(this);

                Text = args.Description;

                _progressForm.progressBar.Maximum = 100;
                _progressForm.progressBar.Value = args.Percent;
                _progressForm.lbProgress.Text = $"{args.Percent}%";
                _progressForm.PositionChanged();

                Refresh();
            }
            catch (Exception ex)
            {
                _fileTransfer_OnEdnProcess(sender, args);
                ShowMessageError(ex);
            }
        }

        private void _fileTransfer_OnEdnProcess(object sender, ProcessArgs args)
        {
            try
            {
                _progressForm.progressBar.Value = args.Percent;
                _progressForm.lbProgress.Text = $"{args.Percent}%";
                _progressForm.PositionChanged();

                Text = args.Description;

                if (_settings.PlaySound)
                    SoundHelper.StartMusic();

                ShowMessageSuccess();

                CurrentPercent = 0;
                Refresh();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void _fileTransfer_OnProcess(object sender, ProcessArgs args)
        {
            try
            {
                if (!args.ShowPressBar) return;
                
                if (args.Percent > 0)
                    CurrentPercent = args.Percent;

                _progressForm.progressBar.Value = CurrentPercent;
                _progressForm.lbProgress.Text = $"{CurrentPercent}% - {args.ItemDescription}";
                _progressForm.PositionChanged();

                Refresh();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void EndProcess()
        {
            _progressForm.progressBar.Value = CurrentPercent = 0;
            _progressForm.lbProgress.Text = "0%";
            _progressForm.PositionChanged();
            _progressForm.Close();

            Text = "FileUI - Manipulação de Arquivos";
            
            Refresh();
        }

        #endregion
    }
}
