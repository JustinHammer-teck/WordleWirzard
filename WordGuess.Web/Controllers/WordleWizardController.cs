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
        // var wordleSolver = new WordleSolver(_hostingEnvironment);
        //
        // var wordList = wordleSolver.GetWordList();
        //
        //
        // foreach (var answer in wordList)
        // {
        //     wordleSolver.Handler(answer);
        // }

        return View();
    }
    
    [HttpPost]
    public IActionResult ProcessGuessWord(Guess guessWord)
    {
        // var wordleSolver = new WordleSolver(_hostingEnvironment);
        // var solverResult = wordleSolver.Handler();

        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetStartWords()
    {
        var startwords = System.IO.File.ReadAllText(pathToRoot + "/src/start-word.txt");
        var startwordList = startwords.Split('\n');
        return Json(startwordList);
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

