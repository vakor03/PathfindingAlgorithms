using Vakor.PathfindingAlgorithms.Algorithms;

Labyrinth defaultLabyrinth = Labyrinth.GenerateDefaultMaze();
Lee lee = new Lee();
AStar aStar = new AStar();

Cell startPoint = new Cell(2,1);
Cell destPoint = new Cell(2,5);

Console.WriteLine("Lee algorithm");
PrintAlgoStatistics(defaultLabyrinth, lee, startPoint, destPoint);

Console.WriteLine("A* algorithm");
PrintAlgoStatistics(defaultLabyrinth, aStar, startPoint, destPoint);

void PrintAlgoStatistics(Labyrinth maze, IPathFindingAlgorithm pathFindingAlgorithm, Cell start, Cell dest)
{
    int dist = pathFindingAlgorithm.FindPath(defaultLabyrinth, start, dest, out List<Cell> path);
    Console.WriteLine($"Total distance: {dist}");
    
    PrintMaze(maze, path);
    Console.WriteLine();
}

void PrintMaze(Labyrinth maze, List<Cell> path)
{
    string[,] stringMaze = new string[maze.Height, maze.Width];
    for (int i = 0; i < stringMaze.GetLength(0); i++)
    {
        for (int j = 0; j < stringMaze.GetLength(1); j++)
        {
            stringMaze[i, j] = maze[i, j] == 1 ? "0" : "I";
        }
    }

    Cell start = path[0];
    Cell dest = path.Last();
    stringMaze[start.X, start.Y] = "S";
    stringMaze[dest.X, dest.Y] = "D";

    for (int i = 1; i < path.Count-1; i++)
    {
        Cell curr = path[i];
        stringMaze[curr.X, curr.Y] = i.ToString();
    }

    for (int i = 0; i < stringMaze.GetLength(0); i++)
    {
        for (int j = 0; j < stringMaze.GetLength(1); j++)
        {
            Console.Write($" {stringMaze[i,j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine(String.Join(" => ", path.Select(x => x.ToString()).ToArray()));
}

