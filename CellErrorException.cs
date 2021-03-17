using System;



public class CellErrorException : Exception
{
    public CellErrorException()
    {
    }

    public CellErrorException(string message)
        : base(message)
    {
    }

    public CellErrorException(string message, Exception inner)
        : base(message, inner)
    {
    }
}