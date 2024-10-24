using Hangman.view;

namespace Hangman.model
{
    internal class Game
    {
        const int MAX_LIVES = 5;
        private int lives = MAX_LIVES;

        private string word = "";
        private List<char> guessedChars = new List<char>();
        private int lettersToGuessCount = 0;
        private int rightLettersCounter = 0;

        private IView view = new ConsoleRenderer();
        private DictionaryService dictionaryService = DictionaryService.getInstance();

        public Game()
        {
            word = dictionaryService.GetRandomWord();
            lettersToGuessCount = word.Distinct().Count();
        }

        private char ReadLetter()
        {
            var pressedKey = Console.ReadKey().KeyChar;

            var isLetter = Char.IsLetter(pressedKey);
            var isAlreadyUsed = guessedChars.Contains(pressedKey);

            while (!isLetter || isAlreadyUsed)
            {
                if (!isLetter)
                {
                    Console.WriteLine($"\n{pressedKey} is not character.");
                }

                if (isAlreadyUsed)
                {
                    Console.WriteLine($"\n{pressedKey} was already used. Try another one.");
                }

                view.PrintPrompt();
                pressedKey = Console.ReadKey().KeyChar;
                isLetter = Char.IsLetter(pressedKey);
                isAlreadyUsed = guessedChars.Contains(pressedKey);
            }

            return pressedKey;
        }

        private void MakeTurn()
        {
            view.PrintFrame(MAX_LIVES - lives, word, guessedChars);
            view.PrintPrompt();

            var pressedKey = ReadLetter();

            guessedChars.Add(pressedKey);

            if (word.Contains(pressedKey))
            {
                rightLettersCounter++;
            }
            else
            {
                lives--;
            }
        }

        public void StartGame()
        {
            while (lives > 0 && rightLettersCounter < lettersToGuessCount)
            {
                MakeTurn();
            }

            view.PrintFrame(MAX_LIVES - lives, word, guessedChars);
            Console.WriteLine();

            if (lives == 0)
            {
                Console.WriteLine("Game over");
                Console.WriteLine($"Correct word is {word}");
            }

            if (rightLettersCounter == lettersToGuessCount)
            {
                Console.WriteLine("You win");
            }

            Console.WriteLine("\nEnter any key to back to menu");
            Console.ReadKey();
        }
    }
}
