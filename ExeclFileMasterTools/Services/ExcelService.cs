using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMasterTools.Services
{
    public class ExcelService
    {
        public void ReadExcelFile(string filePath)
        {
            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            // Open the Excel file
            FileInfo fileInfo = new FileInfo(filePath);
            using (var package = new ExcelPackage(fileInfo))
            {
                // Access the first worksheet
                var worksheet = package.Workbook.Worksheets[0];

                // Get the number of rows and columns
                var rowCount = worksheet.Dimension.Rows;
                var colCount = worksheet.Dimension.Columns;

                // Loop through rows and columns
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        var cellValue = worksheet.Cells[row, col].Text; 
                        Console.WriteLine($"Row {row}, Column {col}: {cellValue}");
                    }
                }
            }
        }
    }
}
