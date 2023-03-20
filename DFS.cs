using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
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
            this.visitedMaze = (int[,])maze.Clone();
            this.count = 0;
            this.countSteps = 0;
            this.countVisited = 0;
        }
        public void findPath()
        {
            Simpul first = new Simpul(this.x, this.y, maze);
            visitedMaze[x, y] = -1;
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
                if (maze[top.getX(), top.getY()] == 3)
                {
                    count++;
                    maze[top.getX(), top.getY()] = 2;
                }
                if (count == totalTreasure)
                {
                    visited.Push(top);
                    break;
                }
                if (top.canGoRight && valid)
                {
                    // Console.WriteLine("");
                    if (visitedMaze[top.getX(), top.getY() + 1] != -1)
                    {
                        // Console.WriteLine("================================");
                        top.canGoRight = false;
                        Simpul temp = new Simpul(top.getX(), top.getY() + 1, maze);
                        visited.Push(top);
                        visited.Push(temp);
                        result.Push(temp);
                        visitedMaze[top.getX(), top.getY() + 1] = -1;
                        valid = false;
                        // Console.WriteLine("R1");
                        // top.displaySimpul();
                        // Console.WriteLine("================================");
                    }
                }
                if (top.canGoDown && valid)
                {
                    // Console.WriteLine("DOWN");
                    if (visitedMaze[top.getX() + 1, top.getY()] != -1)
                    {
                        top.canGoDown = false;
                        Simpul temp = new Simpul(top.getX() + 1, top.getY(), maze);
                        visited.Push(top);
                        visited.Push(temp);
                        result.Push(temp);
                        visitedMaze[top.getX() + 1, top.getY()] = -1;
                        valid = false;
                        // Console.WriteLine("D1");
                        // top.displaySimpul();
                        // Console.WriteLine("================================");
                    }
                }
                if (top.canGoLeft && valid)
                {
                    if (visitedMaze[top.getX(), top.getY() - 1] != -1)
                    {
                        top.canGoLeft = false;
                        Simpul temp = new Simpul(top.getX(), top.getY() - 1, maze);
                        visited.Push(top);
                        visited.Push(temp);
                        result.Push(temp);
                        visitedMaze[top.getX(), top.getY() - 1] = -1;
                        valid = false;
                        // Console.WriteLine("L1");
                        // top.displaySimpul();
                        // Console.WriteLine("================================");
                    }
                }
                if (top.canGoUp && valid)
                {
                    if (visitedMaze[top.getX() - 1, top.getY()] != -1)
                    {
                        // Console.WriteLine("HAHAHAHAA");
                        // Console.WriteLine("================================");
                        top.canGoUp = false;
                        Simpul temp = new Simpul(top.getX() - 1, top.getY(), maze);
                        visited.Push(top);
                        visited.Push(temp);
                        result.Push(temp);
                        visitedMaze[top.getX() - 1, top.getY()] = -1;
                        valid = false;
                        // Console.WriteLine("U1");
                        // top.displaySimpul();
                        // Console.WriteLine("================================");
                    }
                }
                if (valid)
                {
                    visited.Push(top);
                    // Console.WriteLine("================================");
                    // top.displaySimpul();
                    top = visited.Pop();
                    // top.displaySimpul();
                    result.Push(visited.Peek());
                    // Console.WriteLine("POP");
                    // Console.WriteLine("================================");
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
                    if (this.visitedMaze[i, j] == -1)
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

        public Stack<Simpul> getResult()
        {
            return this.result;
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
            this.maze = (int[,])other.maze.Clone();
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
            if (y + 1 < maze.GetLength(1))
            {
                if (maze[x, y + 1] != 0)
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
                if (maze[x, y - 1] != 0)
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
                if (maze[x - 1, y] != 0)
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
            if (x + 1 < maze.GetLength(0))
            {
                if (maze[x + 1, y] != 0)
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
}
