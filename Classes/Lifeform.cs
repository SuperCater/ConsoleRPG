namespace ConsoleRPG.Classes;

public abstract class Lifeform(string name, int health)
{
    public string Name { get; protected init; } = name;
    public int Health { get; protected init; } = health;
}