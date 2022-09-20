namespace Vakor.PathfindingAlgorithms.Algorithms;

public class Lee : IPathFindingAlgorithm
{
    private readonly int[] _rowNum = { -1, 0, 0, 1 };
    private readonly int[] _colNum = { 0, -1, 1, 0 };

    public int FindPath(Labyrinth labyrinth, Cell startPoint, Cell destPoint, out List<Cell> path)
    {
        path = null!;
        if (labyrinth[startPoint] != 1 || labyrinth[destPoint] != 1)
        {
            return -1;
        }

        bool[,] visitedNodes = new bool[labyrinth.Height, labyrinth.Width];
        visitedNodes[startPoint.X, startPoint.Y] = true;

        Queue<Node> nodeQueue = new();
        nodeQueue.Enqueue(new Node(startPoint, 0, null!));

        while (nodeQueue.Count != 0)
        {
            Node current = nodeQueue.Dequeue();
            Cell cell = current.Cell;

            if (cell.X == destPoint.X && cell.Y == destPoint.Y)
            {
                path = CreatePath(current);
                return current.Distance;
            }

            for (int i = 0; i < 4; i++)
            {
                Cell adjCell = new Cell(current.Cell.X + _rowNum[i], current.Cell.Y + _colNum[i]);
                if (CheckCoordinates(adjCell, labyrinth) 
                    && labyrinth[adjCell] == 1 
                    && !visitedNodes[adjCell.X, adjCell.Y])
                {
                    visitedNodes[adjCell.X, adjCell.Y] = true;
                    nodeQueue.Enqueue(new Node(adjCell, current.Distance + 1, current));
                }
            }
        }

        return -1;
    }

    
    private bool CheckCoordinates(Cell cell, Labyrinth labyrinth)
    {
        return cell.X >= 0 && cell.Y >= 0 &&
               cell.X < labyrinth.Height && cell.Y < labyrinth.Width;
    }
    private List<Cell> CreatePath(Node currentNode)
    {
        List<Cell> path = new List<Cell>();

        var curNode = currentNode;
        path.Add(curNode.Cell);

        while (curNode.Distance != 0)
        {
            curNode = curNode.Parent;
            path.Add(curNode.Cell);
        }

        path.Reverse();
        return path;
    }
}