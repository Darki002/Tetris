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
            BlockType.I => ShapeI(),
            BlockType.J => ShapeJ(),
            BlockType.L => ShapeL(),
            BlockType.O => ShapeO(),
            BlockType.S => ShapeS(),
            BlockType.Z => ShapeZ(),
            BlockType.T => ShapeT(),
            _ => throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null)
        };
    }
    
    private static Block ShapeI()
    {
        const int center = Board.Width / 2;

        return new Block([
            new Tile(center - 1, Board.Height - 1),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height - 1),
            new Tile(center + 2, Board.Height - 1),
        ]);
    }

    private static Block ShapeJ()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height),
            new Tile(center - 1, Board.Height - 1),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height - 1),
        ]);
    }

    private static Block ShapeL()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height - 1),
            new Tile(center + 1, Board.Height),
        ]);
    }

    private static Block ShapeO()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center, Board.Height),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height),
            new Tile(center + 1, Board.Height - 1),
        ]);
    }

    private static Block ShapeS()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1),
            new Tile(center, Board.Height - 1),
            new Tile(center, Board.Height),
            new Tile(center + 1, Board.Height),
        ]);
    }

    private static Block ShapeZ()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height),
            new Tile(center, Board.Height),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height - 1),
        ]);
    }
    private static Block ShapeT()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1),
            new Tile(center, Board.Height - 1),
            new Tile(center + 1, Board.Height - 1),
            new Tile(center, Board.Height),
        ]);
    }
    
    private static BlockType GetRandomBlockType()
    {
        return (BlockType)Values.GetValue(Random.Next(Values.Length))!;
    }
}