using System;
using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal class CategoryTransformationRule : IYnabTransformationRule
    {
        public string SourceCategory { get; set; }
        public string TargetCategory { get; set; }

        public YnabTransaction Transform(YnabTransaction ynabTransaction)
        {
            ynabTransaction.Category = ynabTransaction.Category.Replace(SourceCategory, TargetCategory);
            return ynabTransaction;
        }
    }
}
