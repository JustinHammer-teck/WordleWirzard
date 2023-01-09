namespace WordGuess.Web.Exceptions;

public class ExceededRowNumberException : Exception
{
    public ExceededRowNumberException() : base("Exceeded Row")
    {
    }
}