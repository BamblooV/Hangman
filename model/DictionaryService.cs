using System.Reflection;
using System.Text;

namespace Hangman.model
{
    internal class DictionaryService
    {
        private static DictionaryService? instance = null;
        private List<string> words = new List<string>();
        Random random = new Random();

        private DictionaryService()
        {
            words = new List<string>([
                "библиотека",
                "самосвал",
                "машина",
                "кенгуру",
                "абберация",
                "карандаш",
                "мишень",
                "программирование"
                ]);
        }

        public static DictionaryService getInstance()
        {
            if (instance == null)
            {
                instance = new DictionaryService();
                instance.LoadWords();
            }

            return instance;
        }

        public void LoadWords()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding("windows-1251");
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Hangman.resources.ru.txt"))
                using (var reader = new StreamReader(stream, encoding))
                {
                    string word;
                    while ((word = reader.ReadLine()) != null)
                    {
                        words.Add(word.ToLower());
                    }

                }
            }
            catch
            {
                Console.WriteLine("Ее удалось загрузить словарик из ресурсов.");
            }
        }

        public string GetRandomWord(int minWordLength = 4, int maxWordLength = 8)
        {
            var suitableWords = words.FindAll(word => word.Length >= minWordLength && word.Length <= maxWordLength);
            var selectedWordIndex = random.Next(0, suitableWords.Count);
            return suitableWords[selectedWordIndex];
        }
    }
}
