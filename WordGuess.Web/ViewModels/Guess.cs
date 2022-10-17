using WordGuess.Web.Enums;

namespace WordGuess.Web.ViewModels;

public class Guess
{
    public string Word { get; set; }
    public Correctness[] Status { get; set; }
}