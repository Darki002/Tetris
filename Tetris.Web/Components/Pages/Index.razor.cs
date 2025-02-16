using Microsoft.AspNetCore.Components;

namespace Tetris.Web.Components.Pages;

public partial class Index(NavigationManager navigationManager)
{
    private void OnStart()
    {
        navigationManager.NavigateTo("game");
    }
}