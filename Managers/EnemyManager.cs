using ConsoleRPG.Classes.Entities;

namespace ConsoleRPG.Managers;

public class EnemyManager
{
    public static List<Enemy> Enemies = [];
    
    
    public static void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
    
    public static void RemoveEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
    }
    
    public static Enemy? GetEnemy(string name)
    {
        return Enemies.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    
    public static Enemy GetRandomEnemy()
    {
        if (Enemies.Count == 0)
            throw new InvalidOperationException("No enemies available.");
        
        Random random = new();
        var index = random.Next(Enemies.Count);
        return Enemies[index];
    }
    
    
}