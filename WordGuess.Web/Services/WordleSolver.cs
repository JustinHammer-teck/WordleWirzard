using WordGuess.Web.Exceptions;
using WordGuess.Web.Helper;
using WordGuess.Web.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WordGuess.Web.Services;

public class WordleSolver
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string pathToRoot;

    public WordleSolver(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        pathToRoot = Path.Combine(_hostingEnvironment.WebRootPath);
    }

    public WordleWords Handle(string correctness, string guess, IEnumerable<string> possibleWords, int row, IEnumerable<UsedWord> usedWords)
    {
        var eliminationWordService = new EliminationWordService(_hostingEnvironment);
        if (row == 1)
        {
            possibleWords = File.ReadAllLines(pathToRoot + "/src/word_answer.txt");
        }
        else if (!possibleWords.Any() && row > 1)
        {
            throw new WordleWordsException("No Words to Process");
        }

        var guessWordsRef = WordRemover(correctness, guess, possibleWords);
        var eliminationWords = eliminationWordService.GetEliminationWord(
            usedWords,
            guessWordsRef, 
            LetterFeq(guessWordsRef));
        
        var result = new WordleWords()
        {
            BestWord = BestWord(guessWordsRef, LetterFeq(guessWordsRef)),
            PossibleWords = WordScore(guessWordsRef, LetterFeq(guessWordsRef))
                .OrderBy(x => x.Item2)
                .Select(x => x.Item1)
                .ToList(),
            EliminationWord = eliminationWords
                .Select(x => x.Item1)
                .FirstOrDefault("")
        };
        return result;
    }

    private string[] WordRemover(string result, string guess, IEnumerable<string> possibleWords)
    {
        var wordleHelper = new WordPlacementHelper();
        var badLetter = wordleHelper.BadLetter(result, guess);
        var wrongPlacement = wordleHelper.WrongPlacement(result, guess);
        var correctPlacement = wordleHelper.CorrectPlacement(result, guess);
        var goodLetter = wrongPlacement
            .Concat(correctPlacement)
            .Select(x => x.Item1)
            .ToList();

        //Filter words does not contains any bad letter and good letter does not contain any bad letter
        var acceptableWord1 = possibleWords
            .Where(word => word != guess)
            .Where(word => !badLetter.Any(c => word.Contains(c) && !goodLetter.Contains(c)))
            .ToList();

        //Filter words contain correct placement letter at the same index Or contain wrong placement letter but not at the same index
        var acceptableWord2 = acceptableWord1
            .Where(fw => correctPlacement.All(cp => fw[cp.Item2] == cp.Item1))
            .ToList();

        //Filter words contain wrong placement letter but not at the same index
        var acceptableWord3 = acceptableWord2
            .Where(words => wrongPlacement.All(wp => words[wp.Item2] != wp.Item1))
            .ToList();

        var acceptableWord4 = acceptableWord3
            .Where(fw => goodLetter.All(fw.Contains))
            .ToList();

        return acceptableWord4
            .Where(word =>
                badLetter
                    .Where(x => goodLetter.Contains(x))
                    .All(t => word.Count(x => x == t) == goodLetter.Count(x => x == t)))
            .ToArray();
    }

    private IEnumerable<(string, double)> WordScore(IEnumerable<string> possibleWord,
        IEnumerable<(char, int[])> letterFeq)
    {
        var wordValue = new List<(string, double)>();
        int[] maxFeq = { 0, 0, 0, 0, 0 };
        foreach (var c in letterFeq)
        {
            for (int i = 0; i < 5; i++)
            {
                if (maxFeq[i] < c.Item2[i])
                {
                    maxFeq[i] = c.Item2[i];
                }
            }
        }

        foreach (var word in possibleWord)
        {
            var worRef = word.ToLower();
            double score = 1;
            for (var i = 0; i < 5; i++)
            {
                var letter = worRef[i];
                var index = letterFeq
                    .ToList()
                    .Find(x => x.Item1 == letter);
                score *= 1 + Math.Pow((index.Item2[i] - maxFeq[i]), 2);
            }

            wordValue.Add((word, score));
        }

        return wordValue;
    }

    public string BestWord(string[] possibleWord, IEnumerable<(char, int[])> letterFeq)
    {
        double maxScore = 9999999999999999999;
        var result = "";
        var score = WordScore(possibleWord, letterFeq);

        foreach (var word in possibleWord)
        {
            var index = score.ToList().Find(x => x.Item1 == word);
            if (index.Item2 < maxScore)
            {
                maxScore = index.Item2;
                result = word;
            }
        }

        return result;
    }

    public IEnumerable<(char, int[])> LetterFeq(IEnumerable<string> possibleWords)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var letterfeq = new List<(char, int[])>();
        foreach (var c in alphabet)
        {
            int[] feq = { 0, 0, 0, 0, 0 };
            for (int i = 0; i < 5; i++)
            {
                foreach (var word in possibleWords)
                {
                    if (word[i] == c)
                    {
                        feq[i] += 1;
                    }
                }
            }

            letterfeq.Add((c, feq));
        }

        return letterfeq;
    }
}