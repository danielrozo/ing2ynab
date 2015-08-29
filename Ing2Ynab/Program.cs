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
            var convertedExcelFile = new IngExcelConverter().ConvertToXlsx(@"C:\Users\DRozoXPS13\Downloads\Movimientos_CuentaNOMINA_19082015.xls");
            var transactions = new IngExcelParser().GetIngTransactionsFromExcelFile(convertedExcelFile);
            var conversionRules = new YnabTransformationRulesBuilder().BuildConversionRules();
            var ynabTransactions = 
                new IngToYnabTransactionConverter(new YnabTransactionsTransformer(conversionRules))
                .ConvertToYnabTransactions(transactions);
            new CsvWriter().WriteCsv(ynabTransactions, @"E:\Ing\report.csv");
            
        }
    }
}
