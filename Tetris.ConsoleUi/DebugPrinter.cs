namespace Tetris.ConsoleUi;

public class DebugPrinter : IPrinter
{
    public void Print(IReadOnlyList<Tile> updatedTiles)
    {
        Console.WriteLine("------------------Print------------------");
        
        foreach (var tile in updatedTiles)
        {
            Console.WriteLine($"X: {tile.X} Y: {tile.Y}");
        }
    }
}