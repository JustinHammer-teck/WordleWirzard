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

    public WordleWords Handle(string correctness, string guess, IEnumerable<string> possibleWords, int row, string[] usedWords, string[] correctnessOfUsedWords)
    {
        var result = new WordleWords();
        if (row == 1)
        {
            possibleWords = File.ReadAllLines(pathToRoot + "/src/word_guess.txt");
        }
        else if (!possibleWords.Any() && row > 1)
        {
            throw new Exception("No Words to Process");
        }

        var guessWordsRef = WordRemover(correctness, guess, possibleWords);

        result.BestWord = BestWord(guessWordsRef, LetterFeq(guessWordsRef));
        result.PossibleWords = guessWordsRef
            .OrderByDescending(x => x == result.BestWord)
            .ThenBy(i => i)
            .ToList();
        result.EliminationWord = GetEliminationWord(usedWords, correctnessOfUsedWords).First();
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
        
        return  acceptableWord4
            .Where(word => 
                badLetter
                    .Where(x => goodLetter.Contains(x) && word != guess)
                    .All(t => word.Count(x => x == t) == goodLetter.Count(x => x == t)))
            .ToArray();

    }

    private (string, double)[] WordScore(string[] possibleWord, (char, int[])[] letterFeq)
    {
        var words = new (string, double)[possibleWord.Length];
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

        var increment = 0;
        foreach (var word in possibleWord)
        {
            var worRef = word.ToLower();
            double score = 1;
            for (int i = 0; i < 5; i++)
            {
                var letter = worRef[i];
                var index = letterFeq
                    .ToList()
                    .Find(x => x.Item1 == letter);
                score *= 1 + Math.Pow((index.Item2[i] - maxFeq[i]), 2);
            }

            words[increment] = (word, score);
            increment++;
        }

        return words;
    }

    public string BestWord(string[] possibleWord, (char, int[])[] letterFeq)
    {
        double maxScore = 100000000000000000;
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

    public (char, int[])[] LetterFeq(string[] possibleWords)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var letterfeq = new (char, int[])[alphabet.Length];
        var index = 0;
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

            letterfeq[index] = (c, feq);
            index++;
        }

        return letterfeq;
    }

    public IEnumerable<string> GetEliminationWord(string[] usedWords, string[] correctnessOfUsedWords)
    {
        var allWordList = File.ReadAllLines(pathToRoot + "/src/word_answer.txt");
        var correctletters = new List<char>();
        var goodletters = new List<char>();

        for (var i = 0; i < usedWords.Length; i++)
        {
            for (var j = 0; j < usedWords[i].Length; j++)
            {
                if (correctnessOfUsedWords[i][j] == 'G')
                {
                    correctletters.Add(usedWords[i][j]);
                }
                
                if (correctnessOfUsedWords[i][j] == 'Y')
                {
                    correctletters.Add(usedWords[i][j]);
                }
            }
        }
        
        //Get Words Where there are no duplication letter in string
        var possibleWordRef = allWordList
            .Where(word => !usedWords.Contains(word))
            .Where(word => !word.Any(correctletters.Contains))
            .Where(word => !word.Any(goodletters.Contains));

        return possibleWordRef;
    }
}