using System.Windows.Forms;

namespace FileMasterTools.Views
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnFileHandler = new System.Windows.Forms.Button();
            this.btnOrganizeFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            this.pnlContent.Location = new System.Drawing.Point(150, 12);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContent.Size = new System.Drawing.Size(650, 400);
            this.pnlContent.TabIndex = 2;
            // 
            // btnFileHandler
            // 
            this.btnFileHandler.Location = new System.Drawing.Point(12, 12);
            this.btnFileHandler.Name = "btnFileHandler";
            this.btnFileHandler.Size = new System.Drawing.Size(120, 30);
            this.btnFileHandler.TabIndex = 0;
            this.btnFileHandler.Text = "File Handler";
            this.btnFileHandler.UseVisualStyleBackColor = true;
            this.btnFileHandler.Click += new System.EventHandler(this.btnFileHandler_Click);
            // 
            // btnOrganizeFiles
            // 
            this.btnOrganizeFiles.Location = new System.Drawing.Point(12, 50);
            this.btnOrganizeFiles.Name = "btnOrganizeFiles";
            this.btnOrganizeFiles.Size = new System.Drawing.Size(120, 30);
            this.btnOrganizeFiles.TabIndex = 1;
            this.btnOrganizeFiles.Text = "Organize Files";
            this.btnOrganizeFiles.UseVisualStyleBackColor = true;
            this.btnOrganizeFiles.Click += new System.EventHandler(this.btnOrganizeFiles_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(827, 435);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnOrganizeFiles);
            this.Controls.Add(this.btnFileHandler);
            this.Name = "MainForm";
            this.Text = "File Master Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }
        
        #endregion

        private Button btnSelectFiles;
        private ListBox lstSelectedFiles;
        private Button btnRemoveFile;
        private Panel pnlNavigation;
        private Button btnFileHandler;
        private Button btnOrganizeFiles;
        private Panel pnlContent;
    }
}