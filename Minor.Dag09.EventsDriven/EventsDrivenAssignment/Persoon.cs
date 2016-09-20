using System;

namespace EventsDrivenAssignment
{
    public class Persoon
    {
        public event LeeftijdChangedHandler LeeftijdChanged;
        private int _leeftijd;
        public string Naam { get; set; }

        public int Leeftijd
        {
            get
            {
                return _leeftijd;
            }

            set
            {
                OnLeeftijdChanged(new LeeftijdChangedEventArgs(Naam, _leeftijd, value));
                _leeftijd = value;
            }
        }

        public void Verjaar()
        {
            OnLeeftijdChanged(new LeeftijdChangedEventArgs(Naam, Leeftijd, ++Leeftijd));
        }

        protected virtual void OnLeeftijdChanged(LeeftijdChangedEventArgs e)
        {
            LeeftijdChangedHandler temp = LeeftijdChanged;
            temp?.Invoke(this, e);
        }
    }
}