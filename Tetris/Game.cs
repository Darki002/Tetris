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

    public Game(IPrinter printer)
    {
        this.printer = printer;
        board = new Board();
        timer = new Timer();
        timer.Interval = 750;
        timer.Elapsed += GameLoop;
    }

    public bool IsGameOver = false;

    public void Start() => timer.Start();

    private void GameLoop(object? _, ElapsedEventArgs __)
    {
        // TODO might have to change a few thing here
        // https://tetris.wiki/Tetris_Guideline#:~:text=The%20Tetris%20Guideline%20requires%20Tetris,move%20down%20immediately%20after%20appearing.
        currentBlock ??= BlockTemplates.GetRandom();

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
        printer.Print(currentBlock.AddTo(board.Tiles));
    }

    public void SetNextMoveDir(BlockAction blockAction)
    {
        if(currentBlock is null) return;
        currentBlock.TryMove(blockAction, board.Tiles);
        printer.Print(currentBlock.AddTo(board.Tiles));
    }
}