using System;
using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal class CategoryTransformationRule : IYnabTransformationRule
    {
        private readonly string _sourceCategory;
        private readonly string _targetCategory;

        public CategoryTransformationRule(string sourceCategory, string targetCategory)
        {
            _sourceCategory = sourceCategory;
            _targetCategory = targetCategory;
        }

        public YnabTransaction Transform(YnabTransaction ynabTransaction)
        {
            ynabTransaction.Category.Replace(_sourceCategory, _targetCategory);
            return ynabTransaction;
        }
    }
}
