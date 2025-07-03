using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Classes.Internal;

namespace ConsoleRPG.Classes;

public class Quest
{
    public Player Player { get; }
    public string Name { get; }
    public string Description { get; }

    public bool IsCompleted = false;
    
    public Signal<Quest> Completed = new(); // Signal that fires when the quest is completed
    
    public List<Quest> Subquests { get; } // Subquests of this quest;

    public readonly int? AmountNeeded;
    public int AmountCompleted { get; private set; }
    
    public readonly List<Item> Rewards; // Rewards for completing this quest
    
    public Quest(Player owner, string name, string description, int? amountNeeded, List<Quest>? subquests, List<Item>? rewards)
    {
        if (subquests is { Count: > 0 })
        {
            AmountNeeded = subquests.Count;
            // Need to connect into the subquests
            foreach (var subquest in subquests)
            {
                subquest.Completed.Connect(HandleSubquestCompleted); // Hook into the subquest's completion
            }
        }
        
        Player = owner;
        Name = name;
        Description = description;
        AmountNeeded = amountNeeded;
        AmountCompleted = 0;
        Subquests = subquests ?? []; 
        Rewards = rewards ?? [];
    }
    
    private Task HandleSubquestCompleted(Quest subquest)
    {
        AddProgress();
        return Task.CompletedTask;
    }
    
    public int AddProgress(int amount = 1)
    {
        if (AmountNeeded.HasValue)
        {
            AmountCompleted += amount;
            if (AmountCompleted > AmountNeeded)
            {
                AmountCompleted = AmountNeeded ?? 0; // Ensure we don't exceed the needed amount
            }

            
        }

        return AmountCompleted;


    }

    public void Complete()
    {
        if (IsCompleted)
        {
            throw new InvalidOperationException("Quest is already completed.");
        }
        IsCompleted = true;
        Completed.Fire(this);
        
    }

}