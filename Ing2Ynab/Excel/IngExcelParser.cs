using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ing2Ynab.Entities;
using OfficeOpenXml;

namespace Ing2Ynab.Excel
{
    internal class IngExcelParser
    {
        public IEnumerable<IngTransaction> GetIngTransactionsFromExcelFile(string excelFilePath)
        {
            var transactionRows = GetTransactionsTableRows(excelFilePath);

            return BuildTransactionsFromExcelRange(transactionRows);
        }

        private IEnumerable<IngTransaction> BuildTransactionsFromExcelRange(IEnumerable<ExcelRange> transactionsRows)
        {
            return from transactionsRow in transactionsRows let fromRow = transactionsRow.Start.Row select new IngTransaction
                {
                    TransactionDate = DateTime.Parse(transactionsRow[fromRow, 1].Text),
                    Description = transactionsRow[fromRow, 2].Text,
                    Import = decimal.Parse(transactionsRow[fromRow, 3].Text.Replace(",",".")),
                    Category = transactionsRow[fromRow, 6].Text
                };
        }

        private IEnumerable<ExcelRange> GetTransactionsTableRows(string excelFilePath)
        {
            var excelPackage = new ExcelPackage(new FileInfo(excelFilePath));
            var workSheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
            var startingTableCell = workSheet.Cells.FirstOrDefault(c => c.Text.Equals("FECHA VALOR"));

            var startingTableRow = startingTableCell.Start.Row + 1;
            var startingTableColumn = startingTableCell.Start.Column;

            var lastTableRow = workSheet.Dimension.End.Row;
            var lastTableColumn = workSheet.Dimension.End.Column;

            var transactionRows = new List<ExcelRange>();

            for (var ii = startingTableRow; ii < lastTableRow; ii++)
            {
                transactionRows.Add(workSheet.Cells[ii, startingTableColumn, ii, lastTableColumn]);
            }
            return transactionRows;
        }
    }
}
