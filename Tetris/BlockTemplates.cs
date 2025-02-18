using Tetris.Enums;

namespace Tetris;

public static class BlockTemplates 
{
    private static readonly Array Values = Enum.GetValues(typeof(BlockType));

    private static readonly Random Random = new();
    
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
            new Tile(center - 1, Board.Height - 1, BlockType.I),
            new Tile(center, Board.Height - 1, BlockType.I),
            new Tile(center + 1, Board.Height - 1, BlockType.I),
            new Tile(center + 2, Board.Height - 1, BlockType.I),
        ]);
    }

    private static Block ShapeJ()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height, BlockType.J),
            new Tile(center - 1, Board.Height - 1, BlockType.J),
            new Tile(center, Board.Height - 1, BlockType.J),
            new Tile(center + 1, Board.Height - 1, BlockType.J),
        ]);
    }

    private static Block ShapeL()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1, BlockType.L),
            new Tile(center, Board.Height - 1, BlockType.L),
            new Tile(center + 1, Board.Height - 1, BlockType.L),
            new Tile(center + 1, Board.Height, BlockType.L),
        ]);
    }

    private static Block ShapeO()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center, Board.Height, BlockType.O),
            new Tile(center, Board.Height - 1, BlockType.O),
            new Tile(center + 1, Board.Height, BlockType.O),
            new Tile(center + 1, Board.Height - 1, BlockType.O),
        ]);
    }

    private static Block ShapeS()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1, BlockType.S),
            new Tile(center, Board.Height - 1, BlockType.S),
            new Tile(center, Board.Height, BlockType.S),
            new Tile(center + 1, Board.Height, BlockType.S),
        ]);
    }

    private static Block ShapeZ()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height, BlockType.Z),
            new Tile(center, Board.Height, BlockType.Z),
            new Tile(center, Board.Height - 1, BlockType.Z),
            new Tile(center + 1, Board.Height - 1, BlockType.Z),
        ]);
    }
    private static Block ShapeT()
    {
        const int center = Board.Width / 2;
        
        return new Block([
            new Tile(center - 1, Board.Height - 1, BlockType.T),
            new Tile(center, Board.Height - 1, BlockType.T),
            new Tile(center + 1, Board.Height - 1, BlockType.T),
            new Tile(center, Board.Height, BlockType.T),
        ]);
    }
    
    private static BlockType GetRandomBlockType()
    {
        return (BlockType)Values.GetValue(Random.Next(Values.Length))!;
    }
}