namespace WordGuess.Web.ViewModels;

public class WordleWords
{
    public IEnumerable<string> PossibleWords { get; set; }
    public string EliminationWord { get; set; }
    public string BestWord { get; set; }
}