namespace Hangman.view
{
    internal class ConsoleRenderer : IView
    {
        private void PrintHangman(int frame)
        {
            switch (frame)
            {
                case 0:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine("    |");
                        Console.WriteLine("    |");
                        Console.WriteLine("    |");
                        Console.WriteLine("   ===");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine("O   |");
                        Console.WriteLine("    |");
                        Console.WriteLine("    |");
                        Console.WriteLine("   ===");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine(" O  |");
                        Console.WriteLine("/|  |");
                        Console.WriteLine("    |");
                        Console.WriteLine("   ==="); break;
                    }
                case 3:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine(" O  |");
                        Console.WriteLine("/|\\ |");
                        Console.WriteLine("    |");
                        Console.WriteLine("   ==="); break;
                    }
                case 4:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine(" O  |");
                        Console.WriteLine("/|\\ |");
                        Console.WriteLine("/   |");
                        Console.WriteLine("   ==="); break;
                    }
                case 5:
                    {
                        Console.WriteLine("\n+---+");
                        Console.WriteLine(" O   |");
                        Console.WriteLine("/|\\  |");
                        Console.WriteLine("/ \\  |");
                        Console.WriteLine("    ==="); break;
                    }
            }
        }

        private void DrawGuessedLetters(List<char> guessedLetters)
        {
            Console.Write("Предположенные буквы: ");
            foreach (var letter in guessedLetters)
            {
                Console.Write($"{letter} ");
            }
        }

        private void PrintWord(string word, List<char> guessedLetters)
        {
            foreach (var letter in word)
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write($"{letter} ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
        }

        private void PrintDashes(int wordLength)
        {
            for (int i = 0; i < wordLength; i++)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        public void PrintFrame(int frameNumber, string word, List<char> guessedLetters)
        {
            Console.Clear();
            PrintHangman(frameNumber);
            Console.WriteLine();
            DrawGuessedLetters(guessedLetters);
            Console.WriteLine();
            PrintWord(word, guessedLetters);
            Console.WriteLine();
            PrintDashes(word.Length);
        }

        public void PrintPrompt()
        {
            Console.Write("\nВведи букву: ");
        }
    }
}
