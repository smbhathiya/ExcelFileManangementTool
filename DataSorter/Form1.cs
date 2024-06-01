using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index
            openFileDialog1.Filter = "CSV Files|*.csv|All Files|*.*";
            openFileDialog1.FilterIndex = 1;

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
                MessageBox.Show("Please select a CSV file first.");
                return;
            }

            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(txtFilePath.Text);

            // Initialize dictionaries to store names, grades, and mediums
            Dictionary<string, string> names = new Dictionary<string, string>();
            Dictionary<string, string> grades = new Dictionary<string, string>();
            Dictionary<string, string> mediums = new Dictionary<string, string>();

            // Parse each line of the CSV file and extract names, grades, and mediums
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

                // Check if entityName is "Name", "Grade", or "Medium" and store the value accordingly
                if (entityName.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    names[whatsappNumber] = value;
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

            // Create a list to store the sorted data
            List<string> sortedData = new List<string>();
            sortedData.Add("Name,WhatsApp Number,Grade,Medium");

            // Use names dictionary as the base for sorting
            foreach (var pair in names)
            {
                string whatsappNumber = pair.Key;
                string name = pair.Value;
                string grade = grades.ContainsKey(whatsappNumber) ? grades[whatsappNumber] : "-";
                string medium = mediums.ContainsKey(whatsappNumber) ? mediums[whatsappNumber] : "-";

                sortedData.Add($"{name},{whatsappNumber},{grade},{medium}");
            }

            // Save sorted data to a new CSV file
            string outputPath = Path.Combine(Path.GetDirectoryName(txtFilePath.Text), "sorted_data.csv");
            File.WriteAllLines(outputPath, sortedData);

            MessageBox.Show("Sorting completed. Sorted data saved to sorted_data.csv");
        }



    }

}

