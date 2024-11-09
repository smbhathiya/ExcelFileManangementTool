using ExcelFileHandler.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFileHandler.Views
{
    public partial class MainForm : Form
    {
        private OrganizeFilesUserControl organizeFilesUserControl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadOrganizeFilesUserControl();
        }

        private void LoadFileHandlerUserControl()
        {
            pnlContent.Controls.Clear(); 
            FileHandlerUserControl fileHandlerControl = new FileHandlerUserControl();
            fileHandlerControl.Dock = DockStyle.Fill; 
            pnlContent.Controls.Add(fileHandlerControl); 
        }
        private void LoadOrganizeFilesUserControl()
        {
            pnlContent.Controls.Clear();
            organizeFilesUserControl = new OrganizeFilesUserControl();
            organizeFilesUserControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(organizeFilesUserControl);
        }

        private void btnFileHandler_Click(object sender, EventArgs e)
        {
            LoadFileHandlerUserControl();
            btnOrganizeFiles.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            btnFileHandler.BackColor = System.Drawing.Color.FromArgb(106, 164, 204);
        }
        private void btnOrganizeFiles_Click(object sender, EventArgs e)
        {
            LoadOrganizeFilesUserControl();
            btnFileHandler.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            btnOrganizeFiles.BackColor = System.Drawing.Color.FromArgb(106, 164, 204);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string appInfo = "Application Name: Excel File Handler\n" +
                     "Version: 2.1.0\n" +
                     "Created by: Bhathiya Lakshan\n" +
                     "Year: 2024\n" +
                     "Contact Support: +94 76 894 1816" ;

            MessageBox.Show(appInfo, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
