using ExcelFileHandler.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelFileHandler.Services
{
    public class ExcelOrganizer
    {
        public void OrganizeExcelData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a CSV or Excel file first.");
                return;
            }

            // Set EPPlus license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string originalFileName = Path.GetFileNameWithoutExtension(filePath);
            string outputFileName = originalFileName + "_organized_data.xlsx";  // Changed to .xlsx
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), outputFileName);

            List<string> lines = new List<string>();

            if (Path.GetExtension(filePath).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                // Read CSV and ensure WhatsApp numbers are treated as text (as strings)
                lines = File.ReadAllLines(filePath, Encoding.UTF8).ToList();
            }
            else if (Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.First();

                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var rowData = new List<string>();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            // Use the raw value (not Text) to prevent scientific notation issue
                            var cellValue = worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;

                            // If it's the WhatsApp number column, prepend with apostrophe
                            if (col == 3)  // Assuming WhatsApp numbers are in the 3rd column
                            {
                                // Prepend a single quote (') to ensure Excel treats it as text
                                cellValue = "'" + cellValue;
                            }

                            rowData.Add(cellValue);

                            // Debugging: Log the value of WhatsApp numbers
                            if (col == 3)  // Log only the WhatsApp column
                            {
                                Console.WriteLine($"Row {row}, WhatsApp: {cellValue}");
                            }
                        }
                        var line = string.Join(",", rowData);
                        lines.Add(line);
                    }
                }
            }
            else
            {
                MessageBox.Show("Unsupported file format. Please select a CSV or Excel file.");
                return;
            }

            Dictionary<string, List<string>> names = new Dictionary<string, List<string>>();
            Dictionary<string, string> grades = new Dictionary<string, string>();
            Dictionary<string, string> mediums = new Dictionary<string, string>();
            HashSet<string> uniqueNames = new HashSet<string>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length < 3)
                {
                    MessageBox.Show($"Skipping line: {line}. It does not have enough parts.");
                    continue;
                }

                string entityName = parts[0].Trim();
                string value = parts[1].Trim();
                string whatsappNumber = parts[2].Trim().Trim('"').Replace("=", "").Replace("\"", "");  

                // Ensure the WhatsApp number is treated as text
                whatsappNumber = whatsappNumber.Trim();

                if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    if (uniqueNames.Contains(value))
                    {
                        continue;
                    }

                    uniqueNames.Add(value);

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
            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(outputFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Organized Data");

                    // Add headers
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Grade";
                    worksheet.Cells[1, 3].Value = "Medium";
                    worksheet.Cells[1, 4].Value = "WhatsApp";

                    // Style headers
                    var headerRange = worksheet.Cells[1, 1, 1, 4];
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                    int row = 2;
                    foreach (var name in names)
                    {
                        foreach (var whatsapp in name.Value)
                        {
                            worksheet.Cells[row, 1].Value = name.Key;
                            worksheet.Cells[row, 2].Value = grades.ContainsKey(whatsapp) ? grades[whatsapp] : "";
                            worksheet.Cells[row, 3].Value = mediums.ContainsKey(whatsapp) ? mediums[whatsapp] : "";

                            var whatsappCell = worksheet.Cells[row, 4];
                            whatsappCell.Value = whatsapp;

                            row++;
                        }
                    }

                    // Auto-fit columns
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the Excel file
                    package.Save();
                }

                MessageBox.Show($"Data organized successfully and saved to {outputFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving the file: {ex.Message}");
            }
        }
    }
}
