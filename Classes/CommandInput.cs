using ConsoleRPG.Classes.Entities;

namespace ConsoleRPG.Classes;

public class CommandInput
{
    public Player Player { get; }
    public List<string> Arguments { get; }

    public CommandInput(Player player, List<string> arguments)
    {
        Player = player;
        Arguments = arguments;
    }
}