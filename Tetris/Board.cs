using Tetris.Enums;

namespace Tetris;

public class Board
{
    public const int Height = 22;

    public const int Width = 10;
    
    private BlockType?[,] board = new BlockType?[Width, Height];

    public BlockType?[,] Tiles => (BlockType?[,])board.Clone();

    public void AddBlock(Block block)
    {
        foreach (var tile in block.Tiles)
        {
            board[tile.X, tile.Y] = tile.BlockType;
        }
    }

    public bool IsBlocked(Block block) => block.Tiles.Any(IsBlocked);

    private bool IsBlocked(Tile tile)
    {
        return tile.Y - 1 < 0 || board[tile.X, tile.Y - 1] is not null;
    }
    
    public void TryRemoveRows()
    {
        for (var i = 0; i <= Height; i++)
        {
            var row = GetRow(i);
            if(row.Length == 0) return;
            if (row.Count(r => r is not null) >= Width) RemoveRow(i);
        }
    }

    private void RemoveRow(int rowIndex)
    {
        var old = board;
        board = new BlockType?[Width, Height];

        for (var x = 0; x < Width; x++)
        {
            for (var y = rowIndex; y < Height - 1; y++)
            {
                board[x, y] = old[x, y + 1];
            }
        }
    }

    private BlockType?[] GetRow(int row)
    {
        return Enumerable.Range(0, board.GetLength(1))
            .Select(x => board[row, x])
            .ToArray();
    }

    public bool IsGameOver() => GetRow(Height - 1).Any(b => b is not null);
}