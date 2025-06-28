using ConsoleRPG.Classes.Internal;

namespace ConsoleRPG.Classes;



public class Item
{
    private string Name { get; set; }
    public float Durability { get; set; }

    public Signal<Item> OnBreak = new();
    
    public Item(string name, float durability)
    {
        Name = name;
        Durability = durability;
    }

    public float ReduceDurability(float amount)
    {
        Durability-= amount;
        if (Durability <= 0)
        {
            Break();
        }
        return Durability;
    }

    public void Break()
    {
        Durability = 0;
        OnBreak.Fire(this);
    }
    
}