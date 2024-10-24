using Hangman.model;

namespace Hangman.controller.commands
{
    internal class StartGameCommand : ICommand
    {
        public string Description()
        {
            return "Начать игру";
        }

        public State Execute(State state)
        {
            new Game().StartGame();
            return state;
        }
    }
}
