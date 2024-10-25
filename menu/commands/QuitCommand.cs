namespace Hangman.menu.commands
{
    internal class QuitCommand : ICommand
    {
        public void Execute(Menu context)
        {
            context.isRunning = false;
        }
    }
}
