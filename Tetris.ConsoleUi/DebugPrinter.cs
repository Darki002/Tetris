using Tetris.Enums;

namespace Tetris.ConsoleUi;

public class DebugPrinter : IPrinter
{
    public void Print(BlockType?[,] updatedTiles)
    {
        Console.WriteLine("------------------Print------------------");

        for (var x = 0; x < Board.Width; x++)
        {
            for (var y = 0; y < Board.Height; y++)
            {
                Console.WriteLine($"X: {x} Y: {x} : {updatedTiles[x,y]}");
            }
        }
    }
}