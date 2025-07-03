using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;
using ConsoleRPG.Classes;

public class Clear() : Command(new CommandOptions
{
    Name = "clear",
    Description = "Clear the console screen",
    Action = (input) =>
    {
        Console.Clear();
        return "Console cleared.";
    }
});