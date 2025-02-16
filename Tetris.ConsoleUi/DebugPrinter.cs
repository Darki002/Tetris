namespace Tetris.ConsoleUi;

public class DebugPrinter : IPrinter
{
    public void Print(Board board, Block currentBlock)
    {
        Console.WriteLine("------------------Print------------------");
        
        Console.WriteLine("Current Block:");
        foreach (var tile in currentBlock.Tiles)
        {
            Console.WriteLine($"X: {tile.X} Y: {tile.Y}");
        }
        
        Console.WriteLine("Board:");
        
        foreach (var tile in board.Tiles)
        {
            Console.WriteLine($"X: {tile.X} Y: {tile.Y}");
        }
    }
}