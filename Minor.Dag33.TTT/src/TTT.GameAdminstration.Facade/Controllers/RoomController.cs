using Microsoft.AspNetCore.Mvc;
using System;
using TTT.GameAdministration.Outgoing;

namespace TTT.GameAdminstration.Facade.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        [HttpPost]
        public void CreateRoomAndJoin(CreateRoomCommand crc)
        {
            throw new NotImplementedException();
        }
    }
}