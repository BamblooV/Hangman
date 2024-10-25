using System.Reflection;
using System.Text;

namespace Hangman.model
{
    internal class ResourceVocabulary : Vocabulary, IVocabulary
    {
        public ResourceVocabulary()
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
                        var sanitizedWord = word.Trim().ToLower();

                        if (String.IsNullOrEmpty(sanitizedWord)) continue;

                        words.Add(sanitizedWord);
                    }

                }
            }
            catch
            {
                throw new NullReferenceException("Vocabulary resource is missed!");
            }

        }
    }
}
