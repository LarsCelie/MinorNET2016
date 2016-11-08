namespace TTT.GameAdministration.Outgoing
{
    public class CreateRoomCommand
    {
        public string Colour { get; set; }
        public string GameName { get; set; }
        public string PlayerName { get; set; }
        public string RoomName { get; set; }
    }
}

