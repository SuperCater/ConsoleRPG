using System.Text;
using ConsoleRPG.Classes;
using ConsoleRPG.Managers;
using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;

public class Help() : Command(new CommandOptions
{
    Name = "help",
    Description = "Display available commands and their descriptions",
    Action = (input) =>
    {
        
        if (input.Arguments.Count == 1)
        {
            var commandToSearch = input.Arguments.First();
            var command = CommandManager.Get(commandToSearch);
            return command != null ? $"{command.Name}: {command.Description}" : $"Command '{commandToSearch}' not found.";
        }

        var message = new StringBuilder();
        message.AppendLine("Available commands:");
        foreach (var command in CommandManager.Stored)
        {
            message.AppendLine($"{command.Name}: {command.Description}");
        }


        return message.ToString();
    }
});
