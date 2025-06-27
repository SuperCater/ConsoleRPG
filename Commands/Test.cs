using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;
using ConsoleRPG.Classes;

public class Test() : Command(new CommandOptions
{
    Name = "test",
    Description = "Test command",
    Action = (input) =>
    {
        Console.WriteLine(string.Join(", ", input.Arguments));
        return "Test command executed successfully.";
    }
});