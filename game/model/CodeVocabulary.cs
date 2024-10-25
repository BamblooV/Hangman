namespace Hangman.game.model
{
    internal class CodeVocabulary : Vocabulary, IVocabulary
    {
        public CodeVocabulary()
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
