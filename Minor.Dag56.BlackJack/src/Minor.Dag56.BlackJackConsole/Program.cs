using Minor.Dag56.BlackJack;
using Minor.Dag56.BlackJack.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJackConsole
{
    public class Program
    {
        private static BlackJackController _controller;
        private static BlackJackDispatcher _dispatcher;
        public static void Main(string[] args)
        {
            _controller = new BlackJackController(new GameEventRepository());
            _dispatcher = new BlackJackDispatcher();
            string command = "";
            while ((command = Console.ReadLine()).ToLower() != "quit")
            {
                switch (command)
                {
                    case "hit":
                        PlayerHit();
                        break;
                    case "stand":
                        PlayerStand();
                        break;
                    case "restart":
                        PlayerRestart();
                        break;
                    default:
                        InvalidCommand();
                        break;
                }
            }


            Console.WriteLine();
            Console.WriteLine("We hope you had fun playing!");
        }

        private static void PlayerRestart()
        {
            throw new NotImplementedException();
        }

        private static void InvalidCommand()
        {
            Console.WriteLine("Invalid command, try again");
        }

        private static void PlayerStand()
        {
            _controller.Stand();
        }

        private static void PlayerHit()
        {
            _controller.Hit();
        }
    }
}
