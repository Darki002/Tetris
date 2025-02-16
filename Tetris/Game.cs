using System.Timers;
using Tetris.Enums;
using Timer = System.Timers.Timer;

namespace Tetris;

public class Game
{
    private readonly IPrinter printer;
    private readonly Timer timer;

    private readonly Board board;
    private Block? currentBlock;

    private Direction? nextMoveDir;

    public Game(IPrinter printer)
    {
        this.printer = printer;
        board = new Board();
        timer = new Timer();
        timer.Interval = 1000 * 2;
        timer.Elapsed += GameLoop;
    }

    public bool IsGameOver = false;

    public void Start() => timer.Start();

    private void GameLoop(object? _, ElapsedEventArgs __)
    {
        currentBlock ??= BlockTemplates.GetRandom();

        if (nextMoveDir is not null)
        {
            Console.WriteLine(nextMoveDir);
            currentBlock.TryMove(nextMoveDir);
            nextMoveDir = null;
        }

        if (board.IsBlocked(currentBlock))
        {
            board.AddBlock(currentBlock);
            currentBlock = null;

            board.TryRemoveRows();
            
            IsGameOver = board.IsGameOver();
            if(IsGameOver) timer.Stop();
            
            return;
        }
        
        currentBlock.MoveDown();
        printer.Print(board, currentBlock);
    }

    public void SetNextMoveDir(Direction direction) => nextMoveDir = direction;
}