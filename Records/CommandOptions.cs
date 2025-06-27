using ConsoleRPG.Classes;

namespace ConsoleRPG.Records;

public record CommandOptions
{
    public required string Name { get; init; }
    public required string Description { get; init; }

    public required Func<CommandInput, string> Action { get; init; }
}