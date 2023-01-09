namespace WordGuess.Web.Exceptions;

public class WordleWordsException : Exception
{
    public WordleWordsException() : base("No Word to Process")
    {
    }
}