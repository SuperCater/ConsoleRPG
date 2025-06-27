namespace ConsoleRPG.Classes.Entities;

public class Lifeform
{
    public float Health { get; set; }
    public string Name { get; set; }
    
    public List<Item> Inventory { get; private set; }
    protected Lifeform(string name, float health)
    {
        Name = name;
        Health = health;
        Inventory = [];
    }


    public float Damage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
        return Health;
    }

    private void Die()
    {
        Health = 0;
    }

    private void HandleBreak(Item? sender, EventArgs ignore)
    {
        Inventory.Remove(sender);
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        item.OnBreak += HandleBreak;
    }
}