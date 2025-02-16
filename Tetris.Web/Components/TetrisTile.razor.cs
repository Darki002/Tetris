using Microsoft.AspNetCore.Components;

namespace Tetris.Web.Components;

public partial class TetrisTile
{
    [Parameter] 
    [EditorRequired] 
    public required Tile? Tile { get; set; }

    private string cssClass = null!;

    protected override void OnInitialized()
    {
        var tileClass = Tile is null ? "empty" : "block";
        cssClass = $"tile {tileClass}";
    }
}