using PokemonSimulator.Abstractions;

namespace PokemonSimulator
{
    public class ConsoleUI : IUserInterface
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
        public string ReadLine() => Console.ReadLine() ?? string.Empty;
    }
}
