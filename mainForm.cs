using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainForm : Form
    {
        public static string fileName;
        public static bool BFSbool = false;
        public static bool DFSbool = false;
        bool solveable = true;
        public mainForm()
        {
            InitializeComponent();
            name.Text = "File Name: " + Path.GetFileName(fileName);
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            name.Text = "File Name: " + Path.GetFileName(fileName);
        }

        private void BFS_CheckedChanged(object sender, EventArgs e)
        {
            if (BFS.Checked)
            {
                BFSbool = true;
            }
        }


        private void DFS_CheckedChanged(object sender, EventArgs e)
        {
            if (DFS.Checked)
            {
                DFSbool = true;
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            string filePath = mainForm.fileName;
            StreamReader reader = new StreamReader(filePath);
            //Tentuin kolom dan baris
            int row = 1;
            int col = 0;
            String line = reader.ReadLine();
            foreach (char c in line)
            {
                if (c != ' ')
                {
                    col++;
                }
            }
            while ((line = reader.ReadLine()) != null)
            {
                row++;
            }
            int[,] arr = new int[row, col];
            int charCode;
            int idRow = 0;
            int idCol = 0;
            StreamReader reader2 = new StreamReader(filePath);
            while ((charCode = reader2.Read()) != -1)
            {
                char c = (char)charCode;
                if (idRow == row)
                {
                    break;
                }
                if (c == 'K' || c == 'R' || c == 'T' || c == 'X')
                {
                    solveable = true;
                    idCol++;
                    if (idCol == col)
                    {
                        idRow++;
                        idCol = 0;
                    }
                }
                else if (c != ' ' && c != '\r' && c != '\n')
                {
                    MessageBox.Show("The map that you inserted doesn't match the format, please try again");
                    solveable = false;
                    break;
                }
            }
            if ((DFSbool || BFSbool) && fileName != null && solveable)
            {
                displayForm displayForm = new displayForm();
                displayForm.Show();
                this.Hide();
            }
            else if (fileName == null && solveable)
            {
                MessageBox.Show("Please input a file.");
            }
            else if ((!DFSbool || !BFSbool) && solveable)
            {
                MessageBox.Show("Please insert an algorithm.");
            }
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
