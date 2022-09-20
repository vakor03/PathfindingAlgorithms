namespace Vakor.PathfindingAlgorithms.Algorithms;

public class Node
{
    public Node Parent { get; }
    public Cell Cell { get; }
    public int Distance { get; }

    public Node(Cell cell, int distance, Node parent)
    {
        Cell = cell;
        Distance = distance;
        Parent = parent;
    }
}