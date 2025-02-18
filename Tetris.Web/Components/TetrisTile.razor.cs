using Microsoft.AspNetCore.Components;
using Tetris.Enums;

namespace Tetris.Web.Components;

public partial class TetrisTile
{
    [Parameter]
    public BlockType? BlockType { get; set; }

    private string cssClass = null!;

    protected override void OnParametersSet()
    {
        var tileClass = BlockType is null ? "empty" : BlockType.Value.ToString();
        cssClass = $"tile {tileClass}";
    }
}