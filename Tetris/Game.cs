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
        // TODO might have to change a few thing here
        // https://tetris.wiki/Tetris_Guideline#:~:text=The%20Tetris%20Guideline%20requires%20Tetris,move%20down%20immediately%20after%20appearing.
        currentBlock ??= BlockTemplates.GetRandom();

        if (nextMoveDir is not null)
        {
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
            
            printer.Print(board.Tiles);
            return;
        }
        
        currentBlock.MoveDown();
        printer.Print([..board.Tiles, ..currentBlock.Tiles]);
    }

    public void SetNextMoveDir(Direction direction) => nextMoveDir = direction;
}