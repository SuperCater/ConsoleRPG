namespace ConsoleRPG.Records;

// TODO: Remove this and just have it destructure from json.
public record PlayerData
{
    public required string Name { get; init; }
    public int Level { get; init; } = 1;
    public int Health { get; init; } = 100;

    public int Stamina { get; init; } = 100;

    public int Experience { get; init; } = 0;
}