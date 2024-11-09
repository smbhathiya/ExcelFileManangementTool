using System;
using System.Windows.Forms;

namespace DataSorter
{
    public static class FileSelector
    {
        public static string[] SelectExcelFiles()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
