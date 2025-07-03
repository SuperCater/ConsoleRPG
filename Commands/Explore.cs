using ConsoleRPG.Classes;
using ConsoleRPG.Managers;
using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;

public class Explore() : Command(new CommandOptions
{
    Name = "explore",
    Description = "Explore the world around you",
    Action = (input) =>
    {
        var enemy = EnemyManager.GetRandomEnemy();
        return $"You encountered a {enemy.Name}! Prepare for battle!";
    }
});