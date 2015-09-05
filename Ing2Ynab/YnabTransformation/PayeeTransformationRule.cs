using System;
using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal class PayeeTransformationRule : IYnabTransformationRule
    {
        public string SourcePayee;
        public string TargetPayee;

        public YnabTransaction Transform(YnabTransaction ynabTransaction)
        {
            ynabTransaction.Payee = ynabTransaction.Payee.Replace(SourcePayee, TargetPayee);
            return ynabTransaction;
        }
    }
}
