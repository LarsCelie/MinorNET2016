using Minor.Dag56.BlackJack;
using Minor.Dag56.BlackJack.Common.Commands;
using Minor.Dag56.BlackJack.Domain;
using Minor.Dag56.BlackJack.DomainService;
using Minor.Dag56.BlackJack.Infastructure;
using Minor.WSA.Common.Interfaces;
using Minor.WSA.EventBus.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJackConsole
{
    public class Program
    {
        private static BlackJackController _controller;
        private static BlackJackDispatcher _dispatcher;

        public static void Main(string[] args)
        {
            Setup();

            Console.WriteLine("Welcome to BlackJack Console!");
            Console.WriteLine("Type 'start' to start a new game or 'help' to see all commands.");

            string command = "";
            while ((command = Console.ReadLine().ToLower()) != "quit" && command != "exit")
            {
                try
                {
                    switch (command)
                    {
                        case "start":
                            StartGame();
                            break;
                        case "hit":
                            PlayerHit();
                            break;
                        case "stand":
                            PlayerStand();
                            break;
                        case "hand":
                            DisplayHand();
                            break;
                        case "help":
                            DisplayHelpMessage();
                            break;
                        case "restart":
                            PlayerRestart();
                            break;
                        default:
                            InvalidCommand();
                            break;
                    }
                } catch (InvalidOperationException)
                {
                    Console.WriteLine($"Unable to {command} while the game is not playing");
                }
            }


            Console.WriteLine();
            Console.WriteLine("We hope you had fun playing!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        private static void Setup()
        {
            IRepository repo = new GameEventRepository();
            IEventPublisher publisher = new EventPublisher();
            IGameService gameService = new GameService(repo, publisher);
            _controller = new BlackJackController(gameService);

            _dispatcher = new BlackJackDispatcher();
        }

        private static void StartGame()
        {
            StartGameCommand command = new StartGameCommand();
            _controller.StartGame(command);
        }

        private static void PlayerHit()
        {
            PlayerHitCommand command = new PlayerHitCommand();
            _controller.Hit(command);
        }

        private static void PlayerStand()
        {
            PlayerStandCommand command = new PlayerStandCommand();
            _controller.Stand(command);
        }

        private static void PlayerRestart()
        {
            RestartGameCommand command = new RestartGameCommand();
            _controller.RestartGame(command);
        }

        private static void InvalidCommand()
        {
            Console.WriteLine("Invalid command, if you forgot a command, see the 'help' for more information");
        }

        private static void DisplayHelpMessage()
        {
            Console.WriteLine("\nAvailable commands are:");
            Console.WriteLine("start \t- Starts a new game.");
            Console.WriteLine("restart - Stops the current game and starts a new game.");
            Console.WriteLine("hit \t- Get another card for your current hand.");
            Console.WriteLine("stand \t- Hold your cards and end your turn.");
            Console.WriteLine("hand \t- Display your hand and value.");
            Console.WriteLine("help \t- Display this message again.");
            Console.WriteLine("quit \t- Stop playing.");
            Console.WriteLine("exit \t- Another way to stop playing.");
        }

        private static void DisplayHand()
        {
            RevealPlayerHandCommand command = new RevealPlayerHandCommand();
            _controller.PlayerHand(command);
        }
    }
}
