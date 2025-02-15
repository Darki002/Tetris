using System.Timers;
using Timer = System.Timers.Timer;

namespace Tetris;

public class Game
{
    private readonly Timer timer;

    private readonly Board board;
    private Block? currentBlock;

    public Game()
    {
        board = new Board();
        timer = new Timer();
        timer.Interval = 1000 * 2;
        timer.Elapsed += GameLoop;
    }
    
    public void Start() => timer.Start();

    private void GameLoop(object? _, ElapsedEventArgs __)
    {
        currentBlock ??= CreateNewBlock();
        
        // TODO move block by User Input

        if (board.IsBlocked(currentBlock))
        {
            board.AddBlock(currentBlock);
            currentBlock = null;
            return;
        }
        
        currentBlock.MoveDown();
    }

    private static Block CreateNewBlock()
    {
        return new Block(BlockType.Test);
    }
}