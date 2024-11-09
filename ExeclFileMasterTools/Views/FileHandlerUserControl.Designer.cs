using System.Windows.Forms;

namespace FileMasterTools.Views
{
    partial class FileHandlerUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ListBox lstSelectedFiles;
        private Button btnSelectFiles;
        private Button btnRemoveFile;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstSelectedFiles = new System.Windows.Forms.ListBox();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();

            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.Location = new System.Drawing.Point(30, 50);  // Set location on form
            this.lstSelectedFiles.Name = "lstSelectedFiles";  // Ensure it matches the name in the code
            this.lstSelectedFiles.Size = new System.Drawing.Size(200, 160);

            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.Location = new System.Drawing.Point(30, 220);  // Button location
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);

            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.Location = new System.Drawing.Point(150, 220);  // Button location
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);

            // 
            // FileHandlerForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.lstSelectedFiles);  // Add ListBox to the form
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.btnRemoveFile);
            this.Name = "FileHandlerForm";
            this.Text = "File Handler";
            this.ResumeLayout(false);
        }
        #endregion
    }
}