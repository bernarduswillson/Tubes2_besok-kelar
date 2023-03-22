using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using static System.Windows.Forms.DataFormats;
using System.Windows.Forms.Design;

namespace WinFormsApp1
{
    public partial class displayForm : Form
    {
        bool isProcessRunning = false;
        bool mapShowed = false;
        public string fileName;
        public displayForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = (1000 - trackBar1.Value).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int value) && value > 1000)
            {
                trackBar1.Value = 0;
            }
            else if (int.TryParse(textBox1.Text, out int values) && values < 0)
            {
                trackBar1.Value = 1000;
            }
            else
            {
                trackBar1.Value = 1000 - value;
            }
        }

        public async void search_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("../../../obj/jason.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Boolean flag = false;
            dataGridView1.CurrentCell = null;

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
            if (mainForm.fileName != null && flag && !isProcessRunning && mapShowed)
            {
                isProcessRunning = true;
                this.fileName = mainForm.fileName;
                string filePath = mainForm.fileName;
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
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Pink;
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
                    }
                }

                if (mainForm.BFSbool)
                {
                    BFS bfs = new BFS(x, y, arr, treasure);
                    bfs.finalSearch();
                    Queue<Simpul> copy = new Queue<Simpul>(bfs.getProgress());
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

                    foreach (Simpul value in copy)
                    {
                        foreach ((int xs, int ys) in value.getArr())
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[xs].Cells[ys];
                            dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                            await Task.Delay(1000 - trackBar1.Value);
                            dataGridView1.CurrentCell = null;
                            if (dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.White || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Gold || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Pink)
                            {
                                dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, 255, 0);
                            }
                            else
                            {
                                int greens = dataGridView1.Rows[xs].Cells[ys].Style.BackColor.G - 30;
                                dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, greens, 0);
                            }
                        }
                        await Task.Delay(1000 - trackBar1.Value);
                        filePath = mainForm.fileName;
                        this.fileName = mainForm.fileName;
                        StreamReader reader1 = new StreamReader(filePath);
                        //Tentuin kolom dan baris
                        row = 1;
                        col = 0;
                        String line1 = reader1.ReadLine();
                        foreach (char c in line1)
                        {
                            if (c != ' ')
                            {
                                col++;
                            }
                        }
                        while ((line1 = reader1.ReadLine()) != null)
                        {
                            row++;
                        }

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

                        int[,] arr1 = new int[row, col];
                        idRow = 0;
                        idCol = 0;
                        count = 0;
                        StreamReader reader3 = new StreamReader(filePath);
                        while ((charCode = reader3.Read()) != -1)
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
                                    arr1[idRow, idCol] = 1;
                                    dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Pink;
                                }
                                else if (c == 'R')
                                {
                                    arr1[idRow, idCol] = 2;
                                    dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.White;
                                }
                                else if (c == 'T')
                                {
                                    arr1[idRow, idCol] = 3;
                                    dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Gold;
                                    count++;
                                }
                                else
                                {
                                    arr1[idRow, idCol] = 0;
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
                        reader1.Close();
                        reader3.Close();
                    }
                    await Task.Delay(1000);
                    dataGridView1.Controls.Remove(pictureBox);
                    isProcessRunning = false;

                }
                else if (mainForm.DFSbool)
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

                    foreach (Simpul value in copy)
                    {
                        Rectangle cellBounds = dataGridView1.GetCellDisplayRectangle(value.getY(), value.getX(), false);
                        pictureBox.Size = cellBounds.Size;
                        pictureBox.Location = new Point(cellBounds.X, cellBounds.Y);
                        dataGridView1.Controls.Add(pictureBox);
                        await Task.Delay(1000 - trackBar1.Value);
                        DataGridViewCell cell = dataGridView1.Rows[value.getX()].Cells[value.getY()];
                        if (dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.White || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Gold || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Pink)
                        {
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, 255, 0);
                        }
                        else
                        {
                            int greens = dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor.G - dec;
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, greens, 0);
                        }
                    }
                    await Task.Delay(1000);
                    dataGridView1.Controls.Remove(pictureBox);
                    isProcessRunning = false;

                }
            }
            else if (isProcessRunning)
            {
                MessageBox.Show("Please wait until the process is finished.");
            }
            else if (!mapShowed)
            {
                MessageBox.Show("Please press the 'Show Map' first.");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            mainForm.BFSbool = false;
            mainForm.DFSbool = false;
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (!isProcessRunning)
            {
                string filePath = mainForm.fileName;
                this.fileName = mainForm.fileName;
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
                            arr[idRow, idCol] = 1;
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Pink;
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
                mapShowed = true;
            }
        }

        public async void restart_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("../../../obj/jason.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Boolean flag = false;
            dataGridView1.CurrentCell = null;

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
            if (mainForm.fileName != null && flag && !isProcessRunning && mapShowed)
            {
                isProcessRunning = true;
                this.fileName = mainForm.fileName;
                string filePath = mainForm.fileName;
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
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Pink;
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
                    }
                }

                if (mainForm.BFSbool)
                {
                    BFS root = new BFS(x, y, arr, treasure);
                    // dataGridView1.Rows[1].Cells[1].Value = root;
                    //dataGridView1.Rows[1].Cells[1].Style.BackColor = Color.Black;
                }
                else if (mainForm.DFSbool)
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

                    foreach (Simpul value in copy)
                    {
                        Rectangle cellBounds = dataGridView1.GetCellDisplayRectangle(value.getY(), value.getX(), false);
                        pictureBox.Size = cellBounds.Size;
                        pictureBox.Location = new Point(cellBounds.X, cellBounds.Y);
                        dataGridView1.Controls.Add(pictureBox);
                        await Task.Delay(1000 - trackBar1.Value);
                        DataGridViewCell cell = dataGridView1.Rows[value.getX()].Cells[value.getY()];
                        if (dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.White || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Gold || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Pink)
                        {
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, 255, 0);
                        }
                        else
                        {
                            int greens = dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor.G - dec;
                            dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor = Color.FromArgb(0, greens, 0);
                        }

                    }
                    await Task.Delay(1000);
                    dataGridView1.Controls.Remove(pictureBox);
                    isProcessRunning = false;

                }
            }
            else if (isProcessRunning)
            {
                MessageBox.Show("Please wait until the process is finished.");
            }
            else if (!mapShowed)
            {
                MessageBox.Show("Please press the 'Show Map' first.");
            }
        }

        public async void Route_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("../../../obj/jason.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            Boolean flag = false;
            dataGridView1.CurrentCell = null;

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
            if (mainForm.fileName != null && flag && !isProcessRunning && mapShowed)
            {
                isProcessRunning = true;
                this.fileName = mainForm.fileName;
                string filePath = mainForm.fileName;
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
                            dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Pink;
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
                    }
                }

                if (mainForm.BFSbool)
                {
                    BFS bfs = new BFS(x, y, arr, treasure);
                    bfs.finalSearch();
                    Simpul res = new Simpul(x, y, arr);
                    res.unite(bfs.getResult());
                    int maxCount = 1;
                    for (int i = 0; i < res.getArr().Count(); i++)
                    {
                        int counts = 1;
                        for (int j = 0; j < res.getArr().Count(); j++)
                        {
                            var (xi, yi) = res.getArr()[i];
                            var (xj, yj) = res.getArr()[j];
                            if (i != j)
                            {
                                if (xi == xj && yi == yj)
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

                    foreach ((int xs, int ys) in res.getArr())
                    {
                        Rectangle cellBounds = dataGridView1.GetCellDisplayRectangle(ys, xs, false);
                        pictureBox.Size = cellBounds.Size;
                        pictureBox.Location = new Point(cellBounds.X, cellBounds.Y);
                        dataGridView1.Controls.Add(pictureBox);
                        await Task.Delay(1000 - trackBar1.Value);
                        dataGridView1.Controls.Remove(pictureBox);
                        DataGridViewCell cell = dataGridView1.Rows[xs].Cells[ys];
                        if (dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.White || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Gold || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Pink)
                        {
                            dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, 255, 0);
                        }
                        else
                        {
                            int greens = dataGridView1.Rows[xs].Cells[ys].Style.BackColor.G - dec;
                            dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, greens, 0);
                        }
                    }
                    await Task.Delay(1000);
                    dataGridView1.Controls.Remove(pictureBox);
                    isProcessRunning = false;
                }
            }
        }
    }
}