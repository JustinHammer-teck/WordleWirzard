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

    public WordleWords Handle(string correctness, string guess, string[] possibleWords, int row)
    {
        var result = new WordleWords();
        if (row == 1)
        {
            possibleWords = File.ReadAllLines(pathToRoot + "/src/word_answer.txt");
        }
        else if (possibleWords.Any() && row > 1)
        {
            throw new Exception("No Words to Process");
        }

        var guessWordsRef = WordRemover(correctness, guess, possibleWords);

        result.GuessWords = guessWordsRef;
        result.BestWord = BestWord(guessWordsRef, LetterFeq(guessWordsRef));
        result.EliminationWord = GetEliminationWord(guessWordsRef);
        return result;
    }


    private string[] WordRemover(string result, string guess, string[] possibleWords)
    {
        var wordleHelper = new WordPlacementHelper();
        var badLetter = wordleHelper.BadLetter(result, guess);
        var wrongPlacement = wordleHelper.WrongPlacement(result, guess);
        var correctPlacement = wordleHelper.CorrectPlacement(result, guess);
        var goodLetter = new char[10] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        for (var i = 0; i < correctPlacement.Length; i++)
        {
            goodLetter[i] = correctPlacement[i].Item1;
        }

        for (var i = 5; i <= 9; i++)
        {
            goodLetter[i] = wrongPlacement[i - 5].Item1;
        }

        var acceptableWord1 = new List<string>();
        foreach (var word in possibleWords)
        {
            var check = false;

            foreach (var c in badLetter)
            {
                if (word.Contains(c))
                {
                    if (goodLetter.Contains(c))
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                        break;
                    }
                }
            }

            if (check == false)
            {
                acceptableWord1.Add(word);
            }
        }

        var acceptableWord2 = new List<string>();
        foreach (var word in acceptableWord1.Distinct())
        {
            var check = false;

            for (var i = 0; i < correctPlacement.Length; i++)
            {
                if (correctPlacement[i].Item1 == '\0') continue;
                if (word[correctPlacement[i].Item2] != correctPlacement[i].Item1)
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                acceptableWord2.Add(word);
            }
        }

        var acceptableWord3 = new List<string>();
        foreach (var word in acceptableWord2.Distinct())
        {
            var check = false;

            for (var i = 0; i < wrongPlacement.Length; i++)
            {
                if (wrongPlacement[i].Item1 == '\0') continue;
                if (word[wrongPlacement[i].Item2] == wrongPlacement[i].Item1)
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                acceptableWord3.Add(word);
            }
        }


        var acceptableWord4 = new List<string>();
        foreach (var word in acceptableWord3.Distinct())
        {
            var check = false;

            for (var i = 0; i < goodLetter.Length; i++)
            {
                if (goodLetter[i] == '\0') continue;
                if (!word.Contains(goodLetter[i]))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                acceptableWord4.Add(word);
            }
        }

        var acceptableWord5 = new List<string>();
        foreach (var word in acceptableWord4)
        {
            var check = false;
            foreach (var t in badLetter)
            {
                if (t == '\0') continue;
                if (goodLetter.Contains(t))
                {
                    if (acceptableWord4.Count(x => x.Contains(t)) !=
                        goodLetter.Count(x => x == t))
                    {
                        check = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (check == false)
            {
                acceptableWord5.Add(word);
            }
        }

        return acceptableWord5.Distinct().ToArray();
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

    private string GetEliminationWord(string[] possibleWords)
    {
        return "";
    }
}