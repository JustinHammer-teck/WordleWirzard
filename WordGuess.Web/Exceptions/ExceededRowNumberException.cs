namespace WordGuess.Web.Exceptions;

public class ExceededRowNumberException : Exception
{
    public ExceededRowNumberException(string message): base(message)
    {
        
    }
}