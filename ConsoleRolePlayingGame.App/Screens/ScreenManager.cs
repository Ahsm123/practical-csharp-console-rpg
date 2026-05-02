using ConsoleRolePlayingGame.GameManagement;
using Spectre.Console;

namespace ConsoleRolePlayingGame.App.Screens;

public class ScreenManager(GameManager game, IAnsiConsole console, OverworldScreen screen)
{
    public void Run()
    {
        console.Clear();
        
        switch(game.Status)

        {
            case GameStatus.Overworld:
                console.Write(screen.GenerateVisual());
                screen.HandlePlayerInput();
                break;
            case GameStatus.GameOver:
                console.MarkupLine("[red]Game Over[/]");
                console.MarkupLine("[yellow]Press any key to exit...[/]");
                console.Input.ReadKey(intercept: true);
                game.Quit();
                break;
        }
    }
    
    
}