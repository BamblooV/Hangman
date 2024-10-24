namespace Hangman.controller.commands
{
    internal interface ICommand
    {
        public State Execute(State state);
        public string Description();
    }
}
