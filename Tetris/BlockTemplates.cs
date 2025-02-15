namespace Tetris;

public static class BlockTemplates 
{
    private static readonly Array Values = Enum.GetValues(typeof(BlockType));

    private static readonly Random Random = new Random();
    
    public static Block GetRandom()
    {
        var blockType = GetRandomBlockType();
        return blockType switch
        {
            BlockType.Test => Test(),
            _ => throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null)
        };
    }

    private static Block Test()
    {
        return new Block([new Tile(Board.Width / 2, Board.Height + 1)]);
    }

    private static BlockType GetRandomBlockType()
    {
        return (BlockType)Values.GetValue(Random.Next(Values.Length))!;
    }
}