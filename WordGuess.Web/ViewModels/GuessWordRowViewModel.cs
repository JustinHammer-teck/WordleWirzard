namespace WordGuess.Web.ViewModels;

public class GuessWordRowViewModel
{
    public int Id { get; set; }
    
    public List<GuessWordViewModel> GuessWords { get; set; }
}