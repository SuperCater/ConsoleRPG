namespace ConsoleRPG.Classes.Entities;

public class Lifeform
{
    public float Health { get; set; }
    public string Name { get; set; }
    
    private List<Item> Inventory { get; set; }
    protected Lifeform(string name, float health, List<Item>? inventory)
    {
        Name = name;
        Health = health;
        Inventory = inventory ?? [];
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

    private Task HandleBreak(Item sender)
    {
        Inventory.Remove(sender);
        return Task.CompletedTask;
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        item.OnBreak.Connect(HandleBreak);
    }

    public Item? GetBestWeapon()
    {
        return Inventory
            .Where(item => item is Weapon)
            .Cast<Weapon>()
            .OrderByDescending(weapon => weapon.Damage)
            .FirstOrDefault();
    }
    
    public Lifeform Clone()
    {
        return new Lifeform(Name, Health, [..Inventory]);
    }
}