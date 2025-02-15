namespace Tetris;

public class Block(BlockType blockType)
{
    private readonly List<Tile> tile = BlockTemplates.GetFromType(blockType);

    private List<Tile>? rotationPreview = null;
    
    public IReadOnlyList<Tile> Tile => tile;

    public void MoveDown() => tile.ForEach(t => t.MoveDown());

    public List<Tile> PreviewRotation(RotationDirection rotationDirection)
    {
        rotationPreview = tile;
        return rotationPreview;
    }

    public void CommitRotation()
    {
        // Update Tiles, not replace them in the list, so that the board doesn't lose track of them
    }
}