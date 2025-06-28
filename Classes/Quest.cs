using ConsoleRPG.Classes.Entities;

namespace ConsoleRPG.Classes;

public class Quest
{
    public Player Player { get; }
    public string Name { get; }
    public string Description { get; }
    
    public List<Quest> Subquests { get; } // Subquests of this quest;

    public readonly int? AmountNeeded;
    public int? AmountCompleted { get; private set; }
    
    public readonly List<Item> Rewards; // Rewards for completing this quest
    
    public Quest(Player owner, string name, string description, int? amountNeeded, List<Quest>? subquests, List<Item>? rewards)
    {
        if (subquests is { Count: > 0 })
        {
            
        }
        
        Player = owner;
        Name = name;
        Description = description;
        AmountNeeded = amountNeeded;
        AmountCompleted = 0;
        Subquests = subquests ?? []; 
        Rewards = rewards ?? [];
    }
    
    public int AddProgress(int amount = 1)
    {
        if (AmountNeeded.HasValue)
        {
            AmountCompleted += amount;
            if (AmountCompleted > AmountNeeded)
            {
                AmountCompleted = AmountNeeded;
            }
        }
    }

    public List<Item> Complete()
    {
        if 
    }

}