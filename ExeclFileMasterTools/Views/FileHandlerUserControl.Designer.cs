using System.Windows.Forms;

namespace ExcelFileHandler.Views
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
        private Button btnMergeFiles;

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
            this.btnMergeFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSelectedFiles
            // 
            this.lstSelectedFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSelectedFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedFiles.FormattingEnabled = true;
            this.lstSelectedFiles.ItemHeight = 19;
            this.lstSelectedFiles.Location = new System.Drawing.Point(22, 23);
            this.lstSelectedFiles.Name = "lstSelectedFiles";
            this.lstSelectedFiles.Size = new System.Drawing.Size(700, 304);
            this.lstSelectedFiles.TabIndex = 0;
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSelectFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFiles.FlatAppearance.BorderSize = 0;
            this.btnSelectFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(82)))));
            this.btnSelectFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(80)))));
            this.btnSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFiles.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFiles.ForeColor = System.Drawing.Color.White;
            this.btnSelectFiles.Location = new System.Drawing.Point(205, 363);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(160, 50);
            this.btnSelectFiles.TabIndex = 1;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.UseVisualStyleBackColor = false;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFile.FlatAppearance.BorderSize = 0;
            this.btnRemoveFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnRemoveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnRemoveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFile.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFile.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFile.Location = new System.Drawing.Point(22, 363);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(160, 50);
            this.btnRemoveFile.TabIndex = 2;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMergeFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMergeFiles.FlatAppearance.BorderSize = 0;
            this.btnMergeFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnMergeFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnMergeFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeFiles.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeFiles.ForeColor = System.Drawing.Color.White;
            this.btnMergeFiles.Location = new System.Drawing.Point(562, 363);
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.Size = new System.Drawing.Size(160, 50);
            this.btnMergeFiles.TabIndex = 3;
            this.btnMergeFiles.Text = "Merge Files";
            this.btnMergeFiles.UseVisualStyleBackColor = false;
            this.btnMergeFiles.Click += new System.EventHandler(this.btnMergeFiles_Click);
            // 
            // FileHandlerUserControl
            // 
            this.Controls.Add(this.lstSelectedFiles);
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnMergeFiles);
            this.Name = "FileHandlerUserControl";
            this.Size = new System.Drawing.Size(750, 445);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
