namespace Hangman.controller.commands
{
    internal class QuitCommand : ICommand
    {
        public string Description()
        {
            return "Выйти";
        }

        public State Execute(State state)
        {
            state.isRunning = false;
            return state;
        }
    }
}
