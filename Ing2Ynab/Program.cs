using Ing2Ynab.Converters;
using Ing2Ynab.YnabTransformation;
using Ing2Ynab.Csv;
using Ing2Ynab.Excel;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace Ing2Ynab
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in GetIngExcelFiles())
            {
                var convertedExcelFile = new IngExcelConverter().ConvertToXlsx(file);
                var transactions = new IngExcelParser().GetIngTransactionsFromExcelFile(convertedExcelFile);
                File.Delete(convertedExcelFile);
                var conversionRules = new YnabTransformationRulesBuilder().BuildConversionRules();
                var ynabTransactions =
                    new IngToYnabTransactionConverter(new YnabTransactionsTransformer(conversionRules))
                    .ConvertToYnabTransactions(transactions);
                new CsvWriter().WriteCsv(ynabTransactions, GetOutputFilePath(convertedExcelFile));
            }
        }

        private static string GetOutputFilePath(string convertedExcelFile)
        {
            return convertedExcelFile.Replace(GetInputFolder(), GetInputFolder() + "\\CSV").Replace(".xlsx", ".csv");
        }

        private static IEnumerable<string> GetIngExcelFiles()
        {
            return Directory.GetFiles(GetInputFolder()).Where(file => file.EndsWith("xls"));
        }

        private static string GetInputFolder()
        {
            return ConfigurationManager.AppSettings.Get("InputFolder");
        }
    }
}
