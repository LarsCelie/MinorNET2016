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

        public void Hit(PlayerHitCommand command)
        {
            _gameService.Hit();
        }

        public void Stand(PlayerStandCommand command)
        {
            _gameService.Stand();
        }

        public void PlayerHand(RevealPlayerHandCommand command)
        {
            _gameService.ShowPlayerHand();
        }

        public void RestartGame(RestartGameCommand command)
        {
            _gameService.RestartGame();
        }
    }
}
