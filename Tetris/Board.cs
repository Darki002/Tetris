namespace Tetris;

public class Board
{
    public const int Height = 10;

    public const int Width = 10;
    
    private readonly List<Tile?>[] board = new List<Tile?>[Width];

    public void AddBlock(Block block)
    {
        foreach (var tile in block.Tile)
        {
            board[tile.X].Add(tile);
        }
    }

    public bool IsBlocked(Block block)
    {
        foreach (var tile in block.Tile)
        {
            if (IsBlocked(tile))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsBlocked(Tile tile)
    {
        return board[tile.X].Any(t => t?.Y == tile.Y - 1 || tile.Y - 1 < 0);
    }

    public bool IsGameOver() => board.Any(b => b.Count > Height);
}