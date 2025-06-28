using ConsoleRPG.Managers;

namespace ConsoleRPG.Classes.Entities;

public class Enemy(string name, int health, List<Item> inventory) : Lifeform(name, health, inventory);