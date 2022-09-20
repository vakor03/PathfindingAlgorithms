namespace Vakor.PathfindingAlgorithms.Algorithms;

public interface IPathFindingAlgorithm
{
    public int FindPath(Labyrinth labyrinth, Cell startPoint, Cell destPoint, out List<Cell> path);
}