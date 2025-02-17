using Microsoft.AspNetCore.Components;

namespace Tetris.Web.Components;

public partial class TetrisTile
{
    [Parameter]
    public Tile? Tile { get; set; }

    private string cssClass = null!;

    protected override void OnParametersSet()
    {
        if(Tile is not null) Console.WriteLine(Tile);
        
        var tileClass = Tile is null ? "empty" : "block";
        cssClass = $"tile {tileClass}";
    }
}