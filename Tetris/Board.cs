namespace Tetris;

public class Board
{
    public const int Height = 10;

    public const int Width = 10;
    
    private readonly List<Tile>[] board;

    public Board()
    {
        board = new List<Tile>[Width];
        for (var i = 0; i < board.Length; i++)
        {
            board[i] = [];
        }
    }

    public IReadOnlyList<Tile> Tiles => board
        .SelectMany(b => b)
        .ToList();

    public void AddBlock(Block block)
    {
        foreach (var tile in block.Tiles)
        {
            board[tile.X].Add(tile);
        }
    }

    public bool IsBlocked(Block block) => block.Tiles.Any(IsBlocked);

    private bool IsBlocked(Tile tile)
    {
        return tile.Y - 1 < 0 || board[tile.X].Any(t => t.Y == tile.Y - 1);
    }
    
    public void TryRemoveRows()
    {
        for (var i = 0; i <= Height; i++)
        {
            var row = GetRow(i);
            if(row.Count == 0) return;
            if (row.Count >= Width) RemoveRow(row, i);
        }
    }

    private void RemoveRow(List<Tile> row, int rowIndex)
    {
        Console.WriteLine($"Remove Row {rowIndex}");
        row.ForEach(t => board[t.X].Remove(t));
        
        var tilesToMove = board
            .SelectMany(b => b)
            .Where(t => t.Y > rowIndex);
        foreach (var tile in tilesToMove) tile.MoveDown();
    }

    private List<Tile> GetRow(int row)
    {
        return board
            .SelectMany(col => col)
            .Where(t => t.Y == row)
            .ToList();
    }

    public bool IsGameOver() => board.Any(b => b.Count > Height);
}