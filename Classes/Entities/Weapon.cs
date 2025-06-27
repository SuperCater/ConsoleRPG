namespace ConsoleRPG.Classes.Entities;

public class Weapon : Item
{
    private float Damage { get; set; }

    public Weapon(string name, float durability, float damage) : base(name, durability)
    {
        Damage = damage;
    }

    public float Attack(Lifeform target)
    {
        return target.Damage(Damage);
    }
}