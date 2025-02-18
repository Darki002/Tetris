using Tetris.Enums;

namespace Tetris;

public class Tile(int x, int y, BlockType blockType)
{
    public BlockType BlockType { get; } = blockType;
    
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    internal int PreviewX { get; private set; } = x;
    internal int PreviewY { get; private set; } = y;
    
    public void MoveDown() => Y--;
    
    public void PreviewMove(Direction? moveDir)
    {
        PreviewX = X;
        PreviewY = Y;
        
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
        X = PreviewX;
        Y = PreviewY;
    }

    public override string ToString()
    {
        return $"X: {X} Y: {Y}";
    }
}