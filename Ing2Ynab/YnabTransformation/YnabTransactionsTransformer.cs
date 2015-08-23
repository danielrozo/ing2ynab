using System.Collections.Generic;
using Ing2Ynab.Entities;

namespace Ing2Ynab.YnabTransformation
{
    internal class YnabTransactionsTransformer
    {
        private readonly IEnumerable<IYnabTransformationRule> _conversionRules;

        public YnabTransactionsTransformer(IEnumerable<IYnabTransformationRule> conversionRules)
        {
            _conversionRules = conversionRules;
        }

        public YnabTransaction Transform(YnabTransaction transaction)
        {
            int indexOf = transaction.Payee.IndexOf('(') == -1 ? transaction.Payee.Length : transaction.Payee.IndexOf('(');
            transaction.Payee = transaction.Payee.Substring(0, indexOf);

            foreach(var conversionRule in _conversionRules)
            {
                transaction = conversionRule.Transform(transaction);
            }

            return transaction;
        }
    }
}
