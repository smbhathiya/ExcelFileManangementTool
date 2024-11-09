using System.Windows.Forms;

namespace FileMasterTools.Views
{
    partial class OrganizeFilesUserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnSelectFile;
        private Button btnRemoveFile;
        private Button btnOrganizeData;
        private Label lblSelectedFile;

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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnOrganizeData = new System.Windows.Forms.Button();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(312, 73);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(200, 40);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(53, 73);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(200, 40);
            this.btnRemoveFile.TabIndex = 1;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnOrganizeData
            // 
            this.btnOrganizeData.Location = new System.Drawing.Point(312, 134);
            this.btnOrganizeData.Name = "btnOrganizeData";
            this.btnOrganizeData.Size = new System.Drawing.Size(200, 40);
            this.btnOrganizeData.TabIndex = 2;
            this.btnOrganizeData.Text = "Organize Data";
            this.btnOrganizeData.UseVisualStyleBackColor = true;
            this.btnOrganizeData.Click += new System.EventHandler(this.btnOrganizeData_Click);
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.Location = new System.Drawing.Point(50, 30);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(462, 40);
            this.lblSelectedFile.TabIndex = 3;
            this.lblSelectedFile.Text = "No file selected";
            // 
            // OrganizeFilesUserControl
            // 
            this.Controls.Add(this.lblSelectedFile);
            this.Controls.Add(this.btnOrganizeData);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "OrganizeFilesUserControl";
            this.Size = new System.Drawing.Size(567, 352);
            this.ResumeLayout(false);

        }
        #endregion
    }
}