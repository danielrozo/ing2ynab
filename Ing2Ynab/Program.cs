using Ing2Ynab.Converters;
using Ing2Ynab.Csv;
using Ing2Ynab.Excel;

namespace Ing2Ynab
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new IngExcelParser().GetIngTransactionsFromExcelFile(@"E:\Ing\report.xlsx");
            var ynabTransactions = new IngToYnabTransactionConverter(new IngDescriptionToYnabPayeeConverter()).ConvertToYnabTransactions(transactions);
            new CsvWriter().WriteCsv(ynabTransactions, @"E:\Ing\report.csv");
            
        }
    }
}
