namespace Tetris;

public interface IPrinter
{
    void Print(IReadOnlyList<Tile> updatedTiles);
}