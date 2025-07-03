using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Records;

namespace ConsoleRPG.Services;

public static class PromptService
{
    public static Player PromptCreatePlayer()
    {
        while (true)
        {
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please try again."); 
                continue;
            }

            var player = new Player(new PlayerData { Name = name, Level = 1, Health = 100, });
            
            player.SaveData();
            Console.WriteLine("Player created with name: " + player.Name);
            return player;
        }
    }

    public static Player PromptLoadPlayer(List<Player> players)
    {
        while (true)
        {
            Console.Write("Select a player by number: ");
            if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 0 || choice > players.Count)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            if (choice == 0)
            {
                return PromptCreatePlayer();
            }

            var selectedPlayer = players[choice - 1];
            return selectedPlayer;
        }
    }

    public static bool PromptYesOrNo(string message)
    {
        while (true)
        {
            Console.Write($"{message} (y/n): ");
            var input = Console.ReadLine()?.Trim().ToLower();
            switch (input)
            {
                case "y" or "yes":
                    return true;
                case "n" or "no":
                    return false;
                default:
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    break;
            }
        }
    }
}