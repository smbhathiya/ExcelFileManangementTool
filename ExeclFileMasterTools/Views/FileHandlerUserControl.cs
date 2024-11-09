using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMasterTools.Views
{

        public partial class FileHandlerUserControl : UserControl
        {
            public FileHandlerUserControl()
            {
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
                        string fileNameOnly = System.IO.Path.GetFileName(fileName);
                        if (!lstSelectedFiles.Items.Contains(fileNameOnly))
                        {
                            lstSelectedFiles.Items.Add(fileNameOnly);
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
                        lstSelectedFiles.Items.Remove(lstSelectedFiles.SelectedItem);
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
        }
    }



