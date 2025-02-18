using Tetris.Enums;

namespace Tetris;

public interface IPrinter
{
    void Print(BlockType?[,] updatedTiles);
}