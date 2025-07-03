using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Commands;
using ConsoleRPG.Managers;
using ConsoleRPG.Records;
using ConsoleRPG.Services;
using Newtonsoft.Json;

var players = Player.GetPlayerNames();
if (players.Count == 0)
{
    Console.WriteLine("No players found. Creating a new player...");
    var player = PromptService.PromptCreatePlayer();
    Player.SetActivePlayer(player);
    
}
else
{
    UiService.RenderPlayerChoice();

}

var active = Player.GetActivePlayer();
if (active == null)
{
    Console.WriteLine("No active player found. Exiting...");
    return;
}

CommandManager.Player = active;



CommandManager.Add(new Test()); // Test command
CommandManager.Add(new Stats()); // Stats command
CommandManager.Add(new Help()); // Help command
CommandManager.Add(new DeleteAll());


while (true)
{
    Console.Write($"{active.Name} > ");
    var input = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }
    
    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    
    try
    {
        CommandManager.ProcessInput(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
