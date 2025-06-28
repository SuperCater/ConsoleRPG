namespace ConsoleRPG.Classes.Entities;

public class Weapon(string name, float durability, float damage) : Item(name, durability)
{
    public float Damage { get; private set; } = damage;

    public float Attack(Lifeform target)
    {
        return target.Damage(Damage);
    }
    
    public override string ToString()
    {
        return $"{Name} (Durability: {Durability}, Damage: {Damage})";
    }
}