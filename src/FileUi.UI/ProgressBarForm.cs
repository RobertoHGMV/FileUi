using System.Windows.Forms;

namespace FileUi.UI
{
    public partial class ProgressBarForm : MetroFramework.Forms.MetroForm
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        public void PositionChanged()
        {
            Application.DoEvents();
        }
    }
}
