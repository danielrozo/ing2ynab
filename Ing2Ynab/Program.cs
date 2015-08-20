using System;
using Ing2Ynab.Converters;
using Ing2Ynab.Excel;

namespace Ing2Ynab
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new IngExcelParser().GetIngTransactionsFromExcelFile(@"E:\Ing\report.xlsx");
            var ynabTransactions = new IngToYnabTransactionConverter(new IngDescriptionToYnabPayeeConverter()).ConvertToYnabTransactions(transactions);
            Console.WriteLine(ynabTransactions);
        }
    }
}
