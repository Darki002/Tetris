using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Tetris.Enums;

namespace Tetris.Web.Components.Pages;

public partial class TetrisGame : IPrinter
{
    private Game game = null!;

    private BlockType?[,] tiles = new BlockType?[Board.Width,Board.Height];
    
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
                game.SetNextMoveDir(BlockAction.Right);
                break;
            case "ArrowLeft":
                game.SetNextMoveDir(BlockAction.Left);
                break;
        }
    }

    public void Print(BlockType?[,] updatedTiles)
    {
        InvokeAsync(() =>
        {
            tiles = updatedTiles;
            StateHasChanged();
        });
    }
}