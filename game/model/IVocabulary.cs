namespace Hangman.game.model
{
    internal interface IVocabulary
    {
        public string getRandomWord(int minLength, int maxLength);
    }
}
