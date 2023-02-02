using System.Text.RegularExpressions;
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

    public string GetEliminationWord(IEnumerable<UsedWord> usedWords,
        IEnumerable<string> possibleWords,
        IEnumerable<(char, int[])> letterFeq,
        string wordleStagePattern)
    {
        var forceSmashWord = GetForceSmashWord(wordleStagePattern);
        if (!string.IsNullOrWhiteSpace(forceSmashWord))
        {
            return forceSmashWord;
        }

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

        switch (possibleWords.Count())
        {
            case >= 28:
                GetSmashWordLevel1(letterFeq, guessWords, usedWordsOnly, correctWords, result);
                break;
            case >= 7 and < 28:
                GetSmashWordLevel2(possibleWords, guessWords, wordScoreService, usedWordsOnly, correctWords, result);
                break;
            case >= 3 and <= 6:
                GetSmashWordLevel3(possibleWords, guessWords, wordScoreService, usedWordsOnly, correctWords, result);
                break;
        }

        if (possibleWords.Count() < 3)
        {
            result.Clear();
        }

        return result
            .Distinct()
            .OrderByDescending(x => x.Item2)
            .ThenByDescending(x => x.Item3)
            .Select(x => x.Item1)
            .FirstOrDefault("");
    }

    private void GetSmashWordLevel3(IEnumerable<string> possibleWords, string[] guessWords,
        WordScoringService wordScoreService,
        IEnumerable<string> usedWordsOnly, List<Tuple<char, int>> correctWords, List<Tuple<string, int, int>> result)
    {
        var filtered = RemovePatternRepeatLetters(possibleWords);
        var filteredRepeatLetter = RemoveRepeatLetters(filtered);
        var letterFeq = wordScoreService.LetterFeq(filteredRepeatLetter);
        var overallLetterFeq = OverAllLetterFeq(letterFeq);

        // result.AddRange(guessWords
        //     .Where(fw => !usedWordsOnly.Contains(fw))
        //     .Where(fw => correctWords.All(cp => fw[cp.Item2] != cp.Item1))
        //     .Select(word => new Tuple<string, int, int>(word,
        //         GetOverallScoreSmashWord3(word, overallLetterFeq, possibleWords.Count(),
        //             possibleWords.Sum(x => x.Length)), 0)));

        foreach (var word in guessWords
                     .Where(fw => !usedWordsOnly.Contains(fw))
                     .Where(fw => correctWords.All(cp => fw[cp.Item2] != cp.Item1)))
        {
            var overallScore = GetOverallScoreSmashWord3(word, overallLetterFeq, possibleWords.Count(),
                possibleWords.Sum(x => x.Length));

            result.Add(new Tuple<string, int, int>(word, overallScore, 0));
        }
    }

    private void GetSmashWordLevel2(IEnumerable<string> possibleWords, string[] guessWords,
        WordScoringService wordScoreService,
        IEnumerable<string> usedWordsOnly, List<Tuple<char, int>> correctWords, List<Tuple<string, int, int>> result)
    {
        if (possibleWords.Count() < 15)
        {
            guessWords = File.ReadAllLines(pathToRoot + "/src/level2smashword.txt");
        }

        var filtered = RemovePatternRepeatLetters(possibleWords);
        var letterFeq = wordScoreService.LetterFeq(filtered);
        var overallLetterFeq = OverAllLetterFeq(letterFeq);

        foreach (var word in guessWords
                     .Where(fw => !usedWordsOnly.Contains(fw))
                     .Where(fw => correctWords.All(cp => fw[cp.Item2] != cp.Item1)))
        {
            var overallScore = GetOverallScoreSmashWord2(word, overallLetterFeq, possibleWords.Count());

            result.Add(new Tuple<string, int, int>(word, overallScore, 0));
        }
    }

    private static void GetSmashWordLevel1(IEnumerable<(char, int[])> letterFeq, string[] guessWords,
        IEnumerable<string> usedWordsOnly,
        List<Tuple<char, int>> correctWords, List<Tuple<string, int, int>> result)
    {
        var overallLetterFeq = OverAllLetterFeq(letterFeq);
        foreach (var word in guessWords
                     .Where(fw => !usedWordsOnly.Contains(fw))
                     .Where(fw => correctWords.All(cp => fw[cp.Item2] != cp.Item1)))
        {
            var overallScore = GetOverallScore(word, overallLetterFeq);

            var positionScore = GetPositionalScore(word, letterFeq);

            result.Add(new Tuple<string, int, int>(word, overallScore, positionScore));
        }
    }

    private static IEnumerable<string> RemovePatternRepeatLetters(IEnumerable<string> possibleWords)
    {
        var mostFeqLetterInList = new List<(char, int)>();

        foreach (var word in possibleWords)
        foreach (var letter in word.Select((c, i) => new { c, i }))
            if (possibleWords.All(w => w[letter.i] == letter.c))
                mostFeqLetterInList.Add((letter.c, letter.i));

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

    private static IEnumerable<string> RemoveRepeatLetters(IEnumerable<string> possibleWords)
    {
        return possibleWords
            .Select(word => word.ToCharArray().Distinct().ToArray())
            .Select(uniqueChar => new string(uniqueChar))
            .ToList();
    }

    private static IEnumerable<Tuple<char, int>> OverAllLetterFeq(
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

    private static int GetPositionalScore(string word, IEnumerable<(char, int[])> letterFeq)
    {
        var positionalScore = 0;
        foreach (var letter in letterFeq)
            for (var i = 0; i < 5; i++)
                if (word[i] == letter.Item1)
                    positionalScore += letter.Item2[i];

        return positionalScore;
    }

    private static int GetOverallScore(string word, IEnumerable<Tuple<char, int>> overallLetterFeq)
    {
        return overallLetterFeq
            .Sum(letter => word
                .Where(t => t == letter.Item1)
                .Sum(t => letter.Item2));
    }

    private static int GetOverallScoreSmashWord2(string word, IEnumerable<Tuple<char, int>> overallLetterFeq,
        int possibleWordCount)
    {
        var overallScore = 0;
        foreach (var letter in overallLetterFeq)
        foreach (var t in word)
        {
            if (t == letter.Item1)
                overallScore += letter.Item2;
            else if (t == letter.Item1 && letter.Item2 > possibleWordCount)
                overallScore = (int)(possibleWordCount * 0.3);
        }

        return overallScore;
    }

    public static int GetOverallScoreSmashWord3(string word, IEnumerable<Tuple<char, int>> overallLetterFeq,
        int possibleWordCount, int totalWordCount)
    {
        var overallScore = 0;
        var theLetterScore = 0.0;
        foreach (var c in word)
        {
            foreach (var letter in overallLetterFeq)
            {
                if (c == letter.Item1)
                {
                    theLetterScore += (double)letter.Item2 / totalWordCount;
                }
            }

            if (theLetterScore >= 0.75 * possibleWordCount)
            {
                theLetterScore = 2;
            }
            else if (theLetterScore >= 0.5 * possibleWordCount && theLetterScore < 0.75 * possibleWordCount)
            {
                theLetterScore = 5;
            }
            else if (theLetterScore >= 0.375 * possibleWordCount && theLetterScore < 0.5 * possibleWordCount)
            {
                theLetterScore = 7;
            }
            else if (theLetterScore >= 0.25 * possibleWordCount && theLetterScore < 0.375 * possibleWordCount)
            {
                theLetterScore = 6;
            }
            else if (theLetterScore > 0 * possibleWordCount && theLetterScore < 0.25 * possibleWordCount)
            {
                theLetterScore = 5;
            }

            overallScore += (int)theLetterScore;
        }

        return overallScore;
    }

    private string GetForceSmashWord(string wordleStagePattern)
    {
        var guessWords = File.ReadAllLines(pathToRoot + "/src/force_smashword.txt");
        foreach (var word in guessWords)
        {
            var reference = word.Split(',');
            if (reference[0] == Regex.Replace(wordleStagePattern, "[~]", string.Empty))
            {
                return reference[1];
            }
        }
        return string.Empty;
    }
}