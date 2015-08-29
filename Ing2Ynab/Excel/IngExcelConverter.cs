using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.OpenXml4Net.OPC;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using System.IO;

namespace Ing2Ynab.Excel
{
    internal class IngExcelConverter
    {
        public string ConvertToXlsx(string xlsPath)
        {
            var hssfWorkbook = new HSSFWorkbook(new FileStream(xlsPath, FileMode.Open));
            var firstWorksheet = hssfWorkbook.GetSheetAt(0);
            var newExcelPath = xlsPath.Replace("xls", "xlsx");
            using (var fileStream = new FileStream(newExcelPath, FileMode.Create))
            {
                var xssfWorkBook = new XSSFWorkbook();
                var xSSFSheet = new XSSFSheet();
                xssfWorkBook.Add(xSSFSheet);
                foreach (HSSFRow row in firstWorksheet)
                {
                    var newRow = xssfWorkBook.GetSheetAt(0).CreateRow(row.RowNum);
                    newRow.RowStyle = xssfWorkBook.CreateCellStyle();
                    for (int ii = 0; ii < row.Cells.Count; ii++)
                    {
                        var newCell = newRow.CreateCell(row.GetCell(ii).ColumnIndex);
                        newCell = row.Cells[ii];
                    }
                }

                xssfWorkBook.Write(fileStream);
            }

            return newExcelPath;
        }
    }
}
