using ConsoleRPG.Classes;
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
}