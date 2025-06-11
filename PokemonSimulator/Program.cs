using PokemonSimulator;
using PokemonSimulator.Abstractions;

IUserInterface ui = new ConsoleUI();

var game = new Main(ui);
game.Run();

Console.ForegroundColor = ConsoleColor.DarkGreen;
ui.WriteLine("\n\n\n*** Game over ***\n\n");
ui.WriteLine("Press Enter to close program...");
ui.ReadLine();
