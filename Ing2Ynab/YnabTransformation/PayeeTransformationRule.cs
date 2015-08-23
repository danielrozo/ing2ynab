using System;
using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal class PayeeTransformationRule : IYnabTransformationRule
    {
        private readonly string _sourcePayee;
        private readonly string _targetPayee;

        public PayeeTransformationRule(string sourcePayee, string targetPayee)
        {
            _sourcePayee = sourcePayee;
            _targetPayee = targetPayee;
        }

        public YnabTransaction Transform(YnabTransaction ynabTransaction)
        {
            ynabTransaction.Payee.Replace(_sourcePayee, _targetPayee);
            return ynabTransaction;
        }
    }
}
