namespace Tetris;

public class Board
{
    public const int Height = 10;

    public const int Width = 10;
    
    private readonly List<Tile?>[] board;

    public Board()
    {
        board = new List<Tile?>[Width];
        for (var i = 0; i < board.Length; i++)
        {
            board[i] = [];
        }
    }

    public List<Tile> Tiles => board
        .SelectMany(b => b)
        .Where(t => t != null)
        .ToList()!;

    public void AddBlock(Block block)
    {
        foreach (var tile in block.Tiles)
        {
            board[tile.X].Add(tile);
        }
    }

    public bool IsBlocked(Block block)
    {
        foreach (var tile in block.Tiles)
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
        return tile.Y - 1 < 0 || board[tile.X].Any(t => t?.Y == tile.Y - 1);
    }

    public bool IsGameOver() => board.Any(b => b.Count > Height);
}