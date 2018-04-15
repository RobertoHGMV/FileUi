using FileUi.Domain.Helpers.ProgressBarHelper;
using FileUi.Domain.Models;

namespace FileUi.Domain.Helpers
{
    public interface IFileTransfer
    {
        event OnProcessHandle OnProcess;
        event OnProcessHandle OnStartProcess;
        event OnProcessHandle OnEdnProcess;

        bool Pause { get; set; }
        bool Stop { get; set; }

        void CopyFile(Settings settings);

        void CopyAll(Settings settings);

        void MoveFile(Settings settings);

        void MoveAll(Settings settings);
    }
}
