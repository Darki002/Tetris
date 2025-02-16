namespace Tetris.Web.Components.Pages;

public partial class TetrisGame : IPrinter
{
    private Game game = null!;

    private List<Tile> tiles = [];
    
    private int fuckThisShit = 0;

    protected override void OnInitialized()
    {
        game = new Game(this);
        game.Start();
    }

    public void Print(IReadOnlyList<Tile> updatedTiles)
    {
        InvokeAsync(() =>
        {
            tiles = [];
            fuckThisShit++;
            StateHasChanged();
            
            tiles = [..updatedTiles];
            Console.WriteLine(tiles.Count);

            StateHasChanged();
        });
        StateHasChanged();
    }
}