using ConsoleRPG.Records;

namespace ConsoleRPG.Classes;

public abstract class Command(CommandOptions opts)
{
    public string Name { get; set; } = opts.Name;
    public string Description { get; set; } = opts.Description;

    public Func<CommandInput, string> Action { get; init; } = opts.Action;
}