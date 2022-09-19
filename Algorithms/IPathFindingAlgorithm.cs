namespace Vakor.PathfindingAlgorithms.Algorithms;

public interface IPathFindingAlgorithm
{
    public int FindPath(Maze maze, Coordinates startPoint, Coordinates destPoint, out List<Coordinates> path);
}