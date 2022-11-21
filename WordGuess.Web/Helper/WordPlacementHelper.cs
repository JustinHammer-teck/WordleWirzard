namespace WordGuess.Web.Helper;

public class WordPlacementHelper
{
    public List<char> BadLetter(string result, string guess)
    {
        var badLetter = new List<char>();

        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'B')
            {
                badLetter.Add(guess[i]);
            }
        }

        return badLetter;
    }

    public List<Tuple<char, int>> WrongPlacement(string result, string guess)
    {
        var wrongPlacement = new List<Tuple<char, int>>();
        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'Y')
            {
                wrongPlacement.Add(new Tuple<char, int>(guess[i], i));
            }
        }

        return wrongPlacement;
    }


    public List<Tuple<char, int>> CorrectPlacement(string result, string guess)
    {
        var correctPlacement = new List<Tuple<char, int>>();
        for (int i = 0; i < 5; i++)
        {
            if (result[i] == 'G')
            {
                correctPlacement.Add(new Tuple<char, int>(guess[i], i));
            }
        }

        return correctPlacement;
    }
}