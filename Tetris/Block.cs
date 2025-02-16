using Tetris.Enums;

namespace Tetris;

public class Block(List<Tile> tiles)
{
    public IReadOnlyList<Tile> Tiles => tiles;

    public void TryMove(Direction? moveDir)
    {
        tiles.ForEach(t => t.PreviewMove(moveDir));
        if (tiles.Any(t => t.PreviewX is >= Board.Width or < 0) is false)
        {
            tiles.ForEach(t => t.CommitMove());
        }
    }
    
    public List<Tile> TryRotation(Direction rotationDirection)
    {
        // TODO preview rotation and then commit on tiles
        throw new NotImplementedException();
    }
}