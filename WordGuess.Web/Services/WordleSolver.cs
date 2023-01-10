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
        var wordScoringService = new WordScoringService();
        if (row == 1)
        {
            possibleWords = File.ReadAllLines(pathToRoot + "/src/word_answer.txt");
        }
        else if (!possibleWords.Any() && row > 1)
        {
            throw new WordleWordsException();
        }
        else if (row > 6)
        {
            throw new ExceededRowNumberException();
        }

        var guessWordsRef = WordRemover(correctness, guess, possibleWords);
        var letterFeq = wordScoringService.LetterFeq(guessWordsRef);
        var eliminationWords = eliminationWordService.GetEliminationWord(
            usedWords,
            guessWordsRef, 
            letterFeq);
        
        var result = new WordleWords()
        {
            BestWord = wordScoringService.BestWord(guessWordsRef, letterFeq),
            PossibleWords = wordScoringService.WordScore(guessWordsRef, letterFeq)
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
}