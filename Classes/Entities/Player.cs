using ConsoleRPG.Records;
using ConsoleRPG.Services;
using Newtonsoft.Json;
namespace ConsoleRPG.Classes.Entities;

public class Player : Lifeform
{

    public int Stamina { get; set; }
    public int Level { get; private set; } = 0;
    
    public int Experience { get; set; } = 0;

    private static Player? ActivePlayer { get; set; }
    
    public List<Skill> Skills { get; set; }
    
    
    public Player(PlayerData data): base(data.Name, data.Health, [])
    {
        Name = data.Name;
        Level = data.Level;
        Health = data.Health;
        Stamina = data.Stamina;
        Experience = data.Experience;
        
        // Initialize default skills
        Skills =
        [
            new Skill("Stamina", "Increased stamina level will increase your maximum stamina and stamina regeneration."),
            new Skill("Health", "Increased health level will increase your maximum health and health regeneration."),
            new Skill("Strength", "Increased strength will allow for you to do many tasks faster and output more damage."),
        ];
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


        var json = ToJson();
        
        File.WriteAllText(filePath, json);
    }

    public int AddXp(int amount)
    {
        Experience += amount;
        return CanLevelUp() ? LevelUp() : Level;
    }

    public bool CanLevelUp()
    {
        return Experience >= 1000; // Levels only take 1000 experience to level up
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

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
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
    
    public static Player LoadPlayer(string name)
    {
        var folder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConsoleRPG");
        var filePath = Path.Join(folder, $"{name}.json");
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Player data for {name} not found.");
        }
        
        var json = File.ReadAllText(filePath);
        Console.WriteLine(json);
        var player = JsonConvert.DeserializeObject(json);
        Console.WriteLine(player);

        if (player is null)
        {
            throw new NullReferenceException($"Player data for {name} not found/corrupted.");
        }

        return new Player(new PlayerData {Name = "Unknown"});
    }
    
    public static List<Player> GetAllPlayers()
    {
        var players = new List<Player>();
        var playerNames = GetPlayerNames();
        
        foreach (var playerName in playerNames)
        {
            Console.WriteLine(playerName);
            try
            {
                var player = LoadPlayer(Path.GetFileNameWithoutExtension(playerName));
                players.Add(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading player {playerName}: {ex.Message}");
            }
        }
        
        return players;
    }

    public static void DeleteAllPlayers()
    { 
        var delete = PromptService.PromptYesOrNo("Are you sure you want to delete all players? This action cannot be undone.");
        if (!delete)
        {
            Console.WriteLine("Deletion cancelled.");
            return;
        }
        var folder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ConsoleRPG");
        if (!Directory.Exists(folder))
        {
            Console.WriteLine("No players found to delete.");
            return;
        }
        var files = Directory.GetFiles(folder, "*.json");
        foreach (var file in files)
        {
            try
            {
                File.Delete(file);
                Console.WriteLine($"Deleted player data: {file}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting player data {file}: {ex.Message}");
            }
        }
    }
    
    
}