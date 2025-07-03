using ConsoleRPG.Classes.Entities;

namespace ConsoleRPG.Services;
using Spectre.Console;

public static class UiService
{
    public static void RenderPlayerChoice()
    {
        var table = new Table();
        table.AddColumn("Index");
        table.AddColumn("Name");
        table.AddColumn("Level");
        
        var players = Player.GetAllPlayers();
        Console.WriteLine(players.Count);
        for (var i = 0; i < players.Count; i++)
        {
            var player = Player.GetAllPlayers()[i];
            table.AddRow(i.ToString(), player.Name, player.Level.ToString());
        }
        table.Title = new TableTitle("Select a Player");
        table.Border = TableBorder.Rounded;
        table.BorderColor(Color.Green);
        
        
        
        AnsiConsole.Write(table);
        var selected = PromptService.PromptLoadPlayer(players);
        Player.SetActivePlayer(selected);


    }
}