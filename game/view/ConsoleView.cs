namespace Hangman.game.view
{
    internal class ConsoleView : IHangmanView
    {
        private string[] hangmanFrames = [
            """
             +---+
                 |
                 |
                 |
                ===
            """,
            """
             +---+
             O   |
                 |
                 |
                ===
            """,
            """
             +---+
             O   |
            /|   |
                 |
                ===
            """,
            """
             +---+
             O   |
            /|\  |
                 |
                ===
            """,
            """
             +---+
             O   |
            /|\  |
            /    |
                ===
            """,
            """
             +---+
             O   |
            /|\  |
            / \  |
                ===
            """,
        ];

        public void PrintHangman(int lives)
        {
            var index = Math.Max(hangmanFrames.Length - 1 - lives, 0);
            Console.WriteLine(hangmanFrames[index]);
        }

        public void PrintMaskedWord(string maskedWord)
        {
            Console.WriteLine(String.Join(' ', maskedWord.Split()));
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int i = 0; i < maskedWord.Length; i++)
            {
                Console.Write("\u0305");
            }
            Console.WriteLine();
        }

        public void PrintPrompt()
        {
            Console.Write("Введите букву: ");
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public char ReadLetter()
        {
            var pressedKey = Console.ReadKey().KeyChar;

            var isOk = Char.IsLetter(pressedKey) && Char.IsLower(pressedKey);

            if (!isOk)
            {
                throw new ArgumentException("Requires only letters in low.");
            }

            return pressedKey;
        }

        public void PrintExit()
        {
            Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}
