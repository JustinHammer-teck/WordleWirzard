namespace WordGuess.Web.Services;

public interface IWordScoreService
{
    IEnumerable<(string, double)> WordScore(IEnumerable<string> possibleWord,
        IEnumerable<(char, int[])> letterFeq);
}