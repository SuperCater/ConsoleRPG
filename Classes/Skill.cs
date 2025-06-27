namespace ConsoleRPG.Classes;
using Newtonsoft.Json;

public class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxLevel { get; set; }
    public int Level { get; set; }
    
    public int Experience { get; set; } = 0;
    public Skill(string name, string description, int level = 1, int maxLevel = 100)
    {
        Name = name;
        Description = description;
        Level = level;
        MaxLevel = maxLevel;
    }
    
    public void GainExperience(int amount)
    {
        Experience += amount;
        if (Experience >= Level * 100) // Example threshold for leveling up
        {
            LevelUp();
        }
    }
    
    private int LevelUp()
    {
        if (Level >= MaxLevel) return Level; // Already at max level
        Level++;
        Experience = 0; // Reset experience after leveling up
        return Level;
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}