using FileUi.Domain.Helpers;
using FileUi.Domain.Interfaces;
using FileUi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileUi.Domain.Helpers.ProgressBarHelper;

namespace FileUi.UI
{
    public partial class FilesManipulationForm : MetroFramework.Forms.MetroForm
    {
        private readonly IFileTransfer _fileTransfer;
        private readonly Settings _settings;

        public FilesManipulationForm(IFileTransfer fileTransfer)
        {
            InitializeComponent();
            FormatControls();
            _fileTransfer = fileTransfer;
            _settings = new Settings();
            FormatTransferType();
        }

        private void SignProgressEvents()
        {
            _fileTransfer.OnStartProcess += _fileTransfer_OnStartProcess;
            _fileTransfer.OnEdnProcess += _fileTransfer_OnEdnProcess;
            _fileTransfer.OnProcess += _fileTransfer_OnProcess;
        }

        private void FormatControls()
        {
            progressBar.Visible = lbProgress.Visible = false;
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
                ShowMessageError(ex);
            }
        }

        private void FillClass(Settings settings)
        {
            settings.CreateSubdirectory = chkCreateFolder.Checked;
            settings.EnumerateFiles = chkEnumerateFiles.Checked;
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

        private void Transfer()
        {
            FillClass(_settings);
            _fileTransfer.CopyFile(_settings);
            _fileTransfer.MoveFile(_settings);
            _fileTransfer.CopyAll(_settings);
            _fileTransfer.MoveAll(_settings);

            if (_settings.PlaySound)
                SoundHelper.StartMusic();

            ShowMessageSuccess();
        }

        #region ProgressEvents

        private void _fileTransfer_OnStartProcess(object sender, ProcessArgs args)
        {
            try
            {
                Text = args.Description;
                Refresh();
                progressBar.Maximum = 100;
                progressBar.Visible = lbProgress.Visible = args.ShowPressBar;
                progressBar.Value = args.Percent;
                lbProgress.Text = $"{args.Percent}%";
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
                progressBar.Value = args.Percent;
                lbProgress.Text = $"{args.Percent}%";

                ShowMessageSuccess();

                progressBar.Visible = lbProgress.Visible = !args.ShowPressBar;
                Text = args.Description;
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

                progressBar.Visible = lbProgress.Visible = args.ShowPressBar;
                progressBar.Value = args.Percent;
                lbProgress.Text = $"{args.Percent}%";
            }
            catch (Exception ex)
            {
                _fileTransfer_OnEdnProcess(sender, args);
                ShowMessageError(ex);
            }
        }

        #endregion
    }
}
