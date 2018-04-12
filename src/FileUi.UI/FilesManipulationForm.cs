﻿using FileUi.Domain.Helpers;
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

namespace FileUi.UI
{
    public partial class FilesManipulationForm : MetroFramework.Forms.MetroForm
    {
        private IFileTransfer _fileTransfer;
        private Settings _settings;

        public FilesManipulationForm(IFileTransfer fileTransfer)
        {
            InitializeComponent();
            _fileTransfer = fileTransfer;
            _settings = new Settings();
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

        private void FillControls(Settings settings)
        {

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
    }
}