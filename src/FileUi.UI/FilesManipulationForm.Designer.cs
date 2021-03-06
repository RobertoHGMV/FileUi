﻿namespace FileUi.UI
{
    partial class FilesManipulationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesManipulationForm));
            this.cmdOk = new MetroFramework.Controls.MetroButton();
            this.chkCreateFolder = new MetroFramework.Controls.MetroCheckBox();
            this.chkEnumerateFiles = new MetroFramework.Controls.MetroCheckBox();
            this.chkIgnoreDuplicates = new MetroFramework.Controls.MetroCheckBox();
            this.chkReproduceSound = new MetroFramework.Controls.MetroCheckBox();
            this.txtSource = new MetroFramework.Controls.MetroTextBox();
            this.txtTarget = new MetroFramework.Controls.MetroTextBox();
            this.btnSource = new MetroFramework.Controls.MetroButton();
            this.btnTarget = new MetroFramework.Controls.MetroButton();
            this.cbProcessType = new MetroFramework.Controls.MetroComboBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.btnTransfer = new MetroFramework.Controls.MetroButton();
            this.chkCopyFilesInSubfolders = new MetroFramework.Controls.MetroCheckBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.btnPause = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdOk.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.cmdOk.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.cmdOk.Location = new System.Drawing.Point(33, 363);
            this.cmdOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(112, 41);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseSelectable = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // chkCreateFolder
            // 
            this.chkCreateFolder.AutoSize = true;
            this.chkCreateFolder.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkCreateFolder.Location = new System.Drawing.Point(33, 114);
            this.chkCreateFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCreateFolder.Name = "chkCreateFolder";
            this.chkCreateFolder.Size = new System.Drawing.Size(174, 25);
            this.chkCreateFolder.TabIndex = 1;
            this.chkCreateFolder.Text = "Criar subdiretórios";
            this.metroToolTip1.SetToolTip(this.chkCreateFolder, "Cria uma pasta para cada arquivo transferido");
            this.chkCreateFolder.UseSelectable = true;
            // 
            // chkEnumerateFiles
            // 
            this.chkEnumerateFiles.AutoSize = true;
            this.chkEnumerateFiles.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkEnumerateFiles.Location = new System.Drawing.Point(218, 114);
            this.chkEnumerateFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnumerateFiles.Name = "chkEnumerateFiles";
            this.chkEnumerateFiles.Size = new System.Drawing.Size(132, 25);
            this.chkEnumerateFiles.TabIndex = 2;
            this.chkEnumerateFiles.Text = "Numerar arq.";
            this.metroToolTip1.SetToolTip(this.chkEnumerateFiles, "Realiza a enumeração dos arquivos Ex: 01");
            this.chkEnumerateFiles.UseSelectable = true;
            // 
            // chkIgnoreDuplicates
            // 
            this.chkIgnoreDuplicates.AutoSize = true;
            this.chkIgnoreDuplicates.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkIgnoreDuplicates.Location = new System.Drawing.Point(609, 114);
            this.chkIgnoreDuplicates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIgnoreDuplicates.Name = "chkIgnoreDuplicates";
            this.chkIgnoreDuplicates.Size = new System.Drawing.Size(178, 25);
            this.chkIgnoreDuplicates.TabIndex = 3;
            this.chkIgnoreDuplicates.Text = "Ignorar duplicados";
            this.metroToolTip1.SetToolTip(this.chkIgnoreDuplicates, "Substitui arquivo caso já exista na pasta de destino");
            this.chkIgnoreDuplicates.UseSelectable = true;
            // 
            // chkReproduceSound
            // 
            this.chkReproduceSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReproduceSound.AutoSize = true;
            this.chkReproduceSound.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkReproduceSound.Location = new System.Drawing.Point(423, 371);
            this.chkReproduceSound.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkReproduceSound.Name = "chkReproduceSound";
            this.chkReproduceSound.Size = new System.Drawing.Size(363, 25);
            this.chkReproduceSound.TabIndex = 4;
            this.chkReproduceSound.Text = "Reproduzir alerta ao terminar transferência";
            this.metroToolTip1.SetToolTip(this.chkReproduceSound, "Reproduz alerta ao final da transferência");
            this.chkReproduceSound.UseSelectable = true;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSource.CustomButton.Image = null;
            this.txtSource.CustomButton.Location = new System.Drawing.Point(595, 1);
            this.txtSource.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSource.CustomButton.Name = "";
            this.txtSource.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtSource.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSource.CustomButton.TabIndex = 1;
            this.txtSource.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSource.CustomButton.UseSelectable = true;
            this.txtSource.CustomButton.Visible = false;
            this.txtSource.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSource.Lines = new string[0];
            this.txtSource.Location = new System.Drawing.Point(33, 205);
            this.txtSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSource.MaxLength = 32767;
            this.txtSource.Name = "txtSource";
            this.txtSource.PasswordChar = '\0';
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSource.SelectedText = "";
            this.txtSource.SelectionLength = 0;
            this.txtSource.SelectionStart = 0;
            this.txtSource.ShortcutsEnabled = true;
            this.txtSource.Size = new System.Drawing.Size(629, 35);
            this.txtSource.TabIndex = 5;
            this.txtSource.UseSelectable = true;
            this.txtSource.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSource.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTarget.CustomButton.Image = null;
            this.txtTarget.CustomButton.Location = new System.Drawing.Point(595, 1);
            this.txtTarget.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTarget.CustomButton.Name = "";
            this.txtTarget.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtTarget.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTarget.CustomButton.TabIndex = 1;
            this.txtTarget.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTarget.CustomButton.UseSelectable = true;
            this.txtTarget.CustomButton.Visible = false;
            this.txtTarget.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtTarget.Lines = new string[0];
            this.txtTarget.Location = new System.Drawing.Point(33, 252);
            this.txtTarget.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTarget.MaxLength = 32767;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.PasswordChar = '\0';
            this.txtTarget.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTarget.SelectedText = "";
            this.txtTarget.SelectionLength = 0;
            this.txtTarget.SelectionStart = 0;
            this.txtTarget.ShortcutsEnabled = true;
            this.txtTarget.Size = new System.Drawing.Size(629, 35);
            this.txtTarget.TabIndex = 6;
            this.txtTarget.UseSelectable = true;
            this.txtTarget.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTarget.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSource
            // 
            this.btnSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSource.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSource.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnSource.Location = new System.Drawing.Point(675, 203);
            this.btnSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(112, 41);
            this.btnSource.TabIndex = 7;
            this.btnSource.Text = "Origem";
            this.metroToolTip1.SetToolTip(this.btnSource, "Definir pasta/arquivo de origem");
            this.btnSource.UseSelectable = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnTarget
            // 
            this.btnTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTarget.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnTarget.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnTarget.Location = new System.Drawing.Point(674, 251);
            this.btnTarget.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(112, 41);
            this.btnTarget.TabIndex = 8;
            this.btnTarget.Text = "Destino";
            this.metroToolTip1.SetToolTip(this.btnTarget, "Definir pasta de destino");
            this.btnTarget.UseSelectable = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // cbProcessType
            // 
            this.cbProcessType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProcessType.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.cbProcessType.FormattingEnabled = true;
            this.cbProcessType.ItemHeight = 29;
            this.cbProcessType.Location = new System.Drawing.Point(33, 158);
            this.cbProcessType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbProcessType.Name = "cbProcessType";
            this.cbProcessType.Size = new System.Drawing.Size(626, 35);
            this.cbProcessType.TabIndex = 9;
            this.metroToolTip1.SetToolTip(this.cbProcessType, "Tipo de transferência");
            this.cbProcessType.UseSelectable = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnClear.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnClear.Location = new System.Drawing.Point(675, 155);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 41);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Limpar";
            this.metroToolTip1.SetToolTip(this.btnClear, "Limpar campos");
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnTransfer.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnTransfer.Location = new System.Drawing.Point(675, 299);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(112, 41);
            this.btnTransfer.TabIndex = 14;
            this.btnTransfer.Text = "Transferir";
            this.metroToolTip1.SetToolTip(this.btnTransfer, "Transferir arquivos");
            this.btnTransfer.UseSelectable = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // chkCopyFilesInSubfolders
            // 
            this.chkCopyFilesInSubfolders.AutoSize = true;
            this.chkCopyFilesInSubfolders.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkCopyFilesInSubfolders.Location = new System.Drawing.Point(362, 114);
            this.chkCopyFilesInSubfolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCopyFilesInSubfolders.Name = "chkCopyFilesInSubfolders";
            this.chkCopyFilesInSubfolders.Size = new System.Drawing.Size(230, 25);
            this.chkCopyFilesInSubfolders.TabIndex = 15;
            this.chkCopyFilesInSubfolders.Text = "Copiar arq. em subpastas";
            this.metroToolTip1.SetToolTip(this.chkCopyFilesInSubfolders, "Copia arquivos que se encontram em subpastas");
            this.chkCopyFilesInSubfolders.UseSelectable = true;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPause.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnPause.Location = new System.Drawing.Point(153, 363);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(112, 41);
            this.btnPause.TabIndex = 16;
            this.btnPause.Text = "Pausar";
            this.metroToolTip1.SetToolTip(this.btnPause, "Transferir arquivos");
            this.btnPause.UseSelectable = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // FilesManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 440);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.chkCopyFilesInSubfolders);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbProcessType);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.chkReproduceSound);
            this.Controls.Add(this.chkIgnoreDuplicates);
            this.Controls.Add(this.chkEnumerateFiles);
            this.Controls.Add(this.chkCreateFolder);
            this.Controls.Add(this.cmdOk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(822, 440);
            this.Name = "FilesManipulationForm";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Text = "FileUI - Manipulação de Arquivos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton cmdOk;
        private MetroFramework.Controls.MetroCheckBox chkCreateFolder;
        private MetroFramework.Controls.MetroCheckBox chkEnumerateFiles;
        private MetroFramework.Controls.MetroCheckBox chkIgnoreDuplicates;
        private MetroFramework.Controls.MetroCheckBox chkReproduceSound;
        private MetroFramework.Controls.MetroTextBox txtSource;
        private MetroFramework.Controls.MetroTextBox txtTarget;
        private MetroFramework.Controls.MetroButton btnSource;
        private MetroFramework.Controls.MetroButton btnTarget;
        private MetroFramework.Controls.MetroComboBox cbProcessType;
        private MetroFramework.Controls.MetroButton btnClear;
        private MetroFramework.Controls.MetroButton btnTransfer;
        private MetroFramework.Controls.MetroCheckBox chkCopyFilesInSubfolders;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroButton btnPause;
    }
}

