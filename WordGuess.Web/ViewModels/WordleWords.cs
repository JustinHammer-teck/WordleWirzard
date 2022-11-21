namespace WordGuess.Web.ViewModels;

public class WordleWords
{
    public IOrderedEnumerable<string> PossibleWords { get; set; }
    public string EliminationWord { get; set; }
    public string BestWord { get; set; }
}