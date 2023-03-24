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
                    temp.Append(x,y+1);
                    if (!tempProgress.isVisitedHome(x,y+1))
                    {
                        this.tempProgress.Append(x,y+1);
                    }
                    tempProgress.visitHome(x,y+1);
                    if(this.maze[x,y+1] == 1)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                        coorMap.Clear();
                    }
                    coorMap.Enqueue(temp);
                }
                //Lakukan pengecekan pada bawah start
                if (this.x+1 < this.maze.GetLength(0) && this.maze[x+1,y] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x+1,y);
                    if (!tempProgress.isVisitedHome(x+1,y))
                    {
                        this.tempProgress.Append(x+1,y);
                    }
                    tempProgress.visitHome(x+1,y);
                    if(this.maze[x+1,y] == 1)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                        coorMap.Clear();
                    }
                    coorMap.Enqueue(temp);
                }
                //Lakukan pengecekan pada kiri start
                if (this.y-1 >= 0 && this.maze[x,y-1] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x,y-1);
                    if (!tempProgress.isVisitedHome(x,y-1))
                    {
                        this.tempProgress.Append(x,y-1);
                    }
                    tempProgress.visitHome(x,y-1);
                    if(this.maze[x,y-1] == 1)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                        coorMap.Clear();
                    }
                    coorMap.Enqueue(temp);
                }
                //Lakukan pengecekan pada atas start
                if (this.x-1 >= 0 && this.maze[x-1,y] != 0 && ! found)
                {
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x-1,y);
                    if (!tempProgress.isVisitedHome(x-1,y))
                    {
                        this.tempProgress.Append(x-1,y);
                    }
                    tempProgress.visitHome(x-1,y);
                    if(this.maze[x-1,y] == 1)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                        coorMap.Clear();
                    }
                    coorMap.Enqueue(temp);
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
                    temp.Append(x,y+1);
                    if (!tempProgress.isVisited(x,y+1))
                    {
                        this.tempProgress.Append(x,y+1);
                    }
                    tempProgress.visit(x,y+1);
                    if(this.maze[x,y+1] == 3)
                    {
                        temp.pickTreasure(x,y+1);
                        found = true;
                        result.Enqueue(temp);
                        this.y =  y+ 1;
                        this.flag = false;
                        this.maze = (int[,])temp.getMaze().Clone();
                        coorMap.Clear();
                    }
                    coorMap.Enqueue(temp);
                    countVisited++;
                }
                //Lakukan pengecekan pada bawah start        
                if (this.x+1 < this.maze.GetLength(0) && this.maze[x+1,y] != 0 && !found && this.visitedMaze[x+1,y] != -1)
                {
                    this.visitedMaze[x+1,y] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x+1,y);
                    if (!tempProgress.isVisited(x+1,y))
                    {
                        this.tempProgress.Append(x+1,y);
                    }
                    tempProgress.visit(x+1,y);
                    if(this.maze[x+1,y] == 3 && !goHome)
                    {
                        temp.pickTreasure(x+1,y);
                        found = true;
                        result.Enqueue(temp);
                        this.x = x+1;
                        this.maze = (int[,])temp.getMaze().Clone();
                        this.flag = false;
                        coorMap.Clear();
                    }
                    else if (this.maze[x + 1, y] == 1 && goHome)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                    }
                    coorMap.Enqueue(temp);
                    countVisited++;
                }
                //Lakukan pengecekan pada kiri start
                if (this.y-1 >= 0 && this.maze[x,y-1] != 0 && !found && this.visitedMaze[x,y-1] != -1)
                {
                    this.visitedMaze[x,y-1] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x,y-1);
                    if (!tempProgress.isVisited(x,y-1))
                    {
                        this.tempProgress.Append(x,y-1);
                    }
                    tempProgress.visit(x,y-1);
                    if(this.maze[x,y-1] == 3 && !goHome)
                    {
                        temp.pickTreasure(x,y-1);
                        found = true;
                        result.Enqueue(temp);
                        this.maze = (int[,])temp.getMaze().Clone();
                        this.y = y-1;
                        this.flag = false;
                        coorMap.Clear();
                    }
                    else if (this.maze[x, y - 1] == 1 && goHome)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                    }
                    this.coorMap.Enqueue(temp);
                    countVisited++;
                }
                //Lakukan pengecekan pada atas start        
                if (this.x-1 >= 0 && this.maze[x-1,y] != 0 && ! found && this.visitedMaze[x-1,y] != -1)
                {
                    this.visitedMaze[x-1,y] = -1;
                    Simpul temp = new Simpul(x,y,this.maze);
                    temp.Append(x,y);
                    temp.Append(x-1,y);
                    if (!tempProgress.isVisited(x-1,y))
                    {
                        this.tempProgress.Append(x-1,y);
                    }
                    tempProgress.visit(x-1,y);
                    if(this.maze[x-1,y] == 3 && !goHome)
                    {
                        temp.pickTreasure(x-1,y);
                        found = true;
                        result.Enqueue(temp);
                        this.x = x-1;
                        this.flag = false;
                        this.maze = (int[,])temp.getMaze().Clone();
                        coorMap.Clear();
                    }
                    else if (this.maze[x - 1, y] == 1 && goHome)
                    {
                        found = true;
                        result.Enqueue(temp);
                        this.flag = false;
                    }
                    coorMap.Enqueue(temp); 
                    countVisited++;
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
            // public void findHome()
            // {
            //     while (true)
            //     {
            //         Simpul tempPath = coorMap.Dequeue();
            //         int [] tempCoor = tempPath.getEl(tempPath.getIdx());

            //     }
            // }
            public void findPath()
            {
                while (true)
                {
                    Simpul tempPath = coorMap.Dequeue();
                    int[] tempCoor = tempPath.getEl(tempPath.getIdx());
                    if (canTravel(tempCoor[0],tempCoor[1]+1) && this.visitedMaze[tempCoor[0],tempCoor[1]+1] != -1)
                    {
                        this.visitedMaze[tempCoor[0],tempCoor[1]+1] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        if (goHome) 
                        {
                            if (!tempProgress.isVisitedHome(tempCoor[0],tempCoor[1]+1))
                            {
                                this.tempProgress.Append(tempCoor[0],tempCoor[1]+1);
                            }
                            tempProgress.visitHome(tempCoor[0],tempCoor[1]+1);
                            append.Append(tempCoor[0],tempCoor[1]+1);
                            if (append.isHome(tempCoor[0], tempCoor[1] + 1) && goHome)
                            {
                                result.Enqueue(append);
                                break;
                            }
                        }
                        else
                        {
                            if (!tempProgress.isVisited(tempCoor[0],tempCoor[1]+1))
                            {
                                this.tempProgress.Append(tempCoor[0],tempCoor[1]+1);
                            }
                            tempProgress.visit(tempCoor[0],tempCoor[1]+1);
                            append.Append(tempCoor[0],tempCoor[1]+1);
                            if (append.isTreasure(tempCoor[0],tempCoor[1]+1))
                            {
                                append.pickTreasure(tempCoor[0],tempCoor[1]+1);
                                result.Enqueue(append);
                                coorMap.Clear();
                                this.x = tempCoor[0];
                                this.y = tempCoor[1] + 1;
                                this.maze = (int[,])append.getMaze().Clone();
                                break;
                            }
                        }
                        
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian bawah
                    if (canTravel(tempCoor[0]+1,tempCoor[1]) && this.visitedMaze[tempCoor[0]+1,tempCoor[1]] != -1)
                    {
                        this.visitedMaze[tempCoor[0]+1,tempCoor[1]] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        if (goHome) 
                        {
                            if (!tempProgress.isVisitedHome(tempCoor[0] + 1,tempCoor[1]))
                            {
                                this.tempProgress.Append(tempCoor[0] + 1,tempCoor[1]);
                            }
                            tempProgress.visitHome(tempCoor[0] + 1,tempCoor[1]);
                            append.Append(tempCoor[0] + 1,tempCoor[1]);
                            if (append.isHome(tempCoor[0] + 1, tempCoor[1]) && goHome)
                            {
                                result.Enqueue(append);
                                break;
                            }
                        }
                        else
                        {
                            if (!tempProgress.isVisited(tempCoor[0]+1,tempCoor[1]))
                            {
                                this.tempProgress.Append(tempCoor[0]+1,tempCoor[1]);
                            }
                            tempProgress.visit(tempCoor[0]+1,tempCoor[1]);
                            append.Append(tempCoor[0]+1,tempCoor[1]);
                            if (append.isTreasure(tempCoor[0]+1,tempCoor[1]))
                            {
                                append.pickTreasure(tempCoor[0]+1,tempCoor[1]);
                                result.Enqueue(append);
                                coorMap.Clear();
                                this.maze = (int[,])append.getMaze().Clone();
                                this.x = tempCoor[0] + 1;
                                this.y = tempCoor[1];
                                break;
                            }
                        }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian kiri
                    if (canTravel(tempCoor[0],tempCoor[1]-1) && this.visitedMaze[tempCoor[0],tempCoor[1]-1] != -1)
                    {
                        //cek apakah treasure
                        this.visitedMaze[tempCoor[0],tempCoor[1]-1] = -1;
                        Simpul append = new Simpul(tempPath);
                        if (goHome) 
                        {
                            if (!tempProgress.isVisitedHome(tempCoor[0], tempCoor[1] - 1))
                            {
                                this.tempProgress.Append(tempCoor[0], tempCoor[1] - 1);
                            }
                            tempProgress.visitHome(tempCoor[0], tempCoor[1] - 1);
                            append.Append(tempCoor[0], tempCoor[1] - 1);
                            if (append.isHome(tempCoor[0],  tempCoor[1] - 1) && goHome)
                            {
                                result.Enqueue(append);
                                break;
                            }
                        }
                        else
                        {
                            if (!tempProgress.isVisited(tempCoor[0],tempCoor[1]-1))
                            {
                                this.tempProgress.Append(tempCoor[0],tempCoor[1]-1);
                            }
                            tempProgress.visit(tempCoor[0],tempCoor[1]-1);
                            append.Append(tempCoor[0],tempCoor[1]-1);
                            if (append.isTreasure(tempCoor[0],tempCoor[1]-1))
                            {
                                append.pickTreasure(tempCoor[0],tempCoor[1]-1);
                                result.Enqueue(append);
                                coorMap.Clear();
                                this.maze = (int[,])append.getMaze().Clone();
                                this.x = tempCoor[0];
                                this.y = tempCoor[1] - 1;
                                break;
                            }
                        }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    //cek bagian atas
                    if (canTravel(tempCoor[0]-1,tempCoor[1]) && this.visitedMaze[tempCoor[0]-1,tempCoor[1]] != -1)
                    {
                        this.visitedMaze[tempCoor[0]-1,tempCoor[1]] = -1;
                        //cek apakah treasure
                        Simpul append = new Simpul(tempPath);
                        if (goHome) 
                        {
                            if (!tempProgress.isVisitedHome(tempCoor[0] - 1,tempCoor[1]))
                            {
                                this.tempProgress.Append(tempCoor[0] - 1,tempCoor[1]);
                            }
                            tempProgress.visitHome(tempCoor[0] - 1,tempCoor[1]);
                            append.Append(tempCoor[0] - 1,tempCoor[1]);
                            if (append.isHome(tempCoor[0] - 1, tempCoor[1]) && goHome)
                            {
                                result.Enqueue(append);
                                break;
                            }
                        }
                        else
                        {
                            if (!tempProgress.isVisited(tempCoor[0]-1,tempCoor[1]))
                            {
                                this.tempProgress.Append(tempCoor[0]-1,tempCoor[1]);
                            }
                            tempProgress.visit(tempCoor[0]-1,tempCoor[1]);
                            append.Append(tempCoor[0]-1,tempCoor[1]);
                            if (append.isTreasure(tempCoor[0]-1,tempCoor[1]))
                            {
                                append.pickTreasure(tempCoor[0]-1,tempCoor[1]);
                                result.Enqueue(append);
                                coorMap.Clear();
                                this.maze = (int[,])append.getMaze().Clone();
                                this.x = tempCoor[0]-1;
                                this.y = tempCoor[1];
                                break;
                            }
                        }
                        coorMap.Enqueue(append);
                        countVisited++;
                    }
                    // Console.WriteLine(countVisited);
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
