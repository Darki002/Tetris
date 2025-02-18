using Microsoft.AspNetCore.Components;

namespace Tetris.Web.Components;

public partial class TetrisTile
{
    [Parameter]
    public bool HasBlock { get; set; }

    private string cssClass = null!;

    protected override void OnParametersSet()
    {
        var tileClass = HasBlock ? "block" : "empty";
        cssClass = $"tile {tileClass}";
    }
}