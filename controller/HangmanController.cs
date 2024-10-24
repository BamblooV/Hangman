using Hangman.model;

namespace Hangman.controller
{
    internal class HangmanController
    {
        public void Bootstrap()
        {
            var game = new Game();

            game.StartGame();
        }
    }
}
