namespace Hangman.view
{
    internal interface IView
    {
        public void PrintFrame(int frameNumber, int health, string word, List<char> guessedLetters);

        public void PrintPrompt();
    }
}
