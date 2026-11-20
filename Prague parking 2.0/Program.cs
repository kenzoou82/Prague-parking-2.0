using Prague_parking_klasser;
using Spectre.Console;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
namespace Prague_parking_2._0;

internal class Program
{
    static void Main(string[] args)
    {
        ParkingGarage garage = new ParkingGarage(100);
        bool mainMenu = true;
        while (mainMenu)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]╔═╗╦═╗╔═╗╔═╗╦ ╦╔═╗  ╔═╗╔═╗╦═╗╦╔═╦╔╗╔╔═╗  ╔═╗ ╔═╗[/]");
            AnsiConsole.MarkupLine(  "[bold red]╠═╝╠╦╝╠═╣║ ╦║ ║║╣   ╠═╝╠═╣╠╦╝╠╩╗║║║║║ ╦  ╔═╝ ║ ║[/]");
            AnsiConsole.MarkupLine("[bold gold1]╩  ╩╚═╩ ╩╚═╝╚═╝╚═╝  ╩  ╩ ╩╩╚═╩ ╩╩╝╚╝╚═╝  ╚═╝o╚═╝[/]");
            AnsiConsole.WriteLine();

            var menuChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold gold1]Välj med piltangenterna och tryck enter.[/]")
                .AddChoices(new[]
                {
                    "Parkera fordon",
                    "Flytta fordon",
                    "Sök fordon",
                    "Ta bort fordon",
                    "Översikt Garage"
                }));

            switch (menuChoice)
            {
                case "Parkera fordon":

                    ParkVehicleMenu(garage);
                    break;

                case "Flytta fordon":

                    break;
                case "Sök fordon":

                    break;
                case "Ta bort fordon":

                    break;
                case "Översikt Garage":

                    GarageOverview(garage);
                    break;
            }
        }
    }


    #region Metoder

    #region Park Vehicle
    static void ParkVehicleMenu(ParkingGarage garage)
    {
        AnsiConsole.Clear();
        var vehicleType = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold gold1]Välj fordonstyp:[/]")
                .AddChoices("Bil", "Motorcykel"));

        AnsiConsole.MarkupLine($"[gold1]Du valde: {vehicleType}.[/]");
        string regNumber = AnsiConsole.Ask<string>("[gold1]Ange registreringsnummer:[/]");

        try
        {
            Vehicle newVehicle = vehicleType == "Bil"
                ? new Car(regNumber)
                : new Motorcycle(regNumber);

            int spotNumber = garage.ParkVehicle(newVehicle);
            if (spotNumber > 0)
            {
                AnsiConsole.MarkupLine($"[bold green]Du har fått plats nummer {spotNumber} [/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Garaget är fullt![/]");
            }
        }
        catch (ArgumentException ex)
        {
            AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
        }

        AnsiConsole.MarkupLine("\n[grey]Tryck på valfri tangent för att återgå till menyn...[/]");
        Console.ReadKey(true);
    }

    #endregion Park Vehicle

    #region Garage Overview
    static void GarageOverview(ParkingGarage garage)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(Align.Center(new Markup("[bold gold1] Garage Översikt[/]")));
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        foreach (var spot in garage.Spots)
        {   
            AnsiConsole.Markup($"[green] {spot.SpotNumber} [/]");

            if (spot.VehiclesInSpot.Count == 0)
            {
                AnsiConsole.Markup("[green]Ledig[/]");
            }
            else if (spot.VehiclesInSpot.Count < spot.MaxSpace)
            {
                var mc = spot.VehiclesInSpot[0];
                AnsiConsole.Markup($"[yellow] [[{spot.SpotNumber:000} {mc.RegNumber} ]] [/]");
            }
            else
            {
                AnsiConsole.Markup($"[red] [[{spot.SpotNumber:000} FULLT]] [/]");
            }
            if (spot.SpotNumber % 5 == 0)
            {
                AnsiConsole.WriteLine();
            }
        }
        AnsiConsole.MarkupLine("\n[grey]Tryck på valfri tangent för att återgå till menyn...[/]");
        Console.ReadKey(true);
    }
    #endregion Garage Overview

    #endregion Metoder
}