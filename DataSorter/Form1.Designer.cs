using System;

namespace DataSorter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button filesselectbtn;
        private System.Windows.Forms.Button mergebtn;
        private System.Windows.Forms.Label fileCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelOrganizeFiles;
        private System.Windows.Forms.Panel panelMergeFiles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.filesselectbtn = new System.Windows.Forms.Button();
            this.mergebtn = new System.Windows.Forms.Button();
            this.fileCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelOrganizeFiles = new System.Windows.Forms.Panel();
            this.panelMergeFiles = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelOrganizeFiles.SuspendLayout();
            this.panelMergeFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFilePath.ForeColor = System.Drawing.Color.Black;
            this.txtFilePath.Location = new System.Drawing.Point(40, 102);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(725, 18);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(40, 148);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(150, 41);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Select File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click_1);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(103)))), ((int)(((byte)(247)))));
            this.btnSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.Location = new System.Drawing.Point(210, 148);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(112, 41);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "Organize";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selected Files:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(40, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(719, 18);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // filesselectbtn
            // 
            this.filesselectbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filesselectbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filesselectbtn.FlatAppearance.BorderSize = 0;
            this.filesselectbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.filesselectbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.filesselectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filesselectbtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.filesselectbtn.ForeColor = System.Drawing.Color.White;
            this.filesselectbtn.Location = new System.Drawing.Point(40, 148);
            this.filesselectbtn.Name = "filesselectbtn";
            this.filesselectbtn.Size = new System.Drawing.Size(150, 41);
            this.filesselectbtn.TabIndex = 6;
            this.filesselectbtn.Text = "Select Files";
            this.filesselectbtn.UseVisualStyleBackColor = false;
            this.filesselectbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // mergebtn
            // 
            this.mergebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(103)))), ((int)(((byte)(247)))));
            this.mergebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mergebtn.FlatAppearance.BorderSize = 0;
            this.mergebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.mergebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.mergebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mergebtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.mergebtn.ForeColor = System.Drawing.Color.White;
            this.mergebtn.Location = new System.Drawing.Point(210, 148);
            this.mergebtn.Name = "mergebtn";
            this.mergebtn.Size = new System.Drawing.Size(112, 41);
            this.mergebtn.TabIndex = 7;
            this.mergebtn.Text = "Merge Files";
            this.mergebtn.UseVisualStyleBackColor = false;
            this.mergebtn.Click += new System.EventHandler(this.mergebtn_Click);
            // 
            // fileCount
            // 
            this.fileCount.AutoSize = true;
            this.fileCount.Location = new System.Drawing.Point(558, 193);
            this.fileCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(0, 13);
            this.fileCount.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(10, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Organize Files";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SortFilesMenu_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(10, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "Merge Files";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.MergeFilesMenu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "FileMaster Tools";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelOrganizeFiles
            // 
            this.panelOrganizeFiles.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelOrganizeFiles.Controls.Add(this.label5);
            this.panelOrganizeFiles.Controls.Add(this.txtFilePath);
            this.panelOrganizeFiles.Controls.Add(this.btnUpload);
            this.panelOrganizeFiles.Controls.Add(this.btnSort);
            this.panelOrganizeFiles.Controls.Add(this.label1);
            this.panelOrganizeFiles.Location = new System.Drawing.Point(170, 70);
            this.panelOrganizeFiles.Name = "panelOrganizeFiles";
            this.panelOrganizeFiles.Size = new System.Drawing.Size(800, 458);
            this.panelOrganizeFiles.TabIndex = 12;
            // 
            // panelMergeFiles
            // 
            this.panelMergeFiles.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMergeFiles.Controls.Add(this.label4);
            this.panelMergeFiles.Controls.Add(this.label2);
            this.panelMergeFiles.Controls.Add(this.textBox1);
            this.panelMergeFiles.Controls.Add(this.filesselectbtn);
            this.panelMergeFiles.Controls.Add(this.mergebtn);
            this.panelMergeFiles.Location = new System.Drawing.Point(170, 70);
            this.panelMergeFiles.Name = "panelMergeFiles";
            this.panelMergeFiles.Size = new System.Drawing.Size(800, 458);
            this.panelMergeFiles.TabIndex = 13;
            this.panelMergeFiles.Visible = false;
            this.panelMergeFiles.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMergeFiles_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "MERGE FILES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "ORGANIZE FILES";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1005, 565);
            this.Controls.Add(this.panelOrganizeFiles);
            this.Controls.Add(this.panelMergeFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "File Master Tools";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.panelOrganizeFiles.ResumeLayout(false);
            this.panelOrganizeFiles.PerformLayout();
            this.panelMergeFiles.ResumeLayout(false);
            this.panelMergeFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
