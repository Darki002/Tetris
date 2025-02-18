using Tetris.Enums;

namespace Tetris.ConsoleUi;

public static class Program
{
    private static Game game = null!;
    
    public static void Main()
    {
        game = new Game(new DebugPrinter());
        game.Start();

        while (game.IsGameOver is false)
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    game.SetNextMoveDir(BlockAction.Right);
                    break;
                case ConsoleKey.LeftArrow:
                    game.SetNextMoveDir(BlockAction.Left);
                    break;
            }
        }
    }
}