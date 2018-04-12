using System.Collections.Generic;

namespace FileUi.Domain.Helpers.ProgressBarHelper.Percentage
{
    public interface IPercentageCalculator
    {
        int CalcPercentageProcess<TT>(IEnumerable<TT> listDocs, TT currentDoc);

        int CalcPercentageProcess<TT>(IEnumerable<TT> listDocs, TT currentDoc, int qtdDocs);
    }
}
