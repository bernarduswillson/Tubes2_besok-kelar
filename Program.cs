using System;
using System.IO;
class BFS
{
    /*
        1 -> kanan
        2 -> bawah
        3 -> kiri
        4 -> atas
    */
    private Queue<String> path;
    private Queue<Path> coorMap;
    private int x;
    private int[,] maze;
    private int y;
    private int count;
    private int countSteps;
    private int countVisited;
    public BFS(int x, int y, int[,] arr, int t)
    {
        this.x = x;
        this.y = y;
        this.maze = arr;
        this.countSteps = 0;
        this.countVisited = 0;
        this.count = t;
        this.coorMap = new Queue<Path>();
        //Lakukan pengecekan pada kiri start
        if (this.y-1 >= 0 && this.maze[x,y-1] != 0)
        {
            Path temp = new Path(this.maze);
            if(this.maze[x,y-1] == 3)
            {
                temp.pickTreasure(x-1,y);
            }
            temp.Append(x,y);
            temp.Append(x,y-1);
            // path.Enqueue("L");
            this.coorMap.Enqueue(temp);
            // Console.Write("L");
        }
        //Lakukan pengecekan pada kanan start
        if (this.y+1 < this.maze.GetLength(1) && this.maze[x,y+1] != 0)
        {
            // Console.WriteLine(this.maze.GetLength(0));
            // Console.WriteLine(x+1)/;
            Path temp = new Path(this.maze);
            if(this.maze[x,y+1] == 3)
            {
                temp.pickTreasure(x+1,y);
            }
            temp.Append(x,y);
            temp.Append(x,y+1);
            // path.Enqueue("R");
            coorMap.Enqueue(temp);
            // Console.Write("R");
        }
        //Lakukan pengecekan pada bawah start        
        if (this.x+1 < this.maze.GetLength(0) && this.maze[x+1,y] != 0)
        {
            Path temp = new Path(this.maze);
            if(this.maze[x+1,y] == 3)
            {
                temp.pickTreasure(x+1,y);
            }
            temp.Append(x,y);
            temp.Append(x+1,y);
            // path.Enqueue("D");
            coorMap.Enqueue(temp);
            // Console.Write("D");
        }
        //Lakukan pengecekan pada atas start        
        if (this.x-1 >= 0 && this.maze[x-1,y] != 0)
        {
            Path temp = new Path(this.maze);
            if(this.maze[x-1,y] == 3)
            {
                temp.pickTreasure(x,y-1);
            }
            temp.Append(x,y);
            temp.Append(x-1,y);
            // path.Enqueue("U");
            coorMap.Enqueue(temp); 
            // Console.Write("Up");
        }
        // Path temp2 = coorMap.Dequeue();
        // temp2.displayCoord();
        // Console.WriteLine(temp2.getCount());
        // temp2.displayMaze();
        // Path temp3 = coorMap.Dequeue();
        // temp3.displayCoord();
        
    }
    public Queue<String> getPath()
    {
        return path;
    }
    public bool isDone(int[,] arr)
    {
        for (int i = 0 ; i < arr.GetLength(0); i ++)
        {
            for (int j =  0 ; j < arr.GetLength(1) ; j++)
            {
                if (arr[i,j] == 3)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void findPath()
    {
        bool found = false;
        int[] tempCoor;
        while (!found)
        {
            //Ambil tiap jalurnya
            Path tempPath = coorMap.Dequeue();
            Path tempP1 = new Path(tempPath);
            Path tempP2 = new Path(tempPath);
            Path tempP3 = new Path(tempPath);
            Path tempP4 = new Path(tempPath);
            tempCoor = tempPath.getEl(tempPath.getIdx());
            //Cek apakah sudah semua terambil
            if (isDone(tempPath.getMaze()))
            {
                // Console.Write("PP");
                tempPath.displayCoord();
                // tempPath.displayMaze();
                found = true;
                break;
            }
            //cek bagian atas
            if (tempPath.canTravel(tempCoor[0]-1,tempCoor[1]))
            {
                //cek apakah treasure
                Path append = new Path(this.maze);
                append = tempP1;
                if (append.isTreasure(tempCoor[0]-1,tempCoor[1]))
                {
                    append.pickTreasure(tempCoor[0]-1,tempCoor[1]);
                }
                append.Append(tempCoor[0]-1,tempCoor[1]);
                coorMap.Enqueue(append);
                countVisited++;
            }
            //cek bagian bawah
            if (tempPath.canTravel(tempCoor[0]+1,tempCoor[1]))
            {
                //cek apakah treasure
                Path append = new Path(this.maze);
                append = tempP2;
                if (append.isTreasure(tempCoor[0]+1,tempCoor[1]))
                {
                    append.pickTreasure(tempCoor[0]+1,tempCoor[1]);
                }
                append.Append(tempCoor[0]+1,tempCoor[1]);
                coorMap.Enqueue(append);
                countVisited++;
            }
            //cek bagian kiri
            if (tempPath.canTravel(tempCoor[0],tempCoor[1]-1))
            {
                //cek apakah treasure
                Path append = new Path(this.maze);
                append = tempP3;
                if (append.isTreasure(tempCoor[0],tempCoor[1]-1))
                {
                    append.pickTreasure(tempCoor[0]-1,tempCoor[1]);
                }
                append.Append(tempCoor[0],tempCoor[1]-1);
                coorMap.Enqueue(append);
                countVisited++;
            }
            //cek bagian kanan
            if (tempPath.canTravel(tempCoor[0],tempCoor[1]+1))
            {
                //cek apakah treasure
                Path append = new Path(this.maze);
                append = tempP4;
                if (append.isTreasure(tempCoor[0],tempCoor[1]+1))
                {
                    append.pickTreasure(tempCoor[0],tempCoor[1]+1);
                }
                append.Append(tempCoor[0],tempCoor[1]+1);
                coorMap.Enqueue(append);
                countVisited++;
            }
        }
    }

    public void displayPath()
    {
        while (coorMap.Count != 0)
        {
            Path temp = coorMap.Dequeue();
            temp.displayCoord();
            temp.displayMaze();
        }
    }

    public void getCountVisited()
    {
        Console.WriteLine(countVisited);
    }
}
class DFS
{
    private Stack<Simpul> visited;
    private Stack<Simpul> result;
    private int count;
    private int countSteps;
    private int totalTreasure;
    private int countVisited;
    private int[,] maze;
    private int[,] visitedMaze;
    private int x;
    private int y;
    public DFS(int x, int y, int total, int[,] maze)
    {
        this.visited = new Stack<Simpul>();
        this.result = new Stack<Simpul>();
        this.x = x;
        this.y = y;
        this.totalTreasure = total;
        this.maze = maze;
        this.visitedMaze = (int[,]) maze.Clone();
        this.count = 0;
        this.countSteps = 0;
        this.countVisited = 0;
    }
    public void findPath()
    {
        Simpul first = new Simpul(this.x, this.y, maze);
        visitedMaze[x,y] = -1;
        visited.Push(first);
        result.Push(first);
        /*
            urutan prioritas :
            - kanan
            - bawah
            - kiri
            - atas
        */
        // int done = 0;
        // first.displaySimpul();
        Simpul top;
        bool valid;
        while (true)
        {
            // for (int i = 0 ; i < visitedMaze.GetLength(0) ; i++)
            // {
            //     for (int j = 0 ; j < visitedMaze.GetLength(1) ; j++)
            //     {
            //         Console.Write(visitedMaze[i,j] + " ");
            //     }
            //     Console.WriteLine();
            // }
            valid = true;
            top = new Simpul(visited.Pop());
            // top.displaySimpul();
            // done++;
            // top.displaySimpul();
            // Console.WriteLine(count);
            // Console.WriteLine("=====" + maze[top.getX(),top.getY()]);
            if (maze[top.getX(),top.getY()]==3)
            {
                count++;
                maze[top.getX(),top.getY()] = 2;
            }
            if (count == totalTreasure)
            {
                visited.Push(top);
                break;
            }
            if (top.canGoRight && valid)
            {
                // Console.WriteLine("");
                if (visitedMaze[top.getX(), top.getY()+1] != -1)
                {
                    Console.WriteLine("================================");
                    top.canGoRight = false;
                    Simpul temp = new Simpul(top.getX(), top.getY()+1, maze);
                    visited.Push(top);
                    visited.Push(temp);
                    result.Push(temp);
                    visitedMaze[top.getX(), top.getY()+1] = -1;
                    valid = false;
                    Console.WriteLine("R1");
                    top.displaySimpul();
                    Console.WriteLine("================================");
                }
            }
            if (top.canGoDown && valid)
            {
                Console.WriteLine("DOWN");
                if (visitedMaze[top.getX()+1, top.getY()] != -1)
                {
                    top.canGoDown = false;
                    Simpul temp = new Simpul(top.getX()+1, top.getY(), maze);
                    visited.Push(top);
                    visited.Push(temp);
                    result.Push(temp);
                    visitedMaze[top.getX()+1, top.getY()] = -1;
                    valid = false;
                    Console.WriteLine("D1");
                    top.displaySimpul();
                    Console.WriteLine("================================");
                }
            }
            if (top.canGoLeft && valid)
            {
                if (visitedMaze[top.getX(), top.getY()-1] != -1)
                {
                    top.canGoLeft = false;
                    Simpul temp = new Simpul(top.getX(), top.getY()-1, maze);
                    visited.Push(top);
                    visited.Push(temp);
                    result.Push(temp);
                    visitedMaze[top.getX(), top.getY()-1] = -1;
                    valid = false;
                    Console.WriteLine("L1");
                    top.displaySimpul();
                    Console.WriteLine("================================");
                }
            }
            if (top.canGoUp && valid)
            {
                if (visitedMaze[top.getX()-1, top.getY()] != -1)
                {
                    // Console.WriteLine("HAHAHAHAA");
                    Console.WriteLine("================================");
                    top.canGoUp = false;
                    Simpul temp = new Simpul(top.getX()-1, top.getY(), maze);
                    visited.Push(top);
                    visited.Push(temp);
                    result.Push(temp);
                    visitedMaze[top.getX()-1, top.getY()] = -1;
                    valid = false;
                    Console.WriteLine("U1");
                    top.displaySimpul();
                    Console.WriteLine("================================");
                }
            }
            if(valid)
            {
                visited.Push(top);
                Console.WriteLine("================================");
                top.displaySimpul();
                top = visited.Pop();
                top.displaySimpul();
                result.Push(visited.Peek());
                Console.WriteLine("POP");
                Console.WriteLine("================================");
            }
            this.countSteps++;
        }
    }
    public void displayPath()
    {
        Stack<Simpul> copy = new Stack<Simpul>(this.result);
        foreach (Simpul value in copy)
        {
            value.displaySimpul();
        }
    }

    public void displaySteps()
    {
        Console.WriteLine(this.countSteps);
    }

    public void displayVisited()
    {
        for (int i = 0; i < this.visitedMaze.GetLength(0); i++)
        {
            for (int j = 0; j < this.visitedMaze.GetLength(1); j++)
            {
                if (this.visitedMaze[i,j] == -1)
                {
                    this.countVisited++;
                }
                else
                {
                }
            }
        }
        Console.WriteLine(this.countVisited);
    }
}
class Simpul
{
    private int x;
    private int y;
    public bool canGoLeft;
    public bool canGoRight;
    public bool canGoDown;
    public bool canGoUp;
    int[,] maze;
    
    public Simpul(Simpul other)
    {
        this.x = other.x;
        this.y = other.y;
        this.maze = (int[,]) other.maze.Clone();
        this.canGoDown = other.canGoDown;
        this.canGoLeft = other.canGoLeft;
        this.canGoRight = other.canGoRight;
        this.canGoUp = other.canGoUp;
    }
    
    public Simpul(int x, int y, int[,] maze)
    {
        this.x = x;
        this.y = y;
        this.maze = maze;
        if (y+1 < maze.GetLength(1))
        {
            if(maze[x,y+1] != 0)
            {
                this.canGoRight = true;
            }
            else
            {
                this.canGoRight = false;
            }
        }
        else
        {
            this.canGoRight = false;
        }
        if (y - 1 >= 0)
        {
            if(maze[x,y-1] != 0)
            {
                this.canGoLeft = true;
            }
            else
            {
                this.canGoLeft = false;
            }
        }
        else
        {
            this.canGoLeft = false;
        }
        if (x - 1 >= 0)
        {
            if(maze[x-1,y] != 0)
            {
                this.canGoUp = true;
            }
            else
            {
                this.canGoUp = false;
            }
        }
        else
        {
            this.canGoUp = false;
        }
        if (x+1< maze.GetLength(0))
        {
            if (maze[x+1,y] != 0)
            {
                this.canGoDown = true;
            }
            else
            {
                this.canGoDown = false;
            }
        }
        else
        {
            this.canGoDown = false;
        }
    }
    
    public int getX()
    {
        return x;
    }
    
    public int getY()
    {
        return y;
    }
    
    public void displaySimpul()
    {
        Console.WriteLine(x + " " + y);
    }
}

class Path
{
    private int[,] arr;
    private int[,] maze;
    private bool filled;
    private int count;
    private int idx;
    public int[,] getArr()
    {
        return arr;
    }
    public Path(int[,] maze)
    {
        this.arr = new int[1,2];
        this.maze = maze;
        this.filled = false;
        this.count = 0;
        this.idx = -1;
    }
    public Path(Path other)
    {
        this.arr = (int[,])other.arr.Clone();
        this.maze = (int[,])other.maze.Clone();
        this.filled = other.filled;
        this.count = other.count;
        this.idx = other.idx;
    }
    public void displayMaze()
    {
        for (int i = 0 ; i<maze.GetLength(0) ; i++)
        {
            for (int j = 0 ;  j < maze.GetLength(1) ; j++)
            {
                Console.Write(maze[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void displayCoord()
    {
        for (int i = 0 ; i < arr.GetLength(0) ;i++)
        {
            for (int j = 0 ; j < 2 ;j++)
            {
                Console.Write(arr[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
    public int getIdx()
    {
        return this.idx;
    }
    public bool isTreasure(int x, int y)
    {
        if (maze[x,y] == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool canTravel(int x, int y)
    {
        if (x>=0 && x<maze.GetLength(0) && y>=0 && y<maze.GetLength(1))
        {
            if (maze[x,y] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void Append(int a, int b)
    {
        if (this.filled)
        {
            // Console.WriteLine(a);
            // Console.WriteLine(b);
            int[,] temp = new int[this.arr.GetLength(0)+1, this.arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    temp[i, j] = arr[i, j];
                }
            }
            temp[arr.GetLength(0),0] = a;
            temp[arr.GetLength(0),1] = b;
            this.arr = temp;
        }
        else
        {
            this.arr[0,0] = a;
            this.arr[0,1] = b;
            this.filled = true;
        }
        this.idx++;
    }
    public int[] getEl(int idx)
    {
        int[] ret = new int[2];
        ret[0] = this.arr[idx,0];
        ret[1] = this.arr[idx,1];
        return ret;
    }
    public int[,] getMaze()
    {
        return maze;
    }
    public void pickTreasure(int x, int y)
    {
        this.maze[x,y] = 2;
        count++;
    }
    public int getCount()
    {
        return count;
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
        int count = 0;
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
                    count++;
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
        }
        reader.Close();
        reader2.Close();
        // Simpul root;
        //bikin graph
        int x = 0;
        int y = 0;
        int treasure = 0;
        for (int i = 0 ; i < row ; i++)
        {
            for (int j = 0 ; j < col ; j++)
            {
                if(arr[i,j]==1)
                {
                   x = i;
                   y = j;
                }
                if(arr[i,j] == 3)
                {
                    treasure++;
                }
                Console.Write(arr[i,j]+" ");
            }
            Console.WriteLine();
        }
        // Console.WriteLine(treasure);
        // BFS root = new BFS(x,y,arr,treasure);
        // Console.WriteLine("Koordinat untuk mengambil semua treasure : ");
        // root.findPath();
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