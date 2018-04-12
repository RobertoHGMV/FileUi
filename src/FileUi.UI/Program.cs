using FileUi.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileUi.Domain.Helpers.ProgressBarHelper.Percentage;

namespace FileUi.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FilesManipulationForm(new FileTransfer(new PercentageCalculator())));
        }
    }
}
