
namespace Hangman.model
{
    internal class DictionaryService
    {
        private static DictionaryService? instance = null;
        Random random = new Random();

        private DictionaryService() { }

        public static DictionaryService getInstance()
        {
            if (instance == null)
            {
                instance = new DictionaryService();
            }

            return instance;
        }

        public string GetRandomWord(int minWordLength = 4, int maxWordLength = 6)
        {
            return "библиотека";
        }
    }
}
