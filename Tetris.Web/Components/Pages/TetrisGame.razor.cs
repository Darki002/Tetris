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

    public void Print(IReadOnlyList<Tile> updatedTiles)
    {
        InvokeAsync(() =>
        {
            tiles = [..updatedTiles];
            StateHasChanged();
        });
    }
}