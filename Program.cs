// See https://aka.ms/new-console-template for more information

using Vakor.PathfindingAlgorithms;
using Vakor.PathfindingAlgorithms.Algorithms;

Maze maze = Maze.GenerateDefaultMaze();
LeeAlgorithm leeAlgorithm = new LeeAlgorithm();

Coordinates startPoint = new Coordinates(0,0);
Coordinates destPoint = new Coordinates(4,4);

Console.WriteLine(leeAlgorithm.FindPath(maze, startPoint, destPoint, out List<Coordinates> coords));
foreach (var coord in coords)
{
    Console.WriteLine(coord);
}
