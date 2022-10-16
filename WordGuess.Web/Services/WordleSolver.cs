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

    private Dictionary<string, double> WordFrequency;

    // private Dictionary<string, float> GetWordFrequency()
    // {
    //     var words = File.ReadAllText(pathToRoot + "/src/wordle_words_freqs_full.txt");
    //     
    // }
    private string[] GetWordList()
    {
        var words = File.ReadAllText(pathToRoot + "/src/wordle-word.txt");
        var wordList = words.Split('\n');
        return wordList;
    }
    
    public string[] Handler(string word)
    {
        return GetWordList();
    }
}