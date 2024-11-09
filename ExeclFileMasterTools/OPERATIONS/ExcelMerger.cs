using OfficeOpenXml;
using System;
using System.Collections.Generic;
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
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("MergedData");
                    int rowIndex = 1;
                    bool isTitleRowAdded = false;

                    var recordTracker = new Dictionary<string, List<int>>();

                    foreach (string filePath in filePaths)
                    {
                        using (var inputPackage = new ExcelPackage(new FileInfo(filePath)))
                        {
                            var inputWorksheet = inputPackage.Workbook.Worksheets.FirstOrDefault();

                            // Ensure the worksheet exists and has data
                            if (inputWorksheet == null || inputWorksheet.Dimension == null)
                            {
                                MessageBox.Show($"The worksheet in file {filePath} is empty or could not be found.");
                                continue;
                            }

                            int lastRow = inputWorksheet.Dimension.End.Row;
                            int lastColumn = inputWorksheet.Dimension.End.Column;

                            if (lastRow < 1 || lastColumn < 1)
                            {
                                MessageBox.Show($"The worksheet in file {filePath} does not contain any data.");
                                continue;
                            }

                            if (!isTitleRowAdded)
                            {
                                for (int col = 1; col <= lastColumn; col++)
                                {
                                    worksheet.Cells[rowIndex, col].Value = inputWorksheet.Cells[1, col].Value;
                                }
                                rowIndex++;
                                isTitleRowAdded = true;
                            }

                            for (int row = 2; row <= lastRow; row++)
                            {
                                var record = string.Join(",", Enumerable.Range(1, lastColumn)
                                    .Select(col => inputWorksheet.Cells[row, col].Text));

                                for (int col = 1; col <= lastColumn; col++)
                                {
                                    worksheet.Cells[rowIndex, col].Value = inputWorksheet.Cells[row, col].Value;
                                }

                                if (recordTracker.ContainsKey(record))
                                {
                                    recordTracker[record].Add(rowIndex);
                                }
                                else
                                {
                                    recordTracker[record] = new List<int> { rowIndex };
                                }

                                rowIndex++;
                            }
                        }
                    }

                    foreach (var entry in recordTracker)
                    {
                        if (entry.Value.Count > 1)
                        {
                            foreach (var index in entry.Value.Skip(1))
                            {
                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    worksheet.Cells[index, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[index, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                }
                            }
                        }
                    }

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
