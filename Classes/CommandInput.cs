using ConsoleRPG.Classes.Entities;

namespace ConsoleRPG.Classes;

public class CommandInput(Player player, List<string> arguments, Command command)
{
    public Player Player { get; } = player;
    public List<string> Arguments { get; } = arguments;
    public Command Command { get; } = command;
}