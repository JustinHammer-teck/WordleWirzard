namespace WordGuess.Web.Services;

public interface ISmashWord
{
    IEnumerable<Tuple<string, int, int>> Solve(IEnumerable<string> possibleWords, IEnumerable<(char, int[])> letterFeq);
    IEnumerable<Tuple<char, int>> OverAllLetterFeq(IEnumerable<(char, int[])> letterFeq);
    int GetPositionalScore(string word, IEnumerable<(char, int[])> letterFeq);
    int GetOverallScore(string word, IEnumerable<Tuple<char, int>> overallLetterFeq);
}