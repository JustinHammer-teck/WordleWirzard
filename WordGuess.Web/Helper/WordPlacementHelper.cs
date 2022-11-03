namespace WordGuess.Web.Helper;

public class WordPlacementHelper
{
    public char[] BadLetter(string result, string guess)
    {
        var badLetter = new char[5] { '\0', '\0', '\0', '\0', '\0' };

        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'B')
            {
                badLetter[i] = guess[i];
            }
        }

        return badLetter;
    }

    public (char, int)[] WrongPlacement(string result, string guess)
    {
        var wrongPlacement = new (char, int)[5];
        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'Y')
            {
                wrongPlacement[i] = (guess[i], i);
            }
            else
            {
                wrongPlacement[i] = ('\0', i);
            }
        }

        return wrongPlacement;
    }


    public (char, int)[] CorrectPlacement(string result, string guess)
    {
        var correctPlacement = new (char, int)[5];
        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'G')
            {
                correctPlacement[i] = (guess[i], i);
            } else
            {
                correctPlacement[i] = ('\0', i);
            }
        }

        return correctPlacement;
    }    
}