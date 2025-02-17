using Tetris.Enums;

namespace Tetris;

public class Block(List<Tile> tiles)
{
    public IReadOnlyList<Tile> Tiles => tiles;

    public void TryMove(Direction? moveDir, IReadOnlyList<Tile> boardTiles)
    {
        tiles.ForEach(t => t.PreviewMove(moveDir));
        
        if (tiles.All(t => t.PreviewX is < Board.Width and >= 0 && !IsOnAnyTile(t)))
        {
            tiles.ForEach(t => t.CommitMove());
        }
        return;
        
        bool IsOnAnyTile(Tile tile)
        {
            return boardTiles.Any(t => tile.PreviewX == t.X && tile.PreviewY == t.Y);
        }
    }

    public void MoveDown()
    {
        tiles.ForEach(t => t.PreviewMove(Direction.Down));
        tiles.ForEach(t => t.CommitMove());
    }
    
    public List<Tile> TryRotation(Direction rotationDirection)
    {
        // TODO preview rotation and then commit on tiles
        throw new NotImplementedException();
    }
}