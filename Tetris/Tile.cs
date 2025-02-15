namespace Tetris;

public class Tile(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; private set; } = y;

    public void MoveDown() => Y--;
}