using ExcelFileHandler.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFileHandler.Services
{
    public class ExcelOrganizer
    {
        public void OrganizeExcelData(string filePath)
        {
            List<string> lines = new List<string>();

            // Check the file extension to determine whether it's a CSV or Excel file
            if (Path.GetExtension(filePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                // Read all lines from the CSV file with UTF-8 encoding
                lines = File.ReadAllLines(filePath, Encoding.UTF8).ToList();
            }
            else if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                // Read all lines from the Excel file using EPPlus
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.First();
                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var line = string.Join(",", worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column]
                            .Select(c => (c.Text ?? "").Replace(",", "")));
                        lines.Add(line);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Unsupported file format. Please select a CSV or Excel file.");
            }

            // Create a class to hold the student data
            var studentRecords = new HashSet<StudentRecord>(new StudentRecordComparer());

            // Parse each line of the file and extract information
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                {
                    continue; // Skip lines with insufficient data
                }

                string entityName = parts[0].Trim();
                string value = parts[1].Trim();
                string whatsappNumber = NormalizeWhatsAppNumber(parts[2].Trim());

                if (string.IsNullOrWhiteSpace(value) || value.Equals("-"))
                {
                    value = "-";
                }

                // Find or create the student record
                if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    var record = new StudentRecord { Name = value, WhatsAppNumber = whatsappNumber };
                    studentRecords.Add(record);
                }
                else
                {
                    var existingRecord = studentRecords.FirstOrDefault(r => r.WhatsAppNumber == whatsappNumber);
                    if (existingRecord != null)
                    {
                        if (entityName.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                            existingRecord.Grade = value;
                        else if (entityName.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                            existingRecord.Medium = value;
                        else if (entityName.Equals("Course", StringComparison.OrdinalIgnoreCase))
                            existingRecord.Course = value;
                    }
                }
            }

            // Create a new list to store the organized data
            List<string> sortedData = new List<string>();
            sortedData.Add("Name,WhatsApp Number,Grade,Medium,Course");

            // Sort the records by name and add them to sortedData
            foreach (var record in studentRecords.OrderBy(r => r.Name))
            {
                sortedData.Add($"{record.Name},{record.WhatsAppNumber},{record.Grade},{record.Medium},{record.Course}");
            }

            // Save the organized data to a new file
            string directory = Path.GetDirectoryName(filePath);
            string newFileName = "organized_" + Path.GetFileName(filePath);
            string newFilePath = Path.Combine(directory, newFileName);

            if (filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                // For CSV files, save them as CSV
                File.WriteAllLines(newFilePath, sortedData, Encoding.UTF8);
            }
            else
            {
                // For Excel files, create a new Excel file using EPPlus
                using (var package = new ExcelPackage(new FileInfo(newFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("OrganizedData");

                    // Write the headers
                    string[] headers = { "Name", "WhatsApp Number", "Grade", "Medium", "Course" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                    }

                    // Write the sorted data
                    int rowIndex = 2; // Start from row 2 (after headers)
                    foreach (var entry in sortedData.Skip(1)) // Skip the headers
                    {
                        var values = entry.Split(',');
                        for (int col = 0; col < values.Length; col++)
                        {
                            worksheet.Cells[rowIndex, col + 1].Value = values[col];
                        }
                        rowIndex++;
                    }

                    // Auto-fit columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the new Excel file
                    package.Save();
                }
            }

            Console.WriteLine($"Sorting completed. Organized data saved to {newFilePath}");
        }

        private string NormalizeWhatsAppNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return "-";

            // Remove any non-digit characters
            number = new string(number.Where(char.IsDigit).ToArray());

            // If the number is empty after cleaning, return "-"
            if (string.IsNullOrEmpty(number))
                return "-";

            // Ensure the number starts with the country code
            if (!number.StartsWith("91") && number.Length == 10)
            {
                number = "91" + number;
            }

            return number;
        }
    }

    public class StudentRecordComparer : IEqualityComparer<StudentRecord>
    {
        public bool Equals(StudentRecord x, StudentRecord y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return x.Name == y.Name &&
                   x.WhatsAppNumber == y.WhatsAppNumber &&
                   x.Course == y.Course;
        }

        public int GetHashCode(StudentRecord obj)
        {
            var hash = new HashCode();
            hash.Add(obj.Name);
            hash.Add(obj.WhatsAppNumber);
            hash.Add(obj.Course);
            return hash.ToHashCode();
        }
    }
}