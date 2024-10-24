using Hangman.controller.commands;

namespace Hangman.controller
{
    internal class HangmanController
    {
        private List<ICommand> commands = new List<ICommand>();
        private State state = new State();

        private void PrintCommands()
        {
            Console.Clear();
            for (int i = 0; i < commands.Count; i++)
            {
                var command = commands[i];
                Console.WriteLine($"{i + 1}: {command.Description()}");
            }
        }

        private int ReadIndex()
        {
            try
            {
                Console.Write("Опция>");
                var index = Convert.ToInt32(Console.ReadLine()) ;

                if (index > commands.Count || index < 1)
                {
                    PrintCommands();
                    Console.WriteLine("Не знаю такую команду. Попробуй снова");
                    return ReadIndex();
                }

                return index;
            }
            catch
            {
                PrintCommands();
                Console.WriteLine("Не удалось прочитать номер опции. Попробуй снова");
                return ReadIndex();
            }

        }

        private void SelectCommand()
        {
            Console.WriteLine("Выберите опцию");
            PrintCommands();
            var commandIndex = ReadIndex() - 1;
            commands[commandIndex].Execute(state);
        }

        public void Bootstrap()
        {
            commands.Add(new StartGameCommand());
            commands.Add(new QuitCommand());

            while (state.isRunning)
            {
                SelectCommand();
            }
        }
    }
}
