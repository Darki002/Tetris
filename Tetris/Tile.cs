using Tetris.Enums;

namespace Tetris;

public class Tile(int x, int y)
{
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public int? PreviewX { get; private set; }
    public int? PreviewY { get; private set; }

    public void MoveDown() => Y--;
    
    public void PreviewMove(Direction? moveDir)
    {
        switch (moveDir)
        {
            case Direction.Down:
                PreviewY = Y - 1;
                break;
            case Direction.Left:
                PreviewX = X - 1;
                break;
            case Direction.Right:
                PreviewX = X + 1;
                break;
            case null:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(moveDir), moveDir, null);
        }
    }

    public void CommitMove()
    {
        if (PreviewX is not null)
        {
            X = PreviewX.Value;
            PreviewX = null;
        }

        if (PreviewY is not null)
        {
            Y = PreviewY.Value;
            PreviewY = null;
        }
    }
}