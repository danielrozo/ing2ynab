using System.Collections.Generic;
using System.Linq;
using Ing2Ynab.Entities;

namespace Ing2Ynab.Converters
{
    internal class IngToYnabTransactionConverter
    {
        private readonly IIngDescriptionToYnabPayeeConverter _payeeConverter;

        public IngToYnabTransactionConverter(IIngDescriptionToYnabPayeeConverter payeeConverter)
        {
            _payeeConverter = payeeConverter;
        }

        public IEnumerable<YnabTransaction> ConvertToYnabTransactions(IEnumerable<IngTransaction> ingTransactions)
        {
            return ingTransactions.Select(ing =>
                {
                    var ynabTransaction = new YnabTransaction
                        {
                            TransactionDate = ing.TransactionDate,
                            Category = ing.Category,
                            Cleared = true,
                            Memo = ing.Description,
                            Account = "Ing day to day"
                        };
                    if (ing.Import > 0)
                        ynabTransaction.Inflow = ing.Import;
                    else
                        ynabTransaction.Outflow = ing.Import;

                    ynabTransaction.Payee = _payeeConverter.ConvertToPayee(ing.Description);

                    return ynabTransaction;
                });
        }
    }
}
