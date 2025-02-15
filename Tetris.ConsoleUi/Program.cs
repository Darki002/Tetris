namespace Tetris.ConsoleUi;

public static class Program
{
    private static Game game = null!;
    
    public static void Main()
    {
        game = new Game(new Printer());
        game.Start();

        while (game.IsGameOver is false) { }
    }
}