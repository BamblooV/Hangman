using Hangman.model;

namespace Hangman.menu.commands
{
    internal class StartGameCommand : ICommand
    {
        public void Execute(Menu context)
        {
            new Game().StartGame();
        }
    }
}
