using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTT.GameAdminstration.Facade.Controllers;

namespace TTT.GameAdministration.Facade.Test
{
    [TestClass]
    public class ProgramTest
    {

        [TestMethod]
        public void CreateGameRoom()
        {
            CreateRoomCommand crc = new CreateRoomCommand { RoomName = "UniqueRoomName1", GameName = "Tic-Tac-Toe", PlayerName = "Lars", Colour = "Black"};
            RoomController target = new RoomController();

            target.CreateRoomAndJoin(crc);
            

        }
    }
}
