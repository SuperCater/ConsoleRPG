using System.Text;
using ConsoleRPG.Classes;
using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;

public class Stats() : Command(new CommandOptions
{
    Name = "stats",
    Description = "Display player stats",
    Action = (input) =>
    {
        var player = input.Player;
        var stats = new StringBuilder();
        stats.AppendLine($"Name: {player.Name}");
        stats.AppendLine($"Level: {player.Level}");
        stats.AppendLine($"Experience: {player.Experience}/1000");
        stats.AppendLine($"Health: {player.Health}");
        stats.AppendLine($"Stamina: {player.Stamina}");
        
        return stats.ToString();
    }
});
