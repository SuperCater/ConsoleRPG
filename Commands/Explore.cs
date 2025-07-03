using ConsoleRPG.Classes;
using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;

public class Explore() : Command(new CommandOptions
{
    Name = "explore",
    Description = "Explore the world around you",
    Action = (input) =>
    {
        return "WIP[";
    }
});