namespace FileUi.Domain.Models
{
    public class Settings
    {
        public bool CreateSubdirectory { get; set; }
        public bool EnumerateFiles { get; set; }
        public bool IgnoreDuplicates { get; set; }
        public bool PlaySound { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public TransferTypeEnum TranferType { get; set; }
    }
}
