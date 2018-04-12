using FileUi.Domain.Interfaces;
using FileUi.Domain.Models;
using System;
using System.IO;

namespace FileUi.Domain.Helpers
{
    public class FileTransfer : IFileTransfer
    {
        private string DestFile { get; set; }

        public void CopyFile(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.Copy) return;

            if (!File.Exists(settings.SourcePath))
                throw new Exception("Arquivo não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var fileName = Path.GetFileName(settings.SourcePath);
            fileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, 1);
            DestFile = Path.Combine(settings.DestinationPath);

            CreateSubdirectory(settings, fileName);

            File.Copy(settings.SourcePath, DestFile, settings.IgnoreDuplicates);
        }

        public void CopyAll(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.CopyAll) return;

            if (!Directory.Exists(settings.SourcePath))
                throw new Exception("Diretório de origem não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var files = Directory.GetFiles(settings.SourcePath);

            var count = 1;
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var newFileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, count);
                DestFile = Path.Combine(settings.DestinationPath, newFileName);
                var sourceFile = Path.Combine(settings.SourcePath, fileName);

                CreateSubdirectory(settings, newFileName);

                File.Copy(sourceFile, DestFile, settings.IgnoreDuplicates);
                count++;
            }
        }

        public void MoveFile(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.Move) return;

            if (!File.Exists(settings.SourcePath))
                throw new Exception("Arquivo não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var fileName = Path.GetFileName(settings.SourcePath);
            fileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, 1);
            DestFile = Path.Combine(settings.DestinationPath, fileName);

            CreateSubdirectory(settings, fileName);

            File.Move(settings.SourcePath, DestFile);
        }

        public void MoveAll(Settings settings)
        {
            if (settings.TranferType != TransferTypeEnum.MoveAll) return;

            if (!Directory.Exists(settings.SourcePath))
                throw new Exception("Diretório de origem não encontrado");

            if (string.IsNullOrEmpty(settings.DestinationPath))
                throw new Exception("Pasta de destino não informada");

            if (!Directory.Exists(settings.DestinationPath))
                Directory.CreateDirectory(settings.DestinationPath);

            var files = Directory.GetFiles(settings.SourcePath);

            var count = 1;
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var newFileName = SetEnumerateFileName(settings.EnumerateFiles, fileName, count);
                DestFile = Path.Combine(settings.DestinationPath, newFileName);
                var sourceFile = Path.Combine(settings.SourcePath, fileName);

                CreateSubdirectory(settings, newFileName);

                File.Move(sourceFile, DestFile);
                count++;
            }
        }

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
                return count < 10 ? $"0{count}.{fileName}" : $"{count.ToString()}.{fileName}";

            return fileName;
        }
    }
}
