using System.ComponentModel;
using ConsoleRPG.Classes;

namespace ConsoleRPG.Managers;

public class CommandManager(Player player)
{
    private Player Player { get; init; } = player;
    private List<Command> Stored { get; } = [];

    public Command? Get(string commandName)
    {

        return Stored.First(command => command.Name == commandName);
    }

    public void Add(Command command)
    {
        Stored.Add(command);
    }


    public void ProcessInput(string input)
    {
        var arguments = input.Split(' ').ToList();
        var commandName = arguments[0];
        arguments.RemoveAt(0);

        var commandInput = new CommandInput(Player, arguments);
        var command = Get(commandName);

        if (command == null)
        {
            Console.WriteLine($"Command '{commandName}' not found.");
            return;
        }

        try
        {
            var result = command.Action(commandInput);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command '{commandName}': {ex.Message}");
        }
    }

}