class Simpul
    {
        private int x;
        private int y;
        public bool canGoLeft;
        public bool canGoRight;
        public bool canGoDown;
        public bool canGoUp;
        int[,] maze;
        private List<(int,int)> arr;
        private int idx;
        public Simpul(int x, int y, int[,] maze)
        {
            this.x = x;
            this.y = y;
            this.maze = (int[,])maze.Clone();
            this.arr = new List<(int,int)>();
            this.idx = -1;
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
        public Simpul(Simpul other)
        {
            this.x = other.x;
            this.y = other.y;
            this.maze = (int[,]) other.maze.Clone();
            this.canGoDown = other.canGoDown;
            this.canGoLeft = other.canGoLeft;
            this.canGoRight = other.canGoRight;
            this.canGoUp = other.canGoUp;
            this.arr = new List<(int,int)>(other.arr);
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
        public bool isVisited(int x, int y)
        {
            if (maze[x,y] == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isVisitedHome(int x, int y)
        {
            if (maze[x, y] == -2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void visit(int x, int y)
        {
            maze[x,y] = -1;
        }
        public void visitHome(int x, int y)
        {
            maze[x,y] = -2;
        }
        public List<(int,int)> getArr()
        {
            return this.arr;
        }
        public void Append(int x, int y)
        {
            this.arr.Add((x,y));
            this.idx++;
        }
        public void unite(Queue<Simpul> p)
        {
            bool first = true;
            foreach(Simpul value in p)
            {
                if (first)
                {
                    first = false;
                    foreach((int x, int y) in value.getArr())
                    {
                        this.arr.Add((x,y));
                    }
                }
                else
                {
                    for (int i = 1; i < value.getArr().Count() ; i++)
                    {
                        var (x,y) = value.getArr()[i];
                        this.arr.Add((x,y));
                    }
                }
            }
        }
        public void displayCoord()
        {
            foreach((int x, int y) in arr)
            {
                Console.WriteLine("(" + x + " " + y + ")");
            }
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
        public bool isHome(int x, int y)
        {
            if (maze[x, y] == 1)    { return true; }
            else                    { return false; }
        }
        public int getIdx()
        {
            return this.idx;
        }
        public int getX()
        {
            return x;
        }
        
        public int getY()
        {
            return y;
        }
        public int[] getEl(int id)
        {
            int[] ret = new int[2];
            var (x,y) = this.arr[id];
            ret[0] = x;
            ret[1] = y;
            return ret;
        }
        public void displaySimpul()
        {
            Console.WriteLine(x + " " + y);
        }
        public int[,] getMaze()
        {
            return maze;
        }
        public void pickTreasure(int x, int y)
        {
            this.maze[x,y] = 2;
        }
    }