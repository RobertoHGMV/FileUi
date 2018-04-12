namespace FileUi.Domain.Helpers.ProgressBarHelper
{
    public delegate void OnProcessHandle(object sender, ProcessArgs args);

    public class ProcessArgs
    {
        public ProcessArgs(int percent, string description, string itemDescription, bool showProgressBar)
        {
            Percent = percent;
            Description = description;
            ItemDescription = itemDescription;
            ShowPressBar = showProgressBar;
        }

        public int Percent { get; set; }

        public string Description { get; set; }

        public string ItemDescription { get; set; }

        public bool ShowPressBar { get; set; }
    }
}
