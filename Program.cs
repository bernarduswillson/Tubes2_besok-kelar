using System;
using System.IO;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); int row = 1;
            int col = 0;
            string filePath = @"../../../test/config.txt";
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
            // Console.WriteLine(treasure);
            BFS root = new BFS(x, y, arr, treasure);
            Console.WriteLine("Koordinat untuk mengambil semua treasure : ");
            root.findPath();
            // root.displayPath();
            // root.getCountVisited();

            //DFS
            // Console.WriteLine(arr.GetLength(1));
            DFS C = new DFS(x,y,treasure,arr);
            C.findPath();
            C.displayPath();
            // C.displaySteps();
            // C.displayVisited();
        }
    }
}