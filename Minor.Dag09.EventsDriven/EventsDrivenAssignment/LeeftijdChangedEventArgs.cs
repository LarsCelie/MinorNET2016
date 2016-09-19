using System;

namespace EventsDrivenAssignment
{
    public delegate void LeeftijdChangedHandler(object sender, LeeftijdChangedEventArgs e);

    public class LeeftijdChangedEventArgs : EventArgs
    {
        public string Naam {get;}
        public int OudeLeeftijd { get;  }
        public int NieuweLeeftijd { get; }

        public LeeftijdChangedEventArgs(string naam, int oudeLeeftijd, int nieuweLeeftijd)
        {
            this.Naam = naam;
            this.OudeLeeftijd = oudeLeeftijd;
            this.NieuweLeeftijd = nieuweLeeftijd;
        }
    }

}


