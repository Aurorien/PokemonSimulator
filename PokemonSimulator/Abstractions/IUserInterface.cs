namespace PokemonSimulator.Abstractions
{
    public interface IUserInterface
    {
        void WriteLine(string message);
        void Write(string message);
        string ReadLine();
    }
}
