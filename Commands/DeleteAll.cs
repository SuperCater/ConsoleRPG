using System.Diagnostics;
using ConsoleRPG.Classes;
using ConsoleRPG.Classes.Entities;
using ConsoleRPG.Records;

namespace ConsoleRPG.Commands;

public class DeleteAll() : Command(new CommandOptions
{
    Name = "deleteall",
    Description = "Delete all player data",
    Action = (input) =>
    {
       Player.DeleteAllPlayers();
       // Exit the process
       Process.GetCurrentProcess().Kill();
       return "All player data has been deleted.";
    }
});