namespace Hangman.game.model
{
    internal class SecretWord
    {
        private readonly string _secret;
        private HashSet<char> opennedLetters = new HashSet<char>();

        public SecretWord(string secretWord)
        {
            _secret = secretWord.Trim().ToLower();
        }

        public string GetMaskedWord()
        {
            List<char> result = new List<char>();

            foreach (var letter in _secret)
            {
                if (opennedLetters.Contains(letter))
                {
                    result.Add(letter);
                } else
                {
                    result.Add('*');
                }
            }

            return String.Concat(result);
        }

        public string GetSecretWord() { return _secret; }

        public bool IsSecretContains(char letter) { 
            if (_secret.Contains(letter))
            {
                opennedLetters.Add(letter);
                return true;
            }

            return false;
        }

        public bool IsSecretWordFullyOpen()
        {
            foreach (var letter in _secret)
            {
                if (!opennedLetters.Contains(letter)) return false;
            }

            return true;
        }
    }
}
