using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMasterTools.Services
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
                        var line = string.Join(",", worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column].Select(c => c.Text));
                        lines.Add(line);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Unsupported file format. Please select a CSV or Excel file.");
            }

            // Initialize dictionaries to store names, grades, mediums, and other information
            Dictionary<string, List<string>> names = new Dictionary<string, List<string>>();
            Dictionary<string, string> grades = new Dictionary<string, string>();
            Dictionary<string, string> mediums = new Dictionary<string, string>();
            Dictionary<string, string> courses = new Dictionary<string, string>();

            // HashSet to keep track of unique names
            HashSet<string> uniqueNames = new HashSet<string>();

            // Parse each line of the file and extract names, grades, mediums, and courses
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                {
                    continue; // Skip lines with insufficient data
                }

                string entityName = parts[0].Trim();
                string value = parts[1].Trim();
                string whatsappNumber = parts[2].Trim();

                // Check if entityName is "Name", "Grade", "Medium", or "Course" and store the value accordingly
                if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    if (uniqueNames.Contains(value)) continue;

                    uniqueNames.Add(value); // Add the name to the set of unique names

                    if (!names.ContainsKey(value))
                    {
                        names[value] = new List<string>();
                    }
                    names[value].Add(whatsappNumber);
                }
                else if (entityName.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                {
                    grades[whatsappNumber] = value;
                }
                else if (entityName.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                {
                    mediums[whatsappNumber] = value;
                }
                else if (entityName.Equals("Course", StringComparison.OrdinalIgnoreCase))
                {
                    courses[whatsappNumber] = value;
                }
            }

            // Create a new list to store the organized data
            List<string> sortedData = new List<string>();
            sortedData.Add("Name,WhatsApp Number,Grade,Medium,Course");

            // Use the names dictionary as the base for sorting
            foreach (var pair in names)
            {
                string name = pair.Key;
                List<string> whatsappNumbers = pair.Value;
                foreach (string whatsappNumber in whatsappNumbers)
                {
                    string grade = grades.ContainsKey(whatsappNumber) ? grades[whatsappNumber] : "-";
                    string medium = mediums.ContainsKey(whatsappNumber) ? mediums[whatsappNumber] : "-";
                    string course = courses.ContainsKey(whatsappNumber) ? courses[whatsappNumber] : "-";

                    sortedData.Add($"{name},{whatsappNumber},{grade},{medium},{course}");
                }
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
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "WhatsApp Number";
                    worksheet.Cells[1, 3].Value = "Grade";
                    worksheet.Cells[1, 4].Value = "Medium";
                    worksheet.Cells[1, 5].Value = "Course";

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

                    // Save the new Excel file
                    package.Save();
                }
            }

            // Show success message
            Console.WriteLine($"Sorting completed. Organized data saved to {newFilePath}");
        }
    }
}
