namespace Tetris;

public class Block(BlockType blockType)
{
    private readonly List<Tile> tiles = BlockTemplates.GetFromType(blockType);

    private List<Tile>? rotationPreview = null;
    
    public IReadOnlyList<Tile> Tiles => tiles;

    public void MoveDown() => tiles.ForEach(t => t.MoveDown());

    public List<Tile> PreviewRotation(RotationDirection rotationDirection)
    {
        rotationPreview = tiles;
        return rotationPreview;
    }

    public void CommitRotation()
    {
        // Update Tiles, not replace them in the list, so that the board doesn't lose track of them
    }
}