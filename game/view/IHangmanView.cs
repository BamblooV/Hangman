namespace Hangman.game.view
{
    internal interface IHangmanView
    {
        public void PrintHangman(int lives);
        public void PrintMaskedWord(string maskedWord);
        public void PrintPrompt();
        public void PrintText(string text);
        public void PrintExit();
        public void ClearScreen();
        public char ReadLetter();
    }
}
