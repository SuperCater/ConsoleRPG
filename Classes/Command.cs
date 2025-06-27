using ConsoleRPG.Classes.Internal;
using ConsoleRPG.Records;

namespace ConsoleRPG.Classes;

public abstract class Command(CommandOptions opts)
{
    public string Name { get; set; } = opts.Name;
    public string Description { get; set; } = opts.Description;

    public Signal<CommandInput> Ran = new();

    public string Run(CommandInput input)
    {
        var ret = Action(input);
        Ran.Fire(input);
    }

    public Func<CommandInput, string> Action { get; init; } = opts.Action;
}