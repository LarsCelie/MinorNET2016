using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public interface IGameService
    {
        void StartGame();

        void Init();
        void Shuffle();
        void DealPlayerCard();
    }
}
