using Tetris.Enums;

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
            BlockType.TestWidth => TestWidth(),
            BlockType.TestHeight => TestHeight(),
            BlockType.FullWidth => FullWidth(),
            _ => throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null)
        };
    }

    private static Block FullWidth()
    {
        var tiles = new List<Tile>();

        for (var i = 0; i < Board.Width; i++)
        {
            tiles.Add(new Tile(i, Board.Height));
        }

        return new Block(tiles);
    }

    private static Block TestHeight() => new Block([
        new Tile(Board.Width / 2, Board.Height + 1),
        new Tile(Board.Width / 2, Board.Height + 2)
    ]);

    private static Block TestWidth() => new Block([
        new Tile(Board.Width / 2, Board.Height + 1),
        new Tile(Board.Width / 2 + 1, Board.Height + 1)
    ]);

    private static Block Test()
    {
        return new Block([new Tile(Board.Width / 2, Board.Height + 1)]);
    }

    private static BlockType GetRandomBlockType()
    {
        return (BlockType)Values.GetValue(Random.Next(Values.Length))!;
    }
}