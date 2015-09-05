using System.Collections.Generic;
using System.Linq;
using Ing2Ynab.Entities;
using Ing2Ynab.YnabTransformation;

namespace Ing2Ynab.Converters
{
    internal class IngToYnabTransactionConverter
    {
        private readonly YnabTransactionsTransformer _transactionConverter;

        public IngToYnabTransactionConverter(YnabTransactionsTransformer transactionConverter)
        {
            _transactionConverter = transactionConverter;
        }

        public IEnumerable<YnabTransaction> ConvertToYnabTransactions(IEnumerable<IngTransaction> ingTransactions)
        {
            return ingTransactions.Select(ing =>
                {
                    var ynabTransaction = new YnabTransaction
                        {
                            Date = ing.TransactionDate,
                            Category = ing.Category,
                            Memo = ing.Description,
                            Account = "Ing day to day",
                            Payee = ing.Description
                        };
                    if (ing.Import > 0)
                        ynabTransaction.Inflow = ing.Import;
                    else
                        ynabTransaction.Outflow = ing.Import * -1;

                    ynabTransaction = _transactionConverter.Transform(ynabTransaction);

                    return ynabTransaction;
                });
        }
    }
}
