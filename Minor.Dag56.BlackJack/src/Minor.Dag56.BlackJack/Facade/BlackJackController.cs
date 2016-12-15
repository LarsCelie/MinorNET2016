using Minor.Dag56.BlackJack.Common.Commands;
using Minor.Dag56.BlackJack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack
{
    public class BlackJackController
    {
        private IGameService _gameService;

        public BlackJackController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void StartGame(StartGameCommand command)
        {
            _gameService.StartGame();
        }

        public void Hit()
        {

        }

        public void Stand()
        {
            throw new NotImplementedException();
        }


    }
}
