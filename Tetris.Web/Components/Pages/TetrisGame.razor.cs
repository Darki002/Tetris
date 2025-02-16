namespace Tetris.Web.Components.Pages;

public partial class TetrisGame : IPrinter
{
    private Game game = null!;

    private List<Tile> tiles = [];

    protected override void OnInitialized()
    {
        game = new Game(this);
        game.Start();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        
    }

    public void Print(Board board, Block currentBlock)
    {
        tiles = [..board.Tiles, ..currentBlock.Tiles];
        StateHasChanged();
    }
}