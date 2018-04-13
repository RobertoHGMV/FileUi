using FileUi.Domain.Models;
using System;
using System.IO;
using FileUi.Domain.Helpers.ProgressBarHelper;
using FileUi.Domain.Helpers.ProgressBarHelper.Percentage;

namespace FileUi.Domain.Helpers
{
    public class FileTransfer : IFileTransfer
    {
        public event OnProcessHandle OnProcess;
        public event OnProcessHandle OnStartProcess;
        public event OnProcessHandle OnEdnProcess;

        private readonly IPercentageCalculator _percentageCalculator;
        private const string Title = "FileUI - Manipulação de Arquivos";

        private string DestFile { get; set; }

        public FileTransfer(IPercentageCalculator percentageCalculator)
        {
            _percentageCalculator = percentageCalculator;
        }

        #region Copy

        public void CopyFile(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.Copy) return;

            SetOnStartProcess("Copiando arquivo", false);
            ValidatePath(settings);

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var fileName = Path.GetFileName(settings.SourcePath);
            fileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, 1);
            DestFile = Path.Combine(settings.DestinationPath, fileName);

            CreateSubdirectory(settings, fileName);

            File.Copy(settings.SourcePath, DestFile, settings.IgnoreDuplicates);
            SetOnEndProcess(Title, false);
        }

        public void CopyAll(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.CopyAll) return;

            SetOnStartProcess("Copiando arquivos");
            ValidatePaths(settings);

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            //var files = Directory.GetFiles(settings.SourcePath, "*.*", SearchOption.AllDirectories);
            var directories = GetDirectories(settings);
            var count = 1;
            foreach (var directory in directories)
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    SeOnProcess(0, fileName);

                    var sourceFile = Path.Combine(directory, fileName);
                    var newFileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, count);
                    DestFile = Path.Combine(settings.DestinationPath, newFileName);

                    CreateSubdirectory(settings, newFileName);

                    File.Copy(sourceFile, DestFile, settings.IgnoreDuplicates);
                    var percent = _percentageCalculator.CalcPercentageProcess(files, file);
                    SeOnProcess(percent, fileName);
                    count++;
                }
            }

            SetOnEndProcess(Title);
        }

        #endregion

        #region Move

        public void MoveFile(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.Move) return;

            SetOnStartProcess("Movendo arquivo", false);
            ValidatePath(settings);

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var fileName = Path.GetFileName(settings.SourcePath);
            fileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, 1);
            DestFile = Path.Combine(settings.DestinationPath, fileName);

            CreateSubdirectory(settings, fileName);

            File.Move(settings.SourcePath, DestFile);
            SetOnEndProcess(Title, false);
        }

        public void MoveAll(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.MoveAll) return;

            SetOnStartProcess("Movendo arquivos");
            ValidatePaths(settings);

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var directories = GetDirectories(settings);
            var count = 1;
            foreach (var directory in directories)
            {
                var files = Directory.GetFiles(settings.SourcePath);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    SeOnProcess(0, fileName);

                    var sourceFile = Path.Combine(directory, fileName);
                    var newFileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, count);
                    DestFile = Path.Combine(settings.DestinationPath, newFileName);

                    CreateSubdirectory(settings, newFileName);

                    File.Move(sourceFile, DestFile);
                    var percent = _percentageCalculator.CalcPercentageProcess(files, file);
                    SeOnProcess(percent, fileName);
                    count++;
                }
            }

            SetOnEndProcess(Title);
        }

        #endregion

        private void CreateSubdirectory(Settings settings, string fileName)
        {
            if (settings.CreateSubdirectory)
            {
                //var fileWhitoutExtension = Path.GetFileNameWithoutExtension(settings.SourcePath);
                var newDirectory = Path.Combine(settings.DestinationPath, fileName);

                Directory.CreateDirectory(newDirectory);
                DestFile = Path.Combine(newDirectory, fileName);
            }
        }

        private string SetEnumerateFileName(bool enumerate, string fileName, int count)
        {
            if (enumerate)
                return count < 10 ? $"0{count}.{fileName}" : $"{count}.{fileName}";

            return fileName;
        }

        private string[] GetDirectories(Settings settings)
        {
            var directories = Directory.GetDirectories(settings.SourcePath);

            return !settings.CopyFilesInSubfolders && directories.Length > decimal.Zero 
                ? directories 
                : new[] { settings.SourcePath };
        }

        #region Validates

        private void ValidatePath(Settings settings)
        {
            if (!File.Exists(settings.SourcePath))
                throw new Exception("Arquivo não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");
        }

        private void ValidatePaths(Settings settings)
        {
            if (!Directory.Exists(settings.SourcePath))
                throw new Exception("Diretório de origem não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");
        }

        #endregion

        #region ProgressEvents

        public void SetOnStartProcess(string description, bool showProgressBar = true)
        {
            OnStartProcess?.Invoke(this, new ProcessArgs(0, description, "", showProgressBar));
        }

        public void SetOnEndProcess(string description, bool showProgress = true)
        {
            OnEdnProcess?.Invoke(this, new ProcessArgs(100, description, "", showProgress));
        }

        public void SeOnProcess(int percent, string itemDescription, bool showProgress = true)
        {
            OnProcess?.Invoke(this, new ProcessArgs(percent, "", itemDescription, showProgress));
        }

        #endregion
    }
}
