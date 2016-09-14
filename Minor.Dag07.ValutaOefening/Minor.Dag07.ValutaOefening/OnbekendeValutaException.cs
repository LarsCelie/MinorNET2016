using System;

public class OnbekendeValutaException : Exception
{
    public OnbekendeValutaException()
    {
    }

    public OnbekendeValutaException(string message) : base(message)
    {
    }

    public OnbekendeValutaException(string message, Exception innerException) : base(message, innerException)
    {
    }
}