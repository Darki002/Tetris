using Tetris.Enums;

namespace Tetris;

public class Block(List<Tile> tiles)
{
    public IReadOnlyList<Tile> Tiles => tiles;

    public BlockType?[,] AddTo(BlockType?[,] board)
    {
        foreach (var tile in tiles)
        {
            board[tile.X, tile.Y] = tile.BlockType;
        }
        
        return board;
    }

    // https://tetris.fandom.com/wiki/Sega_Rotation
    // https://tetris.fandom.com/wiki/SRS
    
    public void TryMove(BlockAction? moveDir, BlockType?[,] boardTiles)
    {
        tiles.ForEach(t => t.PreviewMove(moveDir));
        
        if (tiles.All(t => t.PreviewX is < Board.Width and >= 0 && boardTiles[t.PreviewX, t.PreviewY] is null))
        {
            tiles.ForEach(t => t.CommitMove());
        }
    }

    public void MoveDown() => tiles.ForEach(t => t.MoveDown());

    public List<Tile> TryRotation(BlockAction rotationBlockAction)
    {
        // TODO preview rotation and then commit on tiles
        throw new NotImplementedException();
    }
}