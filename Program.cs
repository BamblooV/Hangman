using Hangman.controller;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new HangmanController();

            controller.Bootstrap();
        }
    }
}
