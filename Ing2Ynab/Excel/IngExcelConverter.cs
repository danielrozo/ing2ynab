using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.OpenXml4Net.OPC;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using System.IO;
using OfficeOpenXml;

namespace Ing2Ynab.Excel
{
    internal class IngExcelConverter
    {
        public string ConvertToXlsx(string xlsPath)
        {
            var oldWorkbook = new HSSFWorkbook(new FileStream(xlsPath, FileMode.Open));
            var oldWorkSheet = oldWorkbook.GetSheetAt(0);
            var newExcelPath = xlsPath.Replace("xls", "xlsx");
            var excelPackage = new ExcelPackage(new FileInfo(newExcelPath));
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            foreach (HSSFRow oldRow in oldWorkSheet)
            {
                workSheet.InsertRow(oldRow.RowNum + 1, 1);

                for (int ii = oldRow.FirstCellNum; ii < oldRow.Cells.Count - 1; ii++)
                {
                    workSheet.Cells[oldRow.RowNum + 1, ii + 1].Value = oldRow.Cells[ii].StringCellValue;
                }
            }
            excelPackage.Save();

            return newExcelPath;
        }
    }
}
