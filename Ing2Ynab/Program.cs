using Ing2Ynab.Converters;
using Ing2Ynab.YnabTransformation;
using Ing2Ynab.Csv;
using Ing2Ynab.Excel;

namespace Ing2Ynab
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new IngExcelParser().GetIngTransactionsFromExcelFile(@"E:\Ing\report.xlsx");
            var conversionRules = new IngToYnabTransformationRulesBuilder().BuildConversionRules();
            var ynabTransactions = 
                new IngToYnabTransactionConverter(new YnabTransactionsTransformer(conversionRules))
                .ConvertToYnabTransactions(transactions);
            new CsvWriter().WriteCsv(ynabTransactions, @"E:\Ing\report.csv");
            
        }
    }
}
