using Microsoft.VisualBasic.FileIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelFileHandler.Services
{
    public class ExcelOrganizer
    {
        private class StudentEntry
        {
            public string Name { get; set; }
            public string WhatsAppNumber { get; set; }
            public string Grade { get; set; }
            public string Medium { get; set; }
            public DateTime? Timestamp { get; set; }

            public string GetUniqueKey()
            {
                return $"{Name}|{WhatsAppNumber}|{Grade}|{Medium}";
            }
        }

        private string CleanNameValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            // Remove specific special characters
            string cleaned = value.Replace(",", " ")
                                .Replace("/", " ")
                                .Replace("?", " ")
                                .Replace("_", " ")
                                .Replace("-", " ")
                                .Replace(".", " ")
                                .Replace(";", " ");

            // Remove any extra spaces and trim
            cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

            return cleaned;
        }

        public void OrganizeExcelData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select an Excel file first.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (!Path.GetExtension(filePath).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Unsupported file format. Please select an Excel file.");
                return;
            }

            string outputFileName = Path.GetFileNameWithoutExtension(filePath) + "_organized_data.xlsx";
            string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), outputFileName);

            // Dictionary to store the latest data for each unique combination
            Dictionary<string, StudentEntry> entries = new Dictionary<string, StudentEntry>();
            Dictionary<string, Dictionary<string, HashSet<string>>> studentGradesAndMediums =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            // Read the Excel file
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.First();
                Dictionary<string, StudentEntry> tempEntries = new Dictionary<string, StudentEntry>();

                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    string entityName = worksheet.Cells[row, 1].Value?.ToString().Trim() ?? "";
                    string value = worksheet.Cells[row, 2].Value?.ToString().Trim() ?? "";
                    string whatsappNumber = worksheet.Cells[row, 3].Value?.ToString().Trim() ?? "";

                    DateTime? timestamp = null;
                    if (worksheet.Dimension.End.Column >= 4)
                    {
                        var timestampCell = worksheet.Cells[row, 4].Value;
                        if (timestampCell != null)
                        {
                            if (timestampCell is DateTime dt)
                                timestamp = dt;
                            else if (DateTime.TryParse(timestampCell.ToString(), out DateTime parsedDt))
                                timestamp = parsedDt;
                        }
                    }

                    string key = whatsappNumber;

                    if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    {
                        value = CleanNameValue(value);
                        if (!tempEntries.ContainsKey(key))
                        {
                            tempEntries[key] = new StudentEntry
                            {
                                Name = value,
                                WhatsAppNumber = whatsappNumber,
                                Timestamp = timestamp
                            };
                        }
                        else
                        {
                            tempEntries[key].Name = value;
                            if (timestamp > tempEntries[key].Timestamp)
                                tempEntries[key].Timestamp = timestamp;
                        }
                    }
                    else if (entityName.Equals("Grade", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!tempEntries.ContainsKey(key))
                        {
                            tempEntries[key] = new StudentEntry
                            {
                                WhatsAppNumber = whatsappNumber,
                                Grade = value,
                                Timestamp = timestamp
                            };
                        }
                        else
                        {
                            // Store grade for this WhatsApp number
                            if (!studentGradesAndMediums.ContainsKey(whatsappNumber))
                            {
                                studentGradesAndMediums[whatsappNumber] = new Dictionary<string, HashSet<string>>();
                            }
                            if (!studentGradesAndMediums[whatsappNumber].ContainsKey(value))
                            {
                                studentGradesAndMediums[whatsappNumber][value] = new HashSet<string>();
                            }
                        }
                    }
                    else if (entityName.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!tempEntries.ContainsKey(key))
                        {
                            tempEntries[key] = new StudentEntry
                            {
                                WhatsAppNumber = whatsappNumber,
                                Medium = value,
                                Timestamp = timestamp
                            };
                        }
                        else
                        {
                            // Store medium for the current grade if exists
                            if (studentGradesAndMediums.ContainsKey(whatsappNumber))
                            {
                                foreach (var gradeSet in studentGradesAndMediums[whatsappNumber].Values)
                                {
                                    gradeSet.Add(value);
                                }
                            }
                        }
                    }
                }

                // Create final entries for each unique combination
                List<StudentEntry> finalEntries = new List<StudentEntry>();
                foreach (var entry in tempEntries.Values.Where(e => !string.IsNullOrEmpty(e.Name)))
                {
                    if (studentGradesAndMediums.ContainsKey(entry.WhatsAppNumber))
                    {
                        foreach (var gradeKvp in studentGradesAndMediums[entry.WhatsAppNumber])
                        {
                            string grade = gradeKvp.Key;
                            foreach (var medium in gradeKvp.Value)
                            {
                                finalEntries.Add(new StudentEntry
                                {
                                    Name = entry.Name,
                                    WhatsAppNumber = entry.WhatsAppNumber,
                                    Grade = grade,
                                    Medium = medium,
                                    Timestamp = entry.Timestamp
                                });
                            }
                        }
                    }
                    else
                    {
                        finalEntries.Add(entry);
                    }
                }

                // Remove exact duplicates while preserving multiple grades/mediums
                var uniqueEntries = finalEntries
                    .GroupBy(e => e.GetUniqueKey())
                    .Select(g => g.OrderByDescending(e => e.Timestamp).First())
                    .ToList();

                // Save organized data
                try
                {
                    using (var newPackage = new ExcelPackage(new FileInfo(outputFilePath)))
                    {
                        var newWorksheet = newPackage.Workbook.Worksheets.Add("Organized Data");

                        // Add headers
                        newWorksheet.Cells[1, 1].Value = "Name";
                        newWorksheet.Cells[1, 2].Value = "WhatsApp";
                        newWorksheet.Cells[1, 3].Value = "Grade";
                        newWorksheet.Cells[1, 4].Value = "Medium";

                        // Style headers
                        var headerRange = newWorksheet.Cells[1, 1, 1, 4];
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                        // Write data
                        int row = 2;
                        foreach (var entry in uniqueEntries.OrderBy(e => e.Name))
                        {
                            newWorksheet.Cells[row, 1].Value = entry.Name;
                            newWorksheet.Cells[row, 2].Value = entry.WhatsAppNumber;
                            newWorksheet.Cells[row, 3].Value = entry.Grade;
                            newWorksheet.Cells[row, 4].Value = entry.Medium;
                            row++;
                        }

                        newWorksheet.Cells[newWorksheet.Dimension.Address].AutoFitColumns();
                        newPackage.Save();
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
}