using Hangman.game.model;
using Hangman.game.view;

namespace Hangman.game.controller
{
    internal class GameController
    {
        private IHangmanView view;
        private GameModel model;

        public GameController() : this(new ConsoleView(), new CodeVocabulary()) { }
        public GameController(IVocabulary vocabulary) : this(new ConsoleView(), vocabulary) { }

        public GameController(IHangmanView view, IVocabulary vocabulary)
        {
            this.view = view;
            model = new GameModel(vocabulary.getRandomWord(4, 8));
        }

        private void PrintFrame()
        {
            view.ClearScreen();
            view.PrintHangman(model.Lives);
            view.PrintText($"Оставшееся количество жизней: {model.Lives}");
            view.PrintText($"Уже проверенные буквы: {String.Join(' ', model.GetCheckedLetters())}");
            view.PrintMaskedWord(model.GetMaskedWord());
        }

        private void Turn()
        {
            while (true)
            {
                view.PrintPrompt();
                char userLetter;

                try
                {
                    userLetter = view.ReadLetter();
                }
                catch (ArgumentException ex)
                {
                    view.PrintText("\nМожно вводить только буквы в нижнем регистре. Попробуй снова");
                    continue;
                }

                try
                {
                    model.CheckLetter(userLetter);
                    return;
                }
                catch (ArgumentException ex)
                {
                    view.PrintText("\nБуква уже была введена. Попробуйие другую.");
                    continue;
                }
            }
        }

        public void StartGame()
        {
            while (!model.IsGameOver())
            {
                PrintFrame();
                Turn();
            }

            PrintFrame();

            if (model.IsLost())
            {
                view.PrintText("Вы проиграли.");
                view.PrintText($"Загаданное слово: {model.GetSecretWord()}");
            }

            if (model.IsWon())
            {
                view.PrintText("Вы победили.");
            }

            view.PrintExit();
        }
    }
}
