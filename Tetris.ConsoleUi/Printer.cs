namespace Tetris.ConsoleUi;

public class Printer : IPrinter
{
    public void Print(IReadOnlyList<Tile> updatedTiles)
    {
        Console.Clear();

        for (var i = 0; i < Board.Height; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("||");
            
            Console.SetCursorPosition((Board.Width + 1) * 2, i);
            Console.Write("||");
        }
        
        for (var i = 0; i < Board.Width; i++)
        {
            Console.SetCursorPosition(i * 2, 0);
            Console.Write("||");
            
            Console.SetCursorPosition(i * 2, Board.Height + 1);
            Console.Write("||");
        }
        
        foreach (var tile in updatedTiles)
        {
            Console.SetCursorPosition(tile.X * 2 + 1, Board.Height - tile.Y + 1);
            Console.Write("[]");
        }
    }
}