using System.Windows.Forms;

namespace ExcelFileHandler.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnFileHandler = new System.Windows.Forms.Button();
            this.btnOrganizeFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pnlContent.Location = new System.Drawing.Point(219, 24);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(750, 445);
            this.pnlContent.TabIndex = 2;
            // 
            // btnFileHandler
            // 
            this.btnFileHandler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnFileHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileHandler.FlatAppearance.BorderSize = 0;
            this.btnFileHandler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileHandler.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileHandler.ForeColor = System.Drawing.Color.Transparent;
            this.btnFileHandler.Location = new System.Drawing.Point(19, 83);
            this.btnFileHandler.Name = "btnFileHandler";
            this.btnFileHandler.Size = new System.Drawing.Size(182, 59);
            this.btnFileHandler.TabIndex = 0;
            this.btnFileHandler.Text = "Merge Files";
            this.btnFileHandler.UseVisualStyleBackColor = false;
            this.btnFileHandler.Click += new System.EventHandler(this.btnFileHandler_Click);
            // 
            // btnOrganizeFiles
            // 
            this.btnOrganizeFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(164)))), ((int)(((byte)(204)))));
            this.btnOrganizeFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrganizeFiles.FlatAppearance.BorderSize = 0;
            this.btnOrganizeFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizeFiles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrganizeFiles.ForeColor = System.Drawing.Color.Transparent;
            this.btnOrganizeFiles.Location = new System.Drawing.Point(19, 24);
            this.btnOrganizeFiles.Name = "btnOrganizeFiles";
            this.btnOrganizeFiles.Size = new System.Drawing.Size(182, 59);
            this.btnOrganizeFiles.TabIndex = 1;
            this.btnOrganizeFiles.Text = "Organize Files";
            this.btnOrganizeFiles.UseVisualStyleBackColor = false;
            this.btnOrganizeFiles.Click += new System.EventHandler(this.btnOrganizeFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(60)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(809, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Execl File Master Tools © 2024";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(993, 531);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnOrganizeFiles);
            this.Controls.Add(this.btnFileHandler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Execl File Master Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private Button btnSelectFiles;
        private ListBox lstSelectedFiles;
        private Button btnRemoveFile;
        private Panel pnlNavigation;
        private Button btnFileHandler;
        private Button btnOrganizeFiles;
        private Panel pnlContent;
        private Label label1;
    }
}