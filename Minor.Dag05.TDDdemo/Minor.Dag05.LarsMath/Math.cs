using System;

public class Math
{
    public int Fact(int n)
    {
        if (n < 1)
        {
            throw new InvalidOperationException();
        }
        return n == 1 ? 1: Fact(n - 1) * n; 
    }
}