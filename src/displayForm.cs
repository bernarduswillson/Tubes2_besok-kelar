﻿using System;
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
using Microsoft.VisualBasic.Devices;

namespace WinFormsApp1
{
    public partial class displayForm : Form
    {
        public string fileName;

        bool isProcessRunning = false;
        bool mapShowed = false;
        bool routeShowed = false;
        int row = 1;
        int col = 0;
        int x = 0;
        int y = 0;
        int treasure = 0;
        int[,] arr;


        public displayForm()
        {
            InitializeComponent();
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
            arr = new int[row, col];
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
                    if (c == 'K')
                    {
                        arr[idRow, idCol] = 1;
                    }
                    else if (c == 'R')
                    {
                        arr[idRow, idCol] = 2;
                    }
                    else if (c == 'T')
                    {
                        arr[idRow, idCol] = 3;
                        count++;
                    }
                    else
                    {
                        arr[idRow, idCol] = 0;
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
            x = 0;
            y = 0;
            treasure = 0;
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double value = trackBar1.Value * 0.01;
            textBox1.Text = value.ToString("0.00");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double value))
            {
                if (value > 10)
                {
                    value = 10;
                    textBox1.Text = value.ToString("0.00");
                }
                else if (value < 1)
                {
                    value = 1;
                    textBox1.Text = value.ToString("0.00");
                }
                trackBar1.Value = (int)((value) * 100);
            }
        }

        public async void search_Click(object sender, EventArgs e)
        {
            if (mainForm.fileName != null && !isProcessRunning && mapShowed)
            {
                clearMap();
                isProcessRunning = true;

                if (mainForm.BFSbool)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    BFS bfs = new BFS(this.x, this.y, this.arr, this.treasure);
                    if (mainForm.TSPbool)
                    {
                        bfs.finalTSP();
                    }
                    else
                    {
                        bfs.finalSearch();
                    }

                    stopwatch.Stop();
                    runtime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";

                    string route = bfs.getRoute();
                    routes.Text = route;

                    int step = bfs.getStep();
                    steps.Text = step.ToString();

                    int node = bfs.getCountVisited();
                    nodes.Text = node.ToString();

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
                            if (dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.White || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Gold || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Red)
                            {
                                dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, 255, 0);
                            }
                            else
                            {
                                int greens = dataGridView1.Rows[xs].Cells[ys].Style.BackColor.G - dec;
                                dataGridView1.Rows[xs].Cells[ys].Style.BackColor = Color.FromArgb(0, greens, 0);
                            }
                        }
                        await Task.Delay(1000 - trackBar1.Value);
                        clearMap();
                    }
                    await Task.Delay(1000);
                    isProcessRunning = false;

                }
                else if (mainForm.DFSbool)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    DFS dfs = new DFS(this.x, this.y, this.treasure, this.arr);
                    if (mainForm.TSPbool)
                    {
                        dfs.findHome();
                    }
                    else
                    {
                        dfs.findPath();
                    }
                    stopwatch.Stop();
                    runtime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";

                    string route = dfs.getRoute();
                    routes.Text = route;

                    int step = dfs.getStep();
                    steps.Text = step.ToString();

                    int node = dfs.getCountVisited();
                    nodes.Text = node.ToString();

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
                        dataGridView1.CurrentCell = dataGridView1.Rows[value.getX()].Cells[value.getY()];
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                        await Task.Delay(1000 - trackBar1.Value);
                        dataGridView1.CurrentCell = null;
                        if (dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.White || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Gold || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Red)
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
                    clearMap();
                }
                await Task.Delay(1000);
                isProcessRunning = false;
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
            mainForm.TSPbool = false;
            mainForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void show_Click(object sender, EventArgs e)
        {
            if (!isProcessRunning)
            {
                clearMap();
                mapShowed = true;
            }
        }

        public async void Route_Click(object sender, EventArgs e)
        {
            if (mainForm.fileName != null && !isProcessRunning && mapShowed)
            {
                clearMap();
                isProcessRunning = true;

                if (mainForm.BFSbool)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    BFS bfs = new BFS(this.x, this.y, this.arr, this.treasure);
                    if (mainForm.TSPbool)
                    {
                        bfs.finalTSP();
                    }
                    else
                    {
                        bfs.finalSearch();
                    }

                    stopwatch.Stop();
                    runtime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";

                    string route = bfs.getRoute();
                    routes.Text = route;

                    int step = bfs.getStep();
                    steps.Text = step.ToString();

                    int node = bfs.getCountVisited();
                    nodes.Text = node.ToString();

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
                        dataGridView1.CurrentCell = dataGridView1.Rows[xs].Cells[ys];
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                        await Task.Delay(1000 - trackBar1.Value);
                        dataGridView1.CurrentCell = null;
                        DataGridViewCell cell = dataGridView1.Rows[xs].Cells[ys];
                        if (dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.White || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Gold || dataGridView1.Rows[xs].Cells[ys].Style.BackColor == Color.Red)
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
                    isProcessRunning = false;
                }

                else if (mainForm.DFSbool)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    DFS dfs = new DFS(this.x, this.y, this.treasure, this.arr);
                    if (mainForm.TSPbool)
                    {
                        dfs.findHome();
                    }
                    else
                    {
                        dfs.findPath();
                    }

                    stopwatch.Stop();
                    runtime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString() + " ms";

                    string route = dfs.getRoute();
                    routes.Text = route;

                    int step = dfs.getStep();
                    steps.Text = step.ToString();

                    int node = dfs.getCountVisited();
                    nodes.Text = node.ToString();

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
                        dataGridView1.CurrentCell = dataGridView1.Rows[value.getX()].Cells[value.getY()];
                        dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                        await Task.Delay(1000 - trackBar1.Value);
                        dataGridView1.CurrentCell = null;
                        if (dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.White || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Gold || dataGridView1.Rows[value.getX()].Cells[value.getY()].Style.BackColor == Color.Red)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void runtime_Click(object sender, EventArgs e)
        {

        }

        private void routes_Click(object sender, EventArgs e)
        {

        }

        private void steps_Click(object sender, EventArgs e)
        {

        }

        private void nodes_Click(object sender, EventArgs e)
        {

        }

        private void clearMap()
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
                    if (c == 'K')
                    {
                        dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Red;
                        dataGridView1.Rows[idRow].Cells[idCol].Value = "Start";
                    }
                    else if (c == 'R')
                    {
                        dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.White;
                    }
                    else if (c == 'T')
                    {
                        dataGridView1.Rows[idRow].Cells[idCol].Style.BackColor = Color.Gold;
                        dataGridView1.Rows[idRow].Cells[idCol].Value = "Treasure";
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
            reader.Close();
            reader2.Close();
        }
    }
}