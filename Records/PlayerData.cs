namespace ConsoleRPG.Records;

public record PlayerData
{
    public required string Name { get; init; }
    public int Level { get; init; }
    public int Health { get; init; }
    
    public int Stamina { get; init; }
    
    public int Experience { get; init; }
}