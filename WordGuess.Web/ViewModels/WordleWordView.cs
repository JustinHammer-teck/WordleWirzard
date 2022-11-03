namespace WordGuess.Web.ViewModels;

public class WordleWordView
{
    public string[] PossibleWords { get; set; }
    public string  GuessWord { get; set; }
    public char[] Correctness { get; set; }
    public int Row { get; set; }
}