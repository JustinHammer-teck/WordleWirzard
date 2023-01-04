using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WordGuess.Web.Services;

public class EliminationWordService
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string pathToRoot;

    public EliminationWordService(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        pathToRoot = Path.Combine(_hostingEnvironment.WebRootPath);
    }
    public IEnumerable<Tuple<string, int, int>> GetEliminationWord(string[] usedWords,
        string[] correctnessOfUsedWords,
        IEnumerable<string> possibleWords,
        IEnumerable<(char, int[])> letterFeq,
        int wordleLevel = 1)
    {
        var result = new List<Tuple<string, int, int>>();

        var overallLetterFeq = OverAllLetterFeq(possibleWords, letterFeq);
        
        var guessWords= File.ReadAllLines(pathToRoot + "/src/word_guess.txt");
        
        var refWord = guessWords.Where(guess =>
        {
            for (var i = 0; i < usedWords.Length; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    return !(correctnessOfUsedWords[i][j] == 'G' && usedWords[i][j] == guess[j]);
                }
            }

            return true;
        });

        var something = refWord;
        
        foreach (var word in refWord)
        {
            var overallScore = GetOverallScore(word, overallLetterFeq);

            var positionScore = GetPositionalScore(word, letterFeq);

            result.Add(new Tuple<string, int, int>(word, overallScore, positionScore));
        }

        return result;
    }
    
    private IEnumerable<Tuple<char, int>> OverAllLetterFeq(IEnumerable<string> possibleWords, IEnumerable<(char, int[])> letterFeq)
    {
        var result = new List<Tuple<char, int>>();
        foreach (var letterScore in letterFeq)
        {
            var score = 0;
            for (var i = 0; i < 5; i++) score += letterScore.Item2[i];
            result.Add(new Tuple<char, int>(letterScore.Item1, score));
        }

        return result;
    }

    
    private int GetPositionalScore(string word, IEnumerable<(char, int[])> letterFeq)
    {
        var positionalScore = 0;
        foreach (var letter in letterFeq)
            for (var i = 0; i < 5; i++)
                if (word[i] == letter.Item1)
                    positionalScore += letter.Item2[i];

        return positionalScore;
    }

    private int GetOverallScore(string word, IEnumerable<Tuple<char, int>> overallLetterFeq)
    {
        var overallScore = 0;
        foreach (var letter in overallLetterFeq)
            for (var i = 0; i < 5; i++)
                if (word[i] == letter.Item1)
                    overallScore += letter.Item2;

        return overallScore;
    }
}