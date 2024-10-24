using Hangman.model;
using Hangman.view;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            game.StartGame();
        }
    }
}
