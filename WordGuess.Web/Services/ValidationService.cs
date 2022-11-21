using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WordGuess.Web.Services;

public class ValidationService
{    
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string pathToRoot;

    public ValidationService(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        pathToRoot = Path.Combine(_hostingEnvironment.WebRootPath);
    }

    public bool ValidationWord(string word)
    {
        var allowedWordsFile = File.ReadLines(pathToRoot + "/src/word_guess.txt");
        return allowedWordsFile.Contains(word.ToLower());
    }
}