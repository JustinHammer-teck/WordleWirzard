using WordGuess.Web.Enums;

namespace WordGuess.Web.Models;

public class GuessWord
{
    public int? Indicator { get; set; }
    public char Letter { get; set; }
    public GuessLetterStatus Status { get; set; }
}