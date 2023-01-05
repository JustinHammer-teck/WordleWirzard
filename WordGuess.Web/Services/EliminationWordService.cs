using WordGuess.Web.Helper;
using WordGuess.Web.ViewModels;
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

    public IEnumerable<Tuple<string, int, int>> GetEliminationWord(IEnumerable<UsedWord> usedWords,
        IEnumerable<string> possibleWords,
        IEnumerable<(char, int[])> letterFeq,
        int wordleLevel = 1)
    {
        var result = new List<Tuple<string, int, int>>();
        var helper = new WordPlacementHelper();
        var wordScoreService = new WordScoringService();
        var correctWords = new List<Tuple<char, int>>();

        foreach (var usedWord in usedWords)
        {
            correctWords.AddRange(helper.CorrectPlacement(usedWord.Correctness, usedWord.Word));
        }

        var usedWordsOnly = usedWords.Select(x => x.Word);
        var guessWords = File.ReadAllLines(pathToRoot + "/src/level3smashword.txt");
        var overallLetterFeq = OverAllLetterFeq(letterFeq);

        switch (wordleLevel)
        {
            case 1:
            {
                foreach (var word in guessWords
                             .Where(fw => !usedWordsOnly.Contains(fw))
                             .Where(fw => correctWords.All(cp => fw[cp.Item2] != cp.Item1)))
                {
                    var overallScore = GetOverallScore(word, overallLetterFeq);

                    var positionScore = GetPositionalScore(word, letterFeq);

                    result.Add(new Tuple<string, int, int>(word, overallScore, positionScore));
                }

                break;
            }
            case 2:
            {
                var filtered = RemovePatternRepeatLetters(possibleWords);
                var letterFeqMagicWand2 = wordScoreService.LetterFeq(filtered);
                
                break;
            }
        }

        if (possibleWords.Count() <= 3)
        {
            result.Clear();
        }

        return result
            .Distinct()
            .OrderByDescending(x => x.Item2)
            .ThenByDescending(x => x.Item3);
    }

    private IEnumerable<string> RemovePatternRepeatLetters(IEnumerable<string> possibleWords)
    {
        var mostFeqLetterInList = new List<(char, int)>();

        foreach (var word in possibleWords)
        {
            mostFeqLetterInList.AddRange(word
                .Select((c, i) => new { c, i })
                .Where(letter => possibleWords.All(w => w[letter.i] == letter.c))
                .Select(x => (x.c, x.i)));
        }

        var result = new Dictionary<int, string>();


        for (var i = 0; i < possibleWords.Count(); i++)
        {
            var value = possibleWords.ToList()[i];
            foreach (var letter in mostFeqLetterInList.Distinct())
            {
                var reference = value.ToCharArray();
                reference[letter.Item2] = '-'; 
                value = new string(reference);
            }
            result.Add(i, value);
        }

        return result.Select(x => x.Value);
    }

    private IEnumerable<Tuple<char, int>> OverAllLetterFeq(
        IEnumerable<(char, int[])> letterFeq)
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