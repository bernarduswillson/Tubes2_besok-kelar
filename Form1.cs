using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using System;
using System.IO;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        string fileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public async void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;

            if (int.TryParse(textBox1.Text, out int values) && values <= 1000)
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("Please enter a number between 0 and 1000.");
                textBox1.Text = "0";
            }

            int row = 1;
            int col = 0;
            if (this.fileName != null && flag)
            {
                string filePath = this.fileName;
                StreamReader reader = new StreamReader(filePath);
                //Tentuin kolom dan baris
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

                //BIKIN MATRIKS
                int[,] arr = new int[row, col];
                int charCode;
                int idRow = 0;
                int idCol = 0;
                int count = 0;
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
                        // Console.Write("IDROW : " + idRow + "\n");
                        // Console.Write("     IDCOL : " + idCol + "\n");
                        if (c == 'K')
                        {
                            arr[idRow, idCol] = 1;
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Brown;
                        }
                        else if (c == 'R')
                        {
                            arr[idRow, idCol] = 2;
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.White;
                        }
                        else if (c == 'T')
                        {
                            arr[idRow, idCol] = 3;
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Gold;
                            count++;
                        }
                        else
                        {
                            arr[idRow, idCol] = 0;
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Black;
                        }
                        idCol++;
                        if (idCol == col)
                        {
                            idRow++;
                            idCol = 0;
                        }
                    }
                }
                reader.Close();
                reader2.Close();
                // Simpul root;
                //bikin graph
                int x = 0;
                int y = 0;
                int treasure = 0;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (arr[i, j] == 1)
                        {
                            x = i;
                            y = j;
                        }
                        if (arr[i, j] == 3)
                        {
                            treasure++;
                        }
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                if (radioButton1.Checked)
                {
                    BFS root = new BFS(x, y, arr, treasure);
                    // dataGridView1.Rows[1].Cells[1].Value = root;
                    //dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Black;
                }
                else if (radioButton2.Checked)
                {
                    DFS dfs = new DFS(x, y, treasure, arr);
                    dfs.findPath();
                    Stack<Simpul> copy = new Stack<Simpul>(dfs.getResult());
                    //find the most same value
                    int maxCount = 1;
                    for (int i = 0; i < copy.Count; i++)
                    {
                        int counts = 1;
                        for (int j = 0; j < copy.Count; j++)
                        {
                            if (i != j)
                            {
                                if (copy.ElementAt(i).getX() == copy.ElementAt(j).getX() && copy.ElementAt(i).getY() == copy.ElementAt(j).getY())
                                {
                                    counts++;
                                }
                            }
                        }
                        if (counts > maxCount)
                        {
                            maxCount = counts;
                        }
                    }
                    int dec = (255 / maxCount) - 10;

                    //PictureBox pictureBox = new PictureBox();
                    //Image image = Image.FromFile("../../../obj/jason.png");
                    //PictureBox.Image = image;

                    foreach (Simpul value in copy)
                    {
                        await Task.Delay(trackBar1.Value);
                        if (dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.White || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Gold || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Brown)
                        {
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, 255, 0);
                        }
                        else
                        {
                            int greens = dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor.G - dec;
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, greens, 0);
                        }
                        //dataGridView1.Rows[value.getX()].Cells[value.getY()].Value = pictureBox.Image;
                    }
                }
            }
            else if (this.fileName == null)
            {
                MessageBox.Show("Please input a file.");
            }
            else if (radioButton1.Checked == false || radioButton2.Checked == false)
            {
                MessageBox.Show("Please select an algorithm.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.fileName = openFileDialog.FileName;
                label3.Text = Path.GetFileName(this.fileName);
                int row = 1;
                int col = 0;
                if (this.fileName != null)
                {
                    string filePath = this.fileName;
                    StreamReader reader = new StreamReader(filePath);
                    //Tentuin kolom dan baris
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

                    reader.Close();

                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.Enabled = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeColumns = false;
                    dataGridView1.AllowUserToResizeRows = false;
                    dataGridView1.ScrollBars = ScrollBars.None;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

                    dataGridView1.ColumnCount = col;
                    dataGridView1.RowCount = row;

                    int rowHeight = dataGridView1.ClientSize.Height / dataGridView1.RowCount;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Height = rowHeight;
                    }
                    dataGridView1.CurrentCell = null;

                    int[,] arr = new int[row, col];
                    int charCode;
                    int idRow = 0;
                    int idCol = 0;
                    int count = 0;
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
                            // Console.Write("IDROW : " + idRow + "\n");
                            // Console.Write("     IDCOL : " + idCol + "\n");
                            if (c == 'K')
                            {
                                dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Brown;
                            }
                            else if (c == 'R')
                            {
                                dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.White;
                            }
                            else if (c == 'T')
                            {
                                dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Gold;
                                count++;
                            }
                            else
                            {
                                dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Black;
                            }
                            idCol++;
                            if (idCol == col)
                            {
                                idRow++;
                                idCol = 0;
                            }
                        }

                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value) && value > 1000)
            {
                trackBar1.Value = 1000;
            }
            else if (int.TryParse(textBox1.Text, out int values) && values < 0)
            {
                trackBar1.Value = 0;
            }
            else
            {
                trackBar1.Value = value;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}