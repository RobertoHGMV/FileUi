using FileUi.Domain.Helpers.ProgressBarHelper;
using FileUi.Domain.Models;

namespace FileUi.Domain.Interfaces
{
    public interface IFileTransfer
    {
        event OnProcessHandle OnProcess;
        event OnProcessHandle OnStartProcess;
        event OnProcessHandle OnEdnProcess;

        void CopyFile(Settings settings);

        void CopyAll(Settings settings);

        void MoveFile(Settings settings);

        void MoveAll(Settings settings);
    }
}
