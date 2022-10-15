using WordGuess.Web.Enums;
using WordGuess.Web.Exceptions;
using WordGuess.Web.ViewModels;

namespace WordGuess.Web.Models;

public class GuessWordRow
{
    public GuessWordRow()
    {
        var guessWorks = new List<GuessWord>();
        for (int i = 0; i < 5; i++)
        {
            guessWorks.Add(new GuessWord()
            {
                Indicator = i,
                Status = GuessLetterStatus.None
            });
        }

        GuessWords = guessWorks;
    }

    public void UpdateGuessWordRow(IEnumerable<GuessWordViewModel> guessWords)
    {
        if (guessWords.Count() != 5)
        {
            throw new ExceededRowNumberException("Word Row Invalid");
        }

        foreach (var guessWord in guessWords)
        {
            GuessWords[guessWord.Indicator].Letter = guessWord.Letter;
            GuessWords[guessWord.Indicator].Status = Enum.Parse<GuessLetterStatus>(guessWord.Status);
        }
    }

    public void UpdateGuessWord(GuessWordViewModel guessWordViewModel)
    {
        GuessWords[guessWordViewModel.Indicator].Letter = guessWordViewModel.Letter;
        GuessWords[guessWordViewModel.Indicator].Status = Enum.Parse<GuessLetterStatus>(guessWordViewModel.Status);
    }

    public int Id { get; set; }
    public List<GuessWord> GuessWords { get; private set; }

    public bool IsValid()
    {
        return GuessWords.Count != 5 ? false : true;
    }
}