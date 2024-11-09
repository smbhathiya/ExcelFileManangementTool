using ExcelFileHandler.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFileHandler.Views
{
    public partial class FileHandlerUserControl : UserControl
    {
        // Declare a list to store the file paths
        private List<string> selectedFilePaths = new List<string>();

        public FileHandlerUserControl()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    string fileNameOnly = Path.GetFileName(fileName);
                    if (!lstSelectedFiles.Items.Contains(fileNameOnly))
                    {
                        lstSelectedFiles.Items.Add(fileNameOnly);
                        selectedFilePaths.Add(fileName); 
                    }
                }
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lstSelectedFiles.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show(
                    this,
                    "Are you sure you want to remove the selected file?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string fileToRemoveName = lstSelectedFiles.SelectedItem.ToString();

                    lstSelectedFiles.Items.Remove(lstSelectedFiles.SelectedItem);

                    string filePathToRemove = selectedFilePaths.FirstOrDefault(file => Path.GetFileName(file) == fileToRemoveName);

                    if (filePathToRemove != null)
                    {
                        selectedFilePaths.Remove(filePathToRemove); 
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    this,
                    "Please select a file to remove.",
                    "No file selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            if (selectedFilePaths.Count == 0)
            {
                MessageBox.Show("Please select at least one file to merge.");
                return;
            }

            // Define the output file path for the merged file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "MergedFile.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;

                // Call the MergeExcelFiles method from ExcelMerger class
                ExcelMerger.MergeExcelFiles(selectedFilePaths.ToArray(), outputFilePath);
            }
        }
    }
}
