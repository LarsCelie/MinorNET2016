using System;

public class OnbekendeValutaException : InvalidOperationException
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