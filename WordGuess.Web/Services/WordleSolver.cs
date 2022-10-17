using WordGuess.Web.Enums;
using WordGuess.Web.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WordGuess.Web.Services;

public class WordleSolver
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string pathToRoot;
    private Wordle Wordle;

    public WordleSolver(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        pathToRoot = Path.Combine(_hostingEnvironment.WebRootPath);

        var words = File.ReadAllText(pathToRoot + "/src/dictionary.txt");

        Wordle.Dictionary = words
            .Split("\n")
            .Select(x => x.Split(" "))
            .ToDictionary(x => x[0], x => x[1]);
        
    }

    
    public string[] GetWordList()
    {
        var words = File.ReadAllText(pathToRoot + "/src/wordle-word.txt");
        var wordList = words.Split('\n');
        return wordList;
    }

    private Correctness[] CheckCorrectness(string answer, string guess)
    {
        var correctness = new Correctness[5]
        {
            Correctness.Disable , 
            Correctness.Disable ,
            Correctness.Disable ,
            Correctness.Disable ,
            Correctness.Disable 
        };
        
        var used = new bool[5];
        for (int i = 0; i < correctness.Length; i++)
        {
            if (correctness[i] == Correctness.CorrectPlacement)
            {
                used[i] = true;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (answer[i] == guess[i])
            {
                correctness[i] = Correctness.CorrectPlacement;
            }
        }

        for (int i = 0; i < guess.Length ; i++)
        {
            if (correctness[i] == Correctness.CorrectPlacement)
            {
                continue;
            }

            var check = answer.ToCharArray().Any(x =>
            {
                if (x == guess[i] && !used[i])
                {
                    used[i] = true;
                    return true;
                }
                return false;
            });

            if (check)
            {
                correctness[i] = Correctness.WrongPlacement;
            }

            
        }
        return correctness;
    }
    
    public int Handler(string answer)
    {
        var history = new List<Guess>();
        var guessWord = new Guesser();

        for (int i = 1; i < 32; i++)
        {
            var guess= guessWord.Guess(history);
            if (guess == answer)
            {
                return i;
            }
            var correctness = CheckCorrectness(answer, guess);
            
            history.Add(new Guess()
            {
                Word = guess,
                Status = correctness
            });
        }

        throw new Exception("Something Wrong");
    }
}