using System.Timers;
using Timer = System.Timers.Timer;

namespace Tetris;

public class Game
{
    private readonly IPrinter printer;
    private readonly Timer timer;

    private readonly Board board;
    private Block? currentBlock;

    public Game(IPrinter printer)
    {
        this.printer = printer;
        board = new Board();
        timer = new Timer();
        timer.Interval = 1000 * 2;
        timer.Elapsed += GameLoop;
    }

    public bool IsGameOver = false;

    public void Start()
    {
        timer.Start();
    }

    private void GameLoop(object? _, ElapsedEventArgs __)
    {
        currentBlock ??= CreateNewBlock();
        
        // TODO move block by User Input

        if (board.IsBlocked(currentBlock))
        {
            board.AddBlock(currentBlock);
            currentBlock = null;
            IsGameOver = board.IsGameOver();
            if(IsGameOver) timer.Stop();
            return;
        }
        
        currentBlock.MoveDown();
        printer.Print(board, currentBlock);
    }

    private static Block CreateNewBlock()
    {
        return new Block(BlockType.Test);
    }
}