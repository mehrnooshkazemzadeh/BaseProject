using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;

namespace BaseProject.Tools
{
   public class ExcelManager
    {
        public string FileName { get; set; }
        private IWorksheet worksheet;
        public IWorksheet GetSheet(string fileName, int sheetNumber)
        {
            var excelEngine = new ExcelEngine();
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                var workbook = excelEngine.Excel.Workbooks.Open(stream);
                worksheet = workbook.Worksheets[sheetNumber];
            }
            return worksheet;
        }

        public IEnumerable<string> GetColumns(string fileName, int sheetNumber)
        {
            var sheet = GetSheet(fileName,  sheetNumber);
            return sheet.Rows.Select(x => x.DisplayText).ToList();
        }

        public IEnumerable<string> GetColumns()
        {
            var sheet = GetSheet(FileName, 0);
            return sheet.Rows[0].Select(x => x.DisplayText).ToList();
        }
        public IEnumerable<string> GetRowData(int columnIndex,string columnHeader=null , bool includeHeader=false)
        {
            if (worksheet == null)
            {
                return null;
            }
            return worksheet.Columns[columnIndex].Where(x => includeHeader || x.DisplayText != columnHeader).Select(x =>x.DisplayText.TrimEnd().TrimStart()).ToList();
        }
    }
}
