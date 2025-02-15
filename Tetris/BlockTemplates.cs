namespace Tetris;

public static class BlockTemplates 
{
    public static List<Tile> GetFromType(BlockType blockType)
    {
        return blockType switch
        {
            BlockType.Test => Test(),
            _ => throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null)
        };
    }

    private static List<Tile> Test()
    {
        return [new Tile(Board.Width / 2, Board.Height + 1)];
    }
}