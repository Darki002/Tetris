using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tetris.Enums;

namespace Tetris.Web.Components.Pages;

public partial class TetrisGame : IPrinter
{
    private Game game = null!;

    private bool[,] tiles = new bool[Board.Width,Board.Height];
    
    private ElementReference container;

    protected override void OnInitialized()
    {
        game = new Game(this);
        game.Start();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender) await container.FocusAsync();
    }

    private void OnKeyPress(KeyboardEventArgs obj)
    {
        switch (obj.Key)
        {
            case "ArrowRight":
                game.SetNextMoveDir(Direction.Right);
                break;
            case "ArrowLeft":
                game.SetNextMoveDir(Direction.Left);
                break;
        }
    }

    public void Print(bool[,] updatedTiles)
    {
        InvokeAsync(() =>
        {
            tiles = updatedTiles;
            StateHasChanged();
        });
    }
}