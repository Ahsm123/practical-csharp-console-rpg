using ConsoleRolePlayingGame.App.Screens;
using ConsoleRolePlayingGame.GameManagement;
using ConsoleRolePlayingGame.Overworld;
using ConsoleRolePlayingGame.Overworld.Generators;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

IAnsiConsole console = AnsiConsole.Console;
try
{
    ServiceCollection services = new();
    
    services.AddSingleton<GameManager>();
    services.AddSingleton<IAnsiConsole>(console);
    services.AddSingleton<PerlinNoiseProvider>();
    services.AddSingleton<MapGenerator>();
    services.AddSingleton<WorldMap>();
    services.AddSingleton<OpenPosSelector>();
    services.AddSingleton<PlayerParty>();
    services.AddTransient<ScreenManager>();
    services.AddTransient<OverworldScreen>();

    ServiceProvider provider = services.BuildServiceProvider();

    GameManager game = provider.GetRequiredService<GameManager>();
    ScreenManager screens = provider.GetRequiredService<ScreenManager>();
    
    while (game.Status != GameStatus.Terminated) {
        screens.Run();
        game.Update();
    }
} catch (Exception ex) {
    console.WriteException(ex, ExceptionFormats.ShortenEverything);
    console.Input.ReadKey(intercept: false);
}