namespace WordGuess.Web.ViewModels;

public class WordleWordView
{
    public IEnumerable<string> PossibleWords { get; set; }
    public string  GuessWord { get; set; }
    public char[] Correctness { get; set; }
    public int Row { get; set; }
    public IEnumerable<UsedWord> UsedWords { get; set; }
}

public class UsedWord
{
    public string Word { get; set; }
    public string Correctness { get; set; }
}