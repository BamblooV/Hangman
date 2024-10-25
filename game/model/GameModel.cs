namespace Hangman.game.model
{
    internal class GameModel
    {
        public int Lives { get; private set; }
        public readonly int  MAX_LIVES = 6;
        
        private SecretWord secretWord = null;
        private List<char> checkedLetters = new List<char>();

        public GameModel(string secretWord)
        {
            this.secretWord = new SecretWord(secretWord);
            Lives = MAX_LIVES;
        }

        public string GetMaskedWord()
        {
            return secretWord.GetMaskedWord();
        }

        public string GetSecretWord()
        {
            return secretWord.GetSecretWord();
        }

        public IEnumerable<char> GetCheckedLetters() { 
            return checkedLetters.ToArray();
        }

        public void CheckLetter(char letter)
        {
            if (IsGameOver()) return;

            if (checkedLetters.Contains(letter))
            {
                throw new ArgumentException("Already checked letter");
            }

            checkedLetters.Add(letter);

            if (!secretWord.IsSecretContains(letter))
            {
                Lives--;
            }
        }

        public bool IsLost()
        {
            return Lives == 0;
        }

        public bool IsWon() {
            return Lives != 0 && secretWord.IsSecretWordFullyOpen();
        }

        public bool IsGameOver()
        {
            return IsLost() || IsWon();
        }
    }
}
