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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnFileHandler = new System.Windows.Forms.Button();
            this.btnOrganizeFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pnlContent.Location = new System.Drawing.Point(178, 32);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(750, 400);
            this.pnlContent.TabIndex = 2;
            // 
            // btnFileHandler
            // 
            this.btnFileHandler.Location = new System.Drawing.Point(12, 32);
            this.btnFileHandler.Name = "btnFileHandler";
            this.btnFileHandler.Size = new System.Drawing.Size(153, 43);
            this.btnFileHandler.TabIndex = 0;
            this.btnFileHandler.Text = "File Handler";
            this.btnFileHandler.UseVisualStyleBackColor = true;
            this.btnFileHandler.Click += new System.EventHandler(this.btnFileHandler_Click);
            // 
            // btnOrganizeFiles
            // 
            this.btnOrganizeFiles.Location = new System.Drawing.Point(12, 92);
            this.btnOrganizeFiles.Name = "btnOrganizeFiles";
            this.btnOrganizeFiles.Size = new System.Drawing.Size(153, 43);
            this.btnOrganizeFiles.TabIndex = 1;
            this.btnOrganizeFiles.Text = "Organize Files";
            this.btnOrganizeFiles.UseVisualStyleBackColor = true;
            this.btnOrganizeFiles.Click += new System.EventHandler(this.btnOrganizeFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(60)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(792, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Excel File Handler © 2024";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(960, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.btnOrganizeFiles);
            this.Controls.Add(this.btnFileHandler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Master Tools";
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