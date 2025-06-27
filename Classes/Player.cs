using ConsoleRPG.Records;
using Newtonsoft.Json;
namespace ConsoleRPG.Classes;

public class Player
{
    public string Name { get; set; }

    public int Stamina { get; set; }
    public int Health { get; set; } = 0;
    public int Level { get; private set; } = 0;
    
    public int Experience { get; set; } = 0;

    private static Player? ActivePlayer { get; set; }
    
    public Skill StaminaSkill { get; set; } = new Skill("Stamina", "Increases stamina regeneration and max stamina rate.");
    
    
    public Player(PlayerData data)
    {
        Name = data.Name;
        Level = data.Level;
        Health = data.Health;
        Stamina = data.Stamina;
        Experience = data.Experience;
    }
    

    public void SaveData()
    {
        var folder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConsoleRPG");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        var filePath = Path.Join(folder, $"{Name}.json");
        // Write the player data to the file


        var json = JsonConvert.SerializeObject(this, Formatting.Indented);
        
        File.WriteAllText(filePath, json);
    }

    public int AddXp(int amount)
    {
        Experience += amount;
        return CanLevelUp() ? LevelUp() : Level;
    }

    public bool CanLevelUp()
    {
        return this.Experience >= 1000; // Levels only take 1000 experience to level up
    }

    private int LevelUp()
    {
        while (CanLevelUp())
        {
            Level++;
            Experience -= 1000; // Deduct the experience needed for leveling up
        }
        
        return Level;
    }
    
    public int DecreaseStamina(int amount)
    {
        if (Stamina - amount < 0)
        {
            throw new InvalidOperationException("Not enough stamina.");
        }
        
        Stamina -= amount;
        return Stamina;
    }
    
    public int IncreaseStamina(int amount)
    {
        Stamina += amount;
        return Stamina;
    }
    
    
    public static List<string> GetPlayerNames()
    {
        var folder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConsoleRPG");
        var ret = new List<string>();
        if (!Directory.Exists(folder))
        {
            return ret;
        }
        
        var files = Directory.GetFiles(folder, "*.json");
        ret.AddRange(files);
        return ret;
    }

    public static void SetActivePlayer(Player player)
    {
        ActivePlayer = player;
        Console.WriteLine($"Player {player.Name} set as active.");
    }
    
    public static Player? GetActivePlayer()
    {
        return ActivePlayer;
    }
    
    
}