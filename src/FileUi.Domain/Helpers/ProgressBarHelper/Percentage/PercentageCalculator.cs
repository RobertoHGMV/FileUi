using System.Collections.Generic;
using System.Linq;

namespace FileUi.Domain.Helpers.ProgressBarHelper.Percentage
{
    public class PercentageCalculator : IPercentageCalculator
    {
        public int CalcPercentageProcess<TT>(IEnumerable<TT> listDocs, TT currentDoc)
        {
            var list = listDocs.ToList();
            var rowNumber = list.IndexOf(currentDoc) + 1;
            var percent = rowNumber * 100 / list.Count;
            return percent;
        }

        public int CalcPercentageProcess<TT>(IEnumerable<TT> listDocs, TT currentDoc, int qtdDocs)
        {
            var list = listDocs.ToList();
            var rowNumber = list.IndexOf(currentDoc) + 1;
            var percent = rowNumber * 100 / qtdDocs;
            return percent;
        }
    }
}
