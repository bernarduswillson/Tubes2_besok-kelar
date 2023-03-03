using System;
using System.Collections.Generic;

class MazeSolverBFS
{
    // Define the directions for exploring the maze
    private static readonly int[] dx = { 1, 0, -1, 0 };
    private static readonly int[] dy = { 0, 1, 0, -1 };

    // Define the maze size and maze
    private static int n, m;
    private static char[,] maze;

    // Define a class to hold the coordinates of the maze
    private class Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static void Main()
    {
        // Initialize the maze
        n = 5;
        m = 5;
        maze = new char[n, m]
        {
            {'S', '.', '.', '#', '.'},
            {'.', '#', '.', '.', '.'},
            {'.', '.', '#', '.', '.'},
            {'.', '#', '.', '#', '.'},
            {'.', '.', '.', '.', 'E'}
        };

        // Start the BFS from the starting point
        Coordinate start = new Coordinate(0, 0);
        Coordinate end = BFS(start);

        // Print the path from the starting point to the end point
        if (end != null)
        {
            List<Coordinate> path = new List<Coordinate>();
            while (end.x != start.x || end.y != start.y)
            {
                path.Add(end);
                end = end.parent;
            }
            path.Add(start);
            path.Reverse();

            foreach (Coordinate c in path)
            {
                Console.Write($"({c.x},{c.y}) ");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }

    private static Coordinate BFS(Coordinate start)
    {
        Queue<Coordinate> queue = new Queue<Coordinate>();
        bool[,] visited = new bool[n, m];

        queue.Enqueue(start);
        visited[start.x, start.y] = true;

        while (queue.Count > 0)
        {
            Coordinate curr = queue.Dequeue();

            if (maze[curr.x, curr.y] == 'E')
            {
                return curr;
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = curr.x + dx[i];
                int ny = curr.y + dy[i];

                if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;
                if (visited[nx, ny]) continue;
                if (maze[nx, ny] == '#') continue;

                visited[nx, ny] = true;
                Coordinate next = new Coordinate(nx, ny);
                next.parent = curr;
                queue.Enqueue(next);
            }
        }

        return null;
    }
}
