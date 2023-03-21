using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
        class Paths
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
            public Paths(int[,] maze)
            {
                this.arr = new int[1,2];
                this.maze = (int[,])maze.Clone();
                this.filled = false;
                this.count = 0;
                this.idx = -1;
            }
            public Paths(Paths other)
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
        class BFS
        {
            /*
                1 -> kanan
                2 -> bawah
                3 -> kiri
                4 -> atas
            */
            private Queue<String> path;
            private Queue<Paths> coorMap;
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
                this.maze = (int[,])arr.Clone();
                this.countSteps = 0;
                this.countVisited = 0;
                this.count = t;
                this.coorMap = new Queue<Paths>();
                //Lakukan pengecekan pada kanan start
                if (this.y+1 < this.maze.GetLength(1) && this.maze[x,y+1] != 0)
                {
                    // Console.WriteLine(this.maze.GetLength(0));
                    // Console.WriteLine(x+1)/;
                    Paths temp = new Paths(this.maze);
                    if(this.maze[x,y+1] == 3)
                    {
                        temp.pickTreasure(x,y+1);
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
                    Paths temp = new Paths(this.maze);
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
                //Lakukan pengecekan pada kiri start
                if (this.y-1 >= 0 && this.maze[x,y-1] != 0)
                {
                    Paths temp = new Paths(this.maze);
                    if(this.maze[x,y-1] == 3)
                    {
                        temp.pickTreasure(x,y-1);
                    }
                    temp.Append(x,y);
                    temp.Append(x,y-1);
                    // path.Enqueue("L");
                    this.coorMap.Enqueue(temp);
                    // Console.Write("L");
                }
                //Lakukan pengecekan pada atas start        
                if (this.x-1 >= 0 && this.maze[x-1,y] != 0)
                {
                    Paths temp = new Paths(this.maze);
                    if(this.maze[x-1,y] == 3)
                    {
                        temp.pickTreasure(x-1,y);
                    }
                    temp.Append(x,y);
                    temp.Append(x-1,y);
                    // path.Enqueue("U");
                    coorMap.Enqueue(temp); 
                    // Console.Write("Up");
                }
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
                int done = 0;
                while (true)
                {
                    done++;
                    //Ambil tiap jalurnya
                    Paths tempPath = coorMap.Dequeue();
                    int[] tempCoor = tempPath.getEl(tempPath.getIdx());
                    //Cek apakah sudah semua terambil
                    if (isDone(tempPath.getMaze()))
                    {
                        // Console.Write("PP");
                        tempPath.displayCoord();
                        // tempPath.displayMaze();
                        break;
                    }
                    // if (done>2000)
                    // {
                    //     break;
                    // }
                    //cek bagian kanan
                    Console.WriteLine("COUNT : " + coorMap.Count());
                    Console.WriteLine("=====================");
                    tempPath.displayCoord();
                    tempPath.displayMaze();
                    Console.WriteLine("=====================");
                    if (tempPath.canTravel(tempCoor[0],tempCoor[1]+1))
                    {
                        //cek apakah treasure
                        Paths append = new Paths(tempPath);
                        if (append.isTreasure(tempCoor[0],tempCoor[1]+1))
                        {
                            append.pickTreasure(tempCoor[0],tempCoor[1]+1);
                        }
                        append.Append(tempCoor[0],tempCoor[1]+1);
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian bawah
                    if (tempPath.canTravel(tempCoor[0]+1,tempCoor[1]))
                    {
                        //cek apakah treasure
                        Paths append = new Paths(tempPath);
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
                        Paths append = new Paths(tempPath);
                        if (append.isTreasure(tempCoor[0],tempCoor[1]-1))
                        {
                            append.pickTreasure(tempCoor[0],tempCoor[1]-1);
                        }
                        append.Append(tempCoor[0],tempCoor[1]-1);
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian atas
                    if (tempPath.canTravel(tempCoor[0]-1,tempCoor[1]))
                    {
                        //cek apakah treasure
                        Paths append = new Paths(tempPath);
                        if (append.isTreasure(tempCoor[0]-1,tempCoor[1]))
                        {
                            append.pickTreasure(tempCoor[0]-1,tempCoor[1]);
                        }
                        append.Append(tempCoor[0]-1,tempCoor[1]);
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    // Console.WriteLine(countVisited);
                }
            }

            public void displayPath()
            {
                while (coorMap.Count != 0)
                {
                    Paths temp = coorMap.Dequeue();
                    temp.displayCoord();
                    temp.displayMaze();
                }
            }

            public void getCountVisited()
            {
                Console.WriteLine(countVisited);
            }
        }
}
