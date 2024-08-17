using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;

namespace DataSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpload.Region = null;

            btnSort.Region = null;

            filesselectbtn.Region = null;

            mergebtn.Region = null;
        }


        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index
            openFileDialog1.Filter = "Excel Files|*.xlsx|All Files|*.*";
            openFileDialog1.FilterIndex = 2;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                // Assign the selected file path to the txtFilePath variable
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnSort_Click_1(object sender, EventArgs e)
        {
            // Check if a file path has been provided
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select a CSV or Excel file first.");
                return;
            }

            string originalFileName = Path.GetFileNameWithoutExtension(txtFilePath.Text);
            string outputFileName = originalFileName + "_organized_data.csv"; // Appending "_organized_data.csv" to the original file name

            List<string> lines = new List<string>();

            // Determine the file type and read the content
            if (Path.GetExtension(txtFilePath.Text).Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                // Read all lines from the CSV file with UTF-8 encoding
                lines = File.ReadAllLines(txtFilePath.Text, Encoding.UTF8).ToList();
            }
            else if (Path.GetExtension(txtFilePath.Text).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                // Read all lines from the Excel file using EPPlus
                using (var package = new ExcelPackage(new FileInfo(txtFilePath.Text)))
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
                MessageBox.Show("Unsupported file format. Please select a CSV or Excel file.");
                return;
            }

            // Initialize dictionaries to store names, grades, mediums, and courses
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
                    MessageBox.Show($"Skipping line: {line}. It does not have enough parts.");
                    continue;
                }

                string entityName = parts[0].Trim();
                string value = parts[1].Trim();
                string whatsappNumber = parts[2].Trim();

                // Check if entityName is "Name", "Grade", "Medium", or "Course" and store the value accordingly
                if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    // Skip if the name is already encountered
                    if (uniqueNames.Contains(value))
                    {
                        continue;
                    }

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

            // Create a list to store the sorted data
            List<string> sortedData = new List<string>();
            sortedData.Add("Name,WhatsApp Number,Grade,Medium,Course");

            // Use names dictionary as the base for sorting
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

            // Save sorted data to a new CSV file with UTF-8 encoding
            string outputPath = Path.Combine(Path.GetDirectoryName(txtFilePath.Text), outputFileName);
            File.WriteAllLines(outputPath, sortedData, Encoding.UTF8);

            MessageBox.Show($"Sorting completed. Sorted data saved to {outputFileName}");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] selectedFiles = FileSelector.SelectExcelFiles();

            if (selectedFiles != null && selectedFiles.Length > 0)
            {
                textBox1.Text = string.Join(";", selectedFiles);
            }
            else
            {
                MessageBox.Show("No files selected.");
            }
        }

        private void mergebtn_Click(object sender, EventArgs e)
        {
            string[] selectedFiles = textBox1.Text.Split(';');

            if (selectedFiles.Length > 0 && !string.IsNullOrEmpty(selectedFiles[0]))
            {
                // Define the path for the output file
                string outputFilePath = Path.Combine(Path.GetDirectoryName(selectedFiles[0]), "MergedOutput.xlsx");

                // Call the ExcelMerger to merge files
                ExcelMerger.MergeExcelFiles(selectedFiles, outputFilePath);
            }
            else
            {
                MessageBox.Show("Please select files first.");
            }
        }
    }

}

