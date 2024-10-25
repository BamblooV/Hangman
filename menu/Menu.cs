using Hangman.menu.commands;

namespace Hangman.menu
{
    internal class Menu
    {
        private List<ICommand> commands = new List<ICommand>();
        private Dictionary<ICommand, string> commandDescriptions = new Dictionary<ICommand, string>();

        public bool isRunning = true;

        public Menu()
        {
            AddCommand(new StartGameCommand(), "Начать игру");
            AddCommand(new QuitCommand(), "Выйти из приложения");
        }

        private void PrintCommands()
        {
            for (int i = 0; i < commands.Count; i++)
            {
                var command = commands[i];
                Console.WriteLine($"{i + 1}: {commandDescriptions[command]}");
            }
        }

        private int ReadCommandIndex()
        {
            int commandIndex;
            while (true)
            {
                var userInput = Console.ReadKey();
                if (Int32.TryParse(userInput.ToString(), out commandIndex))
                {
                    if (commandIndex > commands.Count || commandIndex < 1)
                    {
                        Console.WriteLine("Не знаю такую команду. Попробуй снова");
                        continue;
                    }
                    return commandIndex;
                }
                else
                {
                    Console.WriteLine("Введите номер опции меню.");
                }
            }
        }

        private void SelectCommand()
        {
            Console.Clear();
            Console.WriteLine("Выберите опцию");
            PrintCommands();
            var commandIndex = ReadCommandIndex() - 1;
            commands[commandIndex].Execute(this);
        }

        private void AddCommand(ICommand command, string description)
        {
            commands.Add(command);
            commandDescriptions.Add(command, description);
        }

        public void Start()
        {
            while (isRunning)
            {
                SelectCommand();
            }
        }
    }
}





