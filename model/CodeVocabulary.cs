namespace Hangman.model
{
    internal class CodeVocabulary : Vocabulary, IVocabulary
    {
        private CodeVocabulary()
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
    }
}
