using FileUi.Domain.Models;

namespace FileUi.Domain.Interfaces
{
    public interface IFileTransfer
    {
        void CopyFile(Settings settings);

        void CopyAll(Settings settings);

        void MoveFile(Settings settings);

        void MoveAll(Settings settings);
    }
}
