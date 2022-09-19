// See https://aka.ms/new-console-template for more information

using Vakor.PathfindingAlgorithms;
using Vakor.PathfindingAlgorithms.Algorithms;

Maze maze = Maze.GenerateDefaultMaze();
LeeAlgorithm leeAlgorithm = new LeeAlgorithm();
AStarAlgorithm aStarAlgorithm = new AStarAlgorithm();

Coordinates startPoint = new Coordinates(2,1);
Coordinates destPoint = new Coordinates(2,5);

Console.WriteLine(leeAlgorithm.FindPath(maze, startPoint, destPoint, out List<Coordinates> coordsLee));
foreach (var coord in coordsLee)
{
    Console.WriteLine(coord);
}

Console.WriteLine(aStarAlgorithm.FindPath(maze, startPoint, destPoint, out List<Coordinates> coordsA));
foreach (var coord in coordsA)
{
    Console.WriteLine(coord);
}

