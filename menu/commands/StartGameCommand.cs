using Hangman.game.controller;
using Hangman.game.model;

namespace Hangman.menu.commands
{
    internal class StartGameCommand : ICommand
    {
        public void Execute(Menu context)
        {
            IVocabulary vocabulary;

            try
            {
                vocabulary = new ResourceVocabulary();
            }
            catch (NullReferenceException e)
            {
                vocabulary = new CodeVocabulary();
            }

            new GameController(vocabulary).StartGame();
        }
    }
}
