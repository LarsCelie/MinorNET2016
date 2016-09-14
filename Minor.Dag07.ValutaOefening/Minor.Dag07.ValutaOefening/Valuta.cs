using System;

public struct Valuta
{
    private readonly Muntsoort _Soort;
    private readonly decimal _Bedrag;

    public Valuta(Muntsoort soort, decimal bedrag)
    {
        _Soort = soort;
        _Bedrag = bedrag;
    }

    public override string ToString()
    {
        string voorvoegsel = berekenVoorvoegsel();
        return voorvoegsel + string.Format("{0:N2}", _Bedrag);
    }

    public string berekenVoorvoegsel()
    {
        string prefix = "";
        switch (_Soort)
        {
            case Muntsoort.Euro:
                {
                    prefix = "EUR "; break;
                }
            case Muntsoort.Gulden:
                {
                    prefix = "fl "; break;
                }
            case Muntsoort.Florijn:
                {
                    prefix = "fl "; break;
                }
            case Muntsoort.Dukaat:
                {
                    prefix = "HD "; break;
                }
            default:
                {
                    throw new OnbekendeValutaException();
                }
        }
        return prefix;
    }

    public Valuta BerekenNaar(Muntsoort soort)
    {
        decimal nieuwBedrag = BerekenNaarGulden();
        switch (soort)
        {
            case Muntsoort.Dukaat:
                {
                    nieuwBedrag *= 5.1M;
                    break;
                }
            case Muntsoort.Euro:
                {
                    nieuwBedrag /= 2.20371M;
                    break;
                }
            case Muntsoort.Florijn:
                {
                    break;
                }
        }
        return new Valuta(soort, nieuwBedrag);
    }

    private decimal BerekenNaarGulden()
    {
        decimal bedragInGulden = _Bedrag;
        switch (_Soort)
        {
            case Muntsoort.Dukaat:
                {
                    bedragInGulden /= 5.1M;
                    break;
                }
            case Muntsoort.Euro:
                {
                    bedragInGulden *= 2.20371M;
                    break;
                }
            case Muntsoort.Florijn:
                {
                    break;
                }
        }
        return bedragInGulden;
    }

    public static Valuta operator + (Valuta val1, Valuta val2)
    {
        Muntsoort soort = val1._Soort;
        return new Valuta(soort, val1._Bedrag + val2.BerekenNaar(soort)._Bedrag);
    }

    public static Valuta operator * (Valuta val1, Valuta val2)
    {
        Muntsoort soort = val1._Soort;
        return new Valuta(soort, val1._Bedrag * val2.BerekenNaar(soort)._Bedrag);
    }

    public static implicit operator decimal(Valuta val)
    {
        return val.BerekenNaar(Muntsoort.Euro)._Bedrag;
    }

    public static implicit operator Valuta(decimal dec)
    {
        return new Valuta(Muntsoort.Euro, dec);
    }
}