namespace Tetris.ConsoleUi;

public class Printer : IPrinter
{
    public void Print(Board board, Block currentBlock)
    {
        Console.WriteLine("------------------Print------------------");
        foreach (var tile in board.Tiles)
        {
            Console.WriteLine($"X: {tile.X} Y: {tile.Y}");
        }

        foreach (var tile in currentBlock.Tiles)
        {
            Console.WriteLine($"X: {tile.X} Y: {tile.Y}");
        }
    }
}