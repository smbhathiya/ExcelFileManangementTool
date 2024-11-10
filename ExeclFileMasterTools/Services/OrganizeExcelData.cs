using ExcelFileHandler.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelFileHandler.Services
{
    public class ExcelOrganizer
    {
        public void OrganizeExcelData(string filePath)
        {
            // Dictionary to store data with the WhatsApp number as the key
            var studentRecords = new Dictionary<string, StudentRecord>();

            // Check the file extension to determine if it's a CSV or Excel file
            if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.First();
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Skip header row
                    {
                        // Get values from columns A (key) and B (value)
                        string key = worksheet.Cells[row, 1].Text.Trim();
                        string value = worksheet.Cells[row, 2].Text.Trim();

                        // Check if the key is "Name", "Grade", or "Medium" and process accordingly
                        if (key.Equals("Name", StringComparison.OrdinalIgnoreCase))
                        {
                            var record = new StudentRecord { Name = value, Grade = "-", Medium = "-" };
                            studentRecords[value] = record;
                        }
                        else if (key.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                        {
                            if (studentRecords.ContainsKey(value))
                                studentRecords[value].Grade = value;
                            else
                                studentRecords[value] = new StudentRecord { Name = "-", Grade = value, Medium = "-" };
                        }
                        else if (key.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                        {
                            if (studentRecords.ContainsKey(value))
                                studentRecords[value].Medium = value;
                            else
                                studentRecords[value] = new StudentRecord { Name = "-", Grade = "-", Medium = value };
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Unsupported file format. Please select an Excel (.xlsx) file.");
            }

            // Prepare sorted data
            var sortedData = new List<string> { "Name,Grade,Medium" };
            sortedData.AddRange(studentRecords.Values
                .OrderBy(r => r.Name)
                .Select(r => $"{r.Name},{r.Grade},{r.Medium}"));

            // Create a new file to save the organized data
            string directory = Path.GetDirectoryName(filePath);
            string newFileName = "organized_" + Path.GetFileName(filePath);
            string newFilePath = Path.Combine(directory, newFileName);

            using (var package = new ExcelPackage(new FileInfo(newFilePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("OrganizedData");

                // Write headers
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Grade";
                worksheet.Cells[1, 3].Value = "Medium";

                // Write the sorted data starting from row 2 (after headers)
                int rowIndex = 2;
                foreach (var entry in studentRecords.Values.OrderBy(r => r.Name))
                {
                    worksheet.Cells[rowIndex, 1].Value = entry.Name;
                    worksheet.Cells[rowIndex, 2].Value = entry.Grade;
                    worksheet.Cells[rowIndex, 3].Value = entry.Medium;
                    rowIndex++;
                }

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save the new Excel file
                package.Save();
            }

            Console.WriteLine($"Sorting completed. Organized data saved to {newFilePath}");
        }
    }

    public class StudentRecord
    {
        public string Name { get; set; } = "-";
        public string Grade { get; set; } = "-";
        public string Medium { get; set; } = "-";
    }
}
