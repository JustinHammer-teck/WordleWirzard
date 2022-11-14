namespace WordGuess.Web.ViewModels;

public class WordleWords
{
    public string[] GuessWords { get; set; }
    public IEnumerable<string> EliminationWord { get; set; }
    public string BestWord { get; set; }
}