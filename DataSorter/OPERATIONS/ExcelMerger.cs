using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataSorter
{
    public static class ExcelMerger
    {
        public static void MergeExcelFiles(string[] filePaths, string outputFilePath)
        {
            if (filePaths == null || filePaths.Length == 0)
            {
                MessageBox.Show("No files selected for merging.");
                return;
            }

            try
            {
                // Create a new Excel package for the output file
                using (var package = new ExcelPackage())
                {
                    // Create a worksheet in the output file
                    var worksheet = package.Workbook.Worksheets.Add("MergedData");

                    int rowIndex = 1;
                    bool isTitleRowAdded = false;

                    foreach (string filePath in filePaths)
                    {
                        // Open each input Excel file
                        using (var inputPackage = new ExcelPackage(new FileInfo(filePath)))
                        {
                            var inputWorksheet = inputPackage.Workbook.Worksheets.First();
                            int lastRow = inputWorksheet.Dimension.End.Row;
                            int lastColumn = inputWorksheet.Dimension.End.Column;

                            // Read the title row and add it only once
                            if (!isTitleRowAdded)
                            {
                                // Copy the title row to the output worksheet
                                for (int col = 1; col <= lastColumn; col++)
                                {
                                    worksheet.Cells[rowIndex, col].Value = inputWorksheet.Cells[1, col].Value;
                                }
                                rowIndex++;
                                isTitleRowAdded = true;
                            }

                            // Read each row from the input worksheet (excluding the title row) and write to the output worksheet
                            for (int row = 2; row <= lastRow; row++)
                            {
                                for (int col = 1; col <= lastColumn; col++)
                                {
                                    worksheet.Cells[rowIndex, col].Value = inputWorksheet.Cells[row, col].Value;
                                }
                                rowIndex++;
                            }
                        }
                    }

                    // Save the merged data to the output file
                    FileInfo outputFile = new FileInfo(outputFilePath);
                    package.SaveAs(outputFile);

                    MessageBox.Show($"Files merged successfully into {outputFilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while merging files: {ex.Message}");
            }
        }
    }
}
