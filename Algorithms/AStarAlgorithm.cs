namespace Vakor.PathfindingAlgorithms.Algorithms;

public class AStarAlgorithm : IPathFindingAlgorithm
{
    private bool[,] _visitedNodes;
    static readonly int[] RowNum = { -1, 0, 0, 1 };
    static readonly int[] ColNum = { 0, -1, 1, 0 };

    public int FindPath(Maze maze, Coordinates startPoint, Coordinates destPoint, out List<Coordinates> path)
    {
        path = null!;
        if (maze[startPoint] != 1 || maze[destPoint] != 1)
        {
            return -1;
        }

        _visitedNodes = new bool[maze.Height, maze.Width];
        _visitedNodes[startPoint.X, startPoint.Y] = true;

        PriorityQueue<QueueNode, int> nodeQueue = new();
        QueueNode startNode = new QueueNode(startPoint, 0, null!);
        nodeQueue.Enqueue(startNode, FindHeuristic(startNode, destPoint));
        
        //Counter
        int counter = 0;

        while (nodeQueue.Count != 0)
        {
            counter++;
            QueueNode current = nodeQueue.Dequeue();
            Coordinates coordinates = current.Coordinates;

            if (coordinates.X == destPoint.X && coordinates.Y == destPoint.Y)
            {
                Console.WriteLine(counter);//Not needed
                path = RestorePath(current);
                return current.Distance;
            }

            for (int i = 0; i < 4; i++)
            {
                Coordinates adjCoordinates =
                    new Coordinates(coordinates.X + RowNum[i], coordinates.Y + ColNum[i]);
                if (CheckValid(adjCoordinates, maze) && maze[adjCoordinates] == 1 &&
                    !_visitedNodes[adjCoordinates.X, adjCoordinates.Y])
                {
                    _visitedNodes[adjCoordinates.X, adjCoordinates.Y] = true;

                    QueueNode adjNode = new QueueNode(adjCoordinates, current.Distance + 1, current);
                    nodeQueue.Enqueue(adjNode, FindHeuristic(adjNode, destPoint));
                }
            }
        }

        return -1;
    }

    private int FindHeuristic(QueueNode current, Coordinates destPoint)
    {
        return current.Distance + Math.Abs(destPoint.X - current.Coordinates.X) +
               Math.Abs(destPoint.Y - current.Coordinates.Y);
    }

    private bool CheckValid(Coordinates coordinates, Maze currMaze)
    {
        return coordinates.X >= 0 && coordinates.Y >= 0 &&
               coordinates.X < currMaze.Height && coordinates.Y < currMaze.Width;
    }

    private List<Coordinates> RestorePath(QueueNode currentNode)
    {
        List<Coordinates> path = new List<Coordinates>();

        var curNode = currentNode;
        path.Add(curNode.Coordinates);

        while (curNode.Distance != 0)
        {
            curNode = curNode.PreviousNode;
            path.Add(curNode.Coordinates);
        }

        path.Reverse();
        return path;
    }
}