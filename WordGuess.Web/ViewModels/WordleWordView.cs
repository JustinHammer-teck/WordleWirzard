namespace WordGuess.Web.ViewModels;

public class WordleWordView
{
    public IEnumerable<string> PossibleWords { get; set; }
    public string  GuessWord { get; set; }
    public char[] Correctness { get; set; }
    public int Row { get; set; }
    public string[] UsedWords { get; set; }
    public string[] CorrectnessOfUsedWords { get; set; }
}