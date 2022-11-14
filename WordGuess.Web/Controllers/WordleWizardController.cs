using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WordGuess.Web.Models;
using WordGuess.Web.Services;
using WordGuess.Web.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WordGuess.Web.Controllers;

public class WordleWizardController : Controller
{
    private readonly ILogger<WordleWizardController> _logger;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string pathToRoot;

    public WordleWizardController(ILogger<WordleWizardController> logger,
        IHostingEnvironment hostingEnvironment)
    {
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
        pathToRoot = Path.Combine(_hostingEnvironment.WebRootPath);
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ProcessGuessWord(WordleWordView wordleWord)
    {
        var correctness = new string(wordleWord.Correctness);
        var wordle = new WordleSolver(_hostingEnvironment);
        var result = wordle.Handle(
            correctness,
            wordleWord.GuessWord.ToLower(),
            wordleWord.PossibleWords,
            wordleWord.Row,
            wordleWord.UsedWords);
        return Ok(new { data = result});
    }

    [HttpGet]
    public IActionResult GetStartWords()
    {
        var startwords = System.IO.File.ReadAllText(pathToRoot + "/src/start_word.txt");
        var startwordList = startwords.Split('\n');
        var wordle = new WordleSolver(_hostingEnvironment);

        return Json(new WordleStartWords()
        {
            StartWords = startwordList,
            BestWord = wordle.BestWord(startwordList, wordle.LetterFeq(startwordList))
        });
    }

    [HttpPost]
    public IActionResult WordValidation(string word)
    {
        var validation = new ValidationService(_hostingEnvironment);

        var validationResult = validation.ValidationWord(word);

        return Json(new ValidationModel()
        {
            State = validationResult,
            Message = "Success"
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}