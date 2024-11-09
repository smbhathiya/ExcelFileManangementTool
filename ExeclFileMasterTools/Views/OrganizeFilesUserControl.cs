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

namespace FileMasterTools.Views
{
    public partial class OrganizeFilesUserControl : UserControl
    {
        private string selectedFilePath;

        public OrganizeFilesUserControl()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            InitializeComponent();
        }

        // Button for selecting a file
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx"; 
            openFileDialog.Multiselect = false; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = Path.GetFileName(openFileDialog.FileName);
                lblSelectedFile.Text = selectedFileName;  
                selectedFilePath = openFileDialog.FileName; 
            }
        }

        // Button for removing the selected file
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (lblSelectedFile.Text != "")
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
                    lblSelectedFile.Text = "";  
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

        private void btnOrganizeData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedFile.Text))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            try
            {
                OrganizeExcelData(selectedFilePath);
                MessageBox.Show("File organized successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OrganizeExcelData(string filePath)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select an Excel file to organize.");
                return;
            }

            // Create an instance of ExcelOrganizer and call the method
            var excelOrganizer = new FileMasterTools.Services.ExcelOrganizer();
            excelOrganizer.OrganizeExcelData(selectedFilePath);

            MessageBox.Show("File organized successfully!");
        }
    }
}

