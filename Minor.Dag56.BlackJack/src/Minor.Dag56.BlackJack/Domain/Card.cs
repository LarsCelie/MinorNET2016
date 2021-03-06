﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int GetValue()
        {
            if (Rank < Rank.Jack)
            {
                return (int)Rank + 2;
            }
            else if (Rank == Rank.Ace)
            {
                return 11;
            }
            else
            {
                return 10;
            }
        }

    }




    public enum Suit
    {
        Hearts, Spades, Clubs, Diamonds
    }

    public enum Rank
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }
}
