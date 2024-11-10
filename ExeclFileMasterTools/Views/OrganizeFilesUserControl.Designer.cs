using System.Windows.Forms;

namespace ExcelFileHandler.Views
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
            this.btnSelectFile.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSelectFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(82)))));
            this.btnSelectFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(80)))));
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFile.ForeColor = System.Drawing.Color.White;
            this.btnSelectFile.Location = new System.Drawing.Point(205, 363);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(160, 50);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
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
            this.btnRemoveFile.TabIndex = 1;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnOrganizeData
            // 
            this.btnOrganizeData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOrganizeData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrganizeData.FlatAppearance.BorderSize = 0;
            this.btnOrganizeData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnOrganizeData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnOrganizeData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizeData.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrganizeData.ForeColor = System.Drawing.Color.White;
            this.btnOrganizeData.Location = new System.Drawing.Point(562, 363);
            this.btnOrganizeData.Name = "btnOrganizeData";
            this.btnOrganizeData.Size = new System.Drawing.Size(160, 50);
            this.btnOrganizeData.TabIndex = 2;
            this.btnOrganizeData.Text = "Organize Data";
            this.btnOrganizeData.UseVisualStyleBackColor = true;
            this.btnOrganizeData.Click += new System.EventHandler(this.btnOrganizeData_Click);
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFile.Location = new System.Drawing.Point(18, 36);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(704, 40);
            this.lblSelectedFile.TabIndex = 3;
            this.lblSelectedFile.Text = "No file selected";
            this.lblSelectedFile.Click += new System.EventHandler(this.lblSelectedFile_Click);
            // 
            // OrganizeFilesUserControl
            // 
            this.Controls.Add(this.lblSelectedFile);
            this.Controls.Add(this.btnOrganizeData);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "OrganizeFilesUserControl";
            this.Size = new System.Drawing.Size(750, 445);
            this.ResumeLayout(false);

        }
        #endregion
    }
}