using WordGuess.Web.Entities;
using WordGuess.Web.Exceptions;

namespace WordGuess.Web.ViewModels;

public class WordGuessRow
{
    private int RowId  { get; }
    private char[] Chars { get; }
    public WordGuessRow(int rowId, string text)
    {
        RowId = rowId;
        Chars = text.ToCharArray();
        if (rowId > 5)
        {
            throw new ExceededRowNumberException("Exceeded Word Guesses Row Number");
        }
    }

}