using Minor.Dag56.BlackJack.Common.Events;
using Minor.WSA.EventBus.Dispatchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJackConsole
{
    public class BlackJackDispatcher : EventDispatcher
    {

        public void GameStarted(GameStartedEvent @event)
        {
            Console.WriteLine("The game has started.");
        }

        public void DeckShuffled(DeckShuffledEvent @event)
        {
            Console.WriteLine("The dealer has shuffled the deck.");
        }

        public void CardDealt(PlayerCardDealtEvent @event)
        {
            Console.WriteLine($"You draw {@event.Card.Rank} of {@event.Card.Suit}");
        }

        public void HiddenCardDealt(PlayerHiddenCardDealtEvent @event)
        {
            Console.WriteLine($"You draw {@event.Card.Rank} of {@event.Card.Suit} as your hidden card");
        }

        public void DealerCardDealt(DealerCardDealtEvent @event)
        {
            Console.WriteLine($"The dealer draws {@event.Card.Rank} of {@event.Card.Suit}");
        }

        public void DealerHiddenCardDealt(DealerHiddenCardDealtEvent @event)
        {
            Console.WriteLine($"Dealer draws a hidden card");
        }

        public void DealerCardDealt(PlayerHandRevealedEvent @event)
        {
            Console.WriteLine("\nYour cards are:");
            foreach (var card in @event.Cards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
            Console.WriteLine();
        }

        public void PlayerHits(PlayerHitsEvent @event)
        {
            Console.WriteLine($"You hit and draw {@event.Card.Rank} of {@event.Card.Suit}");
        }

        public void DealerHits(DealerHitsEvent @event)
        {
            Console.WriteLine($"Dealer hits and draws {@event.Card.Rank} of {@event.Card.Suit}");
        }

        public void PlayerStands(PlayerStandsEvent @event)
        {
            Console.WriteLine($"You stand with {@event.HandWorthInPoints} points");
        }

        public void DealerStands(DealerStandsEvent @event)
        {
            Console.WriteLine($"Dealer stands with {@event.HandWorthInPoints} points");
        }

        public void PlayerBust(PlayerBustsEvent @event)
        {
            Console.WriteLine($"You bust with a total score of {@event.HandWorthInPoints}");
        }

        public void DealerBusts(DealerBustsEvent @event)
        {
            Console.WriteLine($"Dealer busts with a total score of {@event.HandWorthInPoints}");
        }

        public void PlayerBlackJack(PlayerBlackJackEvent @event)
        {
            Console.WriteLine("You have BlackJack!");
        }

        public void PlayerBlackJack(DealerBlackJackEvent @event)
        {
            Console.WriteLine("Dealer has BlackJack!");
        }

        public void PlayerWin(PlayerWinsEvent @event)
        {
            Console.WriteLine($"You won with {@event.PlayerHandValue} vs {@event.DealerHandValue}!");
            Console.WriteLine("\nDealer cards were:");
            foreach (var card in @event.DealerCards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public void PlayerLost(PlayerLostEvent @event)
        {
            Console.WriteLine($"You lost with {@event.PlayerHandValue} vs {@event.DealerHandValue}.");
            Console.WriteLine("\nDealer cards were:");
            foreach (var card in @event.DealerCards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public void PlayerPush(PlayerPushEvent @event)
        {
            Console.WriteLine($"You tied with {@event.PlayerHandValue}.");
            Console.WriteLine("\nDealer cards were:");
            foreach (var card in @event.DealerCards)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public void GameFinished(GameFinishedEvent @event)
        {
            Console.WriteLine("Game is now finished, do you wish to start again? type 'restart'");
        }
    }
}
