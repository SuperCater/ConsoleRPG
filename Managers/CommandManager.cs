using System.ComponentModel;
using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Classes.Internal;

namespace ConsoleRPG.Managers;

public static class CommandManager
{
    public static Player? Player { get; set; }
    public static List<Command> Stored { get; } = [];
    
    public static Signal<Command> CommandRan { get; } = new();

    public static Command? Get(string commandName)
    {

        return Stored.First(command => command.Name == commandName);
    }

    public static void Add(Command command)
    {
        Stored.Add(command);
    }


    public static void ProcessInput(string input)
    {
        if (Player == null)
        {
            throw new InvalidOperationException("Player is not set");
        }
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