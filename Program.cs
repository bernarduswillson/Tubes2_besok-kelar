using System;
using System.IO;
class Node
{
    private Node childTop;
    private Node childBottom;
    private Node childLeft;
    private Node childRight;
    private Node parent;
    static int n;
    private int id;
    private int number;
    public Node(int num)
    {
        this.childTop = null;
        this.childBottom = null;
        this.childLeft = null;
        this.childRight = null;
        this.parent = null;
        this.number = num;
        this.id = n;
        n++;
    }
    // public void searchChild()
    // {

    // }
    public Node(int num, Node parent)
    {
        this.number = num;
        this.childTop = null;
        this.childBottom = null;
        this.childLeft = null;
        this.childRight = null;
        this.parent = parent;
    }
    // public void addChild(Node other)
    // {
    //     this.child = other;
    // }
    public int getID()
    {
        return this.id;
    }
    public int getNum()
    {
        return this.number;
    }
}
class Graph
{
    Node startNode;
    public Graph(Node startNode)
    {
        this.startNode = startNode;
    }
}
class Matrix
{
    private int[,] matrix;
    public Matrix(int row, int col)
    {
        this.matrix = new int[row,col];
    }
    public int getElement(int row, int col)
    {
        return matrix[row,col];
    }
    public void setElement(int row, int col, int el)
    {
        matrix[row,col] = el;
    }
    public bool isAdjacent(int r1, int c1, int r2, int c2)
    {
        if (r1-1 == r2 || r1 + 1 == r2 || c1 -1 == c2 || c1 + 1 == c2)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
/*
0 -> X
1 -> K
2 -> R
3 -> T
*/
class Program
{
    static void Main()
    {
        int row = 1;
        int col = 0;
        string filePath = @"./test/config.txt"; 
        StreamReader reader = new StreamReader(filePath);
        //Tentuin kolom dan baris
        String line = reader.ReadLine();
        foreach(char c in line)
        {
            if (c!=' ')
            {
                col++;
            }
        }
        while ((line = reader.ReadLine()) != null)
        {
            row++;
        }

        //BIKIN MATRIKS
        int[,] arr = new int[row,col];
        int charCode;
        int idRow = 0;
        int idCol = 0;
        StreamReader reader2 = new StreamReader(filePath);
        while ((charCode = reader2.Read()) != -1)
        {
            char c = (char)charCode;
            if (idRow==row)
            {
                break;
            }
            if (c== 'K' || c== 'R' || c=='T' || c == 'X')
            {
                // Console.Write("IDROW : " + idRow + "\n");
                // Console.Write("     IDCOL : " + idCol + "\n");
                if (c== 'K')
                {
                    arr[idRow,idCol] = 1;
                }
                else if (c == 'R')
                {
                    arr[idRow,idCol] = 2;
                }
                else if (c == 'T')
                {
                    arr[idRow,idCol] = 3;
                }
                else
                {
                    arr[idRow,idCol] = 0;
                }
                idCol++;
                if (idCol == col)
                {
                    idRow++;
                    idCol= 0;
                }
            }
            // Console.Write(c);
        }
        // Console.WriteLine();
        reader.Close();
        reader2.Close();
        //bikin graph
        Graph mainGraph;
        Node pointerNode;
        for (int i = 0 ; i < row ; i++)
        {
            for (int j = 0 ; j < col ; j++)
            {
                if(arr[i,j]==1)
                {
                    Node temp = new Node(3);
                    mainGraph = new Graph(temp);
                    // Console.Write(c);
                }
                Console.Write(arr[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}