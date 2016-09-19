namespace EventsDrivenAssignment.Test
{
    internal class ListenerMock
    {
        public bool LeeftijdChangedHandledHasBeenCalled { get; private set; }

        public LeeftijdChangedEventArgs LeeftijdChangedEventArgs { get; private set; }

        internal void LeeftijdChangedHandled(object sender, LeeftijdChangedEventArgs e)
        {
            LeeftijdChangedHandledHasBeenCalled = true;
            LeeftijdChangedEventArgs = e;
        }
    }
}