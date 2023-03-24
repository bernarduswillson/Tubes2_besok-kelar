using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
        class BFS
        {
            private Queue<String> path;
            private bool flag;
            private Queue<Simpul> coorMap;
            private Queue<Simpul> result;
            private Queue<Simpul> progress;
            private Simpul tempProgress;
            private int x;
            private int[,] maze;
            private int[,] visitedMaze;
            private int y;
            private int count;
            private int countSteps;
            private int countVisited;
            private bool goHome;
            public BFS(int x, int y, int[,] arr, int t)
            {
                this.x = x;
                this.y = y;
                this.maze = (int[,])arr.Clone();
                this.countSteps = 0;
                this.countVisited = 0;
                this.count = t;
                this.coorMap = new Queue<Simpul>();
                this.result = new Queue<Simpul>();
                this.visitedMaze = (int[,])arr.Clone();
                this.tempProgress = new Simpul(x,y,maze);
                this.progress = new Queue<Simpul>();
                this.goHome = false;
                //Lakukan pengecekan pada kanan start
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
            public void initHome()
            {
                this.coorMap = new Queue<Simpul>();
                bool found = false;
                if (!tempProgress.isVisitedHome(x,y))
                {
                    tempProgress.Append(x,y);
                    tempProgress.visitHome(x,y);
                }
                //Lakukan pengecekan pada atas start
                if (this.y+1 < this.maze.GetLength(1) && this.maze[x,y+1] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInitHome(x, y + 1, ref temp, ref found);
                }
                //Lakukan pengecekan pada bawah start
                if (this.x+1 < this.maze.GetLength(0) && this.maze[x+1,y] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInitHome(x + 1, y, ref temp, ref found);
                }
                //Lakukan pengecekan pada kiri start
                if (this.y-1 >= 0 && this.maze[x,y-1] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInitHome(x, y - 1, ref temp, ref found);
                }
                //Lakukan pengecekan pada atas start
                if (this.x-1 >= 0 && this.maze[x-1,y] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInitHome(x - 1, y, ref temp, ref found);
                }
                
            }
            public void init()
            {
                countVisited++;
                this.coorMap = new Queue<Simpul>();
                bool found = false;
                if (!tempProgress.isVisited(x,y))
                {
                    tempProgress.Append(x,y);
                    tempProgress.visit(x,y);
                }
                if (this.y+1 < this.maze.GetLength(1) && this.maze[x,y+1] != 0 && ! found && this.visitedMaze[x,y+1] != -1)
                {
                    this.visitedMaze[x,y+1] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInit(x, y + 1, ref temp, ref found);
                }
                //Lakukan pengecekan pada bawah start        
                if (this.x+1 < this.maze.GetLength(0) && this.maze[x+1,y] != 0 && !found && this.visitedMaze[x+1,y] != -1)
                {
                    this.visitedMaze[x+1,y] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInit(x + 1, y, ref temp, ref found);
                }
                //Lakukan pengecekan pada kiri start
                if (this.y-1 >= 0 && this.maze[x,y-1] != 0 && !found && this.visitedMaze[x,y-1] != -1)
                {
                    this.visitedMaze[x,y-1] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInit(x, y - 1, ref temp, ref found);
                }
                //Lakukan pengecekan pada atas start        
                if (this.x-1 >= 0 && this.maze[x-1,y] != 0 && ! found && this.visitedMaze[x-1,y] != -1)
                {
                    this.visitedMaze[x-1,y] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    enqueueResultInit(x - 1, y, ref temp, ref found);
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
                bool stopLoop = false;
                while (true)
                {
                    Simpul tempPath = coorMap.Dequeue();
                    int[] tempCoor = tempPath.getEl(tempPath.getIdx());
                    if (canTravel(tempCoor[0],tempCoor[1]+1) && this.visitedMaze[tempCoor[0],tempCoor[1]+1] != -1)
                    {
                        this.visitedMaze[tempCoor[0],tempCoor[1]+1] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        processPath(tempCoor[0],tempCoor[1]+1, ref tempPath, ref append, ref stopLoop);
                       
                        if (stopLoop) { break; }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian bawah
                    if (canTravel(tempCoor[0]+1,tempCoor[1]) && this.visitedMaze[tempCoor[0]+1,tempCoor[1]] != -1)
                    {
                        this.visitedMaze[tempCoor[0]+1,tempCoor[1]] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        processPath(tempCoor[0]+1,tempCoor[1], ref tempPath, ref append, ref stopLoop);
                        if (stopLoop) { break; }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian kiri
                    if (canTravel(tempCoor[0],tempCoor[1]-1) && this.visitedMaze[tempCoor[0],tempCoor[1]-1] != -1)
                    {
                        //cek apakah treasure
                        this.visitedMaze[tempCoor[0],tempCoor[1]-1] = -1;
                        Simpul append = new Simpul(tempPath);
                        processPath(tempCoor[0],tempCoor[1]-1, ref tempPath, ref append, ref stopLoop);
                        if (stopLoop) { break; }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian atas
                    if (canTravel(tempCoor[0]-1,tempCoor[1]) && this.visitedMaze[tempCoor[0]-1,tempCoor[1]] != -1)
                    {
                        this.visitedMaze[tempCoor[0]-1,tempCoor[1]] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        processPath(tempCoor[0]-1,tempCoor[1], ref tempPath, ref append, ref stopLoop);
                        if (stopLoop) { break; }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                }
            }
            public void finalTSP()
            {
                finalSearch();
                goHome = true;
                tempProgress = new Simpul(x,y,maze);
                this.flag = true;
                initHome();
                findPath();
                progress.Enqueue(tempProgress);
                Simpul res = new Simpul(x,y,maze);
                res.unite(result);

            }
            public void finalSearch()
            {
                /*
                HASILNYA DISIMPAN DI
                Jalur : res (harus di unite dulu kyk dibawah)
                Progress : progress
                */
                int tempCount = 0;
                tempProgress = new Simpul(x,y,maze);
                this.flag = true;
                while(tempCount<count)
                {
                    tempProgress = new Simpul(x,y,maze);
                    init();
                    if (this.flag)
                    {
                        findPath();
                    }
                    progress.Enqueue(tempProgress);
                    this.flag = true;
                    tempCount++;
                    for (int i = 0 ; i < this.visitedMaze.GetLength(0) ; i++)
                    {
                        for (int j = 0 ; j < this.visitedMaze.GetLength(1) ; j++)
                        {
                            if (visitedMaze[i,j] == -1)
                            {
                                visitedMaze[i,j] = 2;
                            }
                        }
                    }
                }
                
                Simpul res = new Simpul(x,y,maze);
                res.unite(result);
                res.displayCoord();
                
                Console.WriteLine("Progressnya");
                foreach(Simpul value in progress)
                {
                    value.displayCoord();
                    Console.WriteLine("===============");
                }
            }

            public void enqueueResultInitHome(int a, int b, ref Simpul temp, ref bool found)
            {
                temp.Append(a, b);
                if (!this.tempProgress.isVisitedHome(a, b))
                {
                    this.tempProgress.Append(a, b);
                }
                this.tempProgress.visitHome(a, b);
                if (temp.isHome(a, b))
                {
                    found = true;
                    this.result.Enqueue(temp);
                    this.flag = false;
                    this.coorMap.Clear();
                }
                this.coorMap.Enqueue(temp);
            }

            public void enqueueResultInit(int a, int b, ref Simpul temp, ref bool found)
            {
                temp.Append(a, b);
                if (!this.tempProgress.isVisited(a, b))
                {
                    this.tempProgress.Append(a, b);
                }
                this.tempProgress.visit(a, b);
                if (temp.isTreasure(a, b))
                {
                    temp.pickTreasure(a, b);
                    found = true;
                    this.result.Enqueue(temp);
                    this.flag = false;
                    this.x = a;
                    this.y = b;
                    this.maze = (int[,])temp.getMaze().Clone();
                    this.coorMap.Clear();
                }
                this.coorMap.Enqueue(temp);
                this.countVisited++;
            }

            public void processPath(int x, int y, ref Simpul tempPath, ref Simpul append, ref bool stopLoop)
            {
                if (goHome)
                {
                    if (!tempProgress.isVisitedHome(x, y))
                    {
                        this.tempProgress.Append(x, y);
                    }
                    tempProgress.visitHome(x, y);
                    append.Append(x, y);
                    if (append.isHome(x, y))
                    {
                        result.Enqueue(append);
                        stopLoop = true;
                    }
                }
                else
                {
                    if (!tempProgress.isVisited(x, y))
                    {
                        this.tempProgress.Append(x, y);
                    }
                    tempProgress.visit(x, y);
                    append.Append(x, y);
                    if (append.isTreasure(x, y))
                    {
                        append.pickTreasure(x, y);
                        result.Enqueue(append);
                        this.coorMap.Clear();
                        this.x = x;
                        this.y = y;
                        this.maze = (int[,])append.getMaze().Clone();
                        stopLoop = true;
                    }
                }     
            }

            public void displayPath()
            {
                while (coorMap.Count != 0)
                {
                    Simpul temp = coorMap.Dequeue();
                    temp.displayCoord();
                    temp.displayMaze();
                }
            }

            public Queue<Simpul> getResult()
            {
                return this.result;
            }

            public Queue<Simpul> getProgress()
            {
                return this.progress;
            }
            public int getStep()
            {
                Simpul res = new Simpul(x,y,maze);
                res.unite(result);
                return res.getArr().Count()-1;
            }
            public String getRoute()
            {
                String res = "";
                Simpul route = new Simpul(x,y,maze);
                route.unite(result);
                for (int i = 1; i < route.getArr().Count() ; i++)
                {
                    var (px, py) = route.getArr()[i-1];
                    var (x,y) = route.getArr()[i];
                    if (x-px == 1)
                    {
                        res+="D ";
                    }
                    else if (x-px == -1)
                    {
                        res+="U ";
                    }
                    else if(y-py == 1)
                    {
                        res+="R ";
                    }
                    else if (y-py == -1)
                    {
                        res+="L ";
                    }
                }
                return res;
            }
            public int getCountVisited()
            {
                return countVisited;
            }
        }
}
