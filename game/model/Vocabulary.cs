namespace Hangman.game.model
{
    internal abstract class Vocabulary : IVocabulary
    {
        protected List<string> words = new List<string>();
        protected Random random = new Random();

        public string getRandomWord(int minLength, int maxLength)
        {
            var suitableWords = words.FindAll(word => word.Length >= minLength && word.Length <= maxLength);
            var selectedWordIndex = random.Next(0, suitableWords.Count);
            return suitableWords[selectedWordIndex];
        }
    }
}
