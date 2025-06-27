using ConsoleRPG.Classes;
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
    Console.WriteLine("Available players:");
    for (var i = 0; i < players.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(players[i])}");
    }
    
    Console.WriteLine("0. Create a new player");
    
    Console.WriteLine("Select a player by number:");
    if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 0 || choice > players.Count)
    {
        Console.WriteLine("Invalid choice. Exiting...");
        return;
    }

    if (choice == 0)
    {
        var player = PromptService.PromptCreatePlayer();
        Player.SetActivePlayer(player);
        return;
    }
    
    var selectedPlayer = players[choice - 1];
    
    var playerDataJson = File.ReadAllText(selectedPlayer);
    var playerData = JsonConvert.DeserializeObject<PlayerData>(playerDataJson);
    
    if (playerData == null)
    {
        Console.WriteLine("Failed to load player data. Exiting...");
        return;
    }
    

    Player.SetActivePlayer(new Player(playerData));
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
