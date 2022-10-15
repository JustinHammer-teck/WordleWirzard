using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WordGuess.Web.Models;
using WordGuess.Web.Services;
using WordGuess.Web.ViewModels;

namespace WordGuess.Web.Controllers;

public class WordleWizardController : Controller
{
    private readonly ILogger<WordleWizardController> _logger;

    public WordleWizardController(ILogger<WordleWizardController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var GuessWordRows = new List<GuessWordRow>();

        for (int i = 0; i < 6; i++)
        {
            GuessWordRows.Add(new GuessWordRow());
        }
        
        return View();
    }

    public JsonResult GetWordleWord()
    {
        return Json("sdjf");
    }

    public JsonResult GetNextWord()
    {
        var nextGuessWord = new GuessWordViewModel();
        
        return Json(nextGuessWord);
    }
    
    public IActionResult UpdateGuessWord(GuessWordViewModel guessWordViewModel)
    {
        
        return Ok(new { msg = "Successful" });
    }
    
    public IActionResult UpdateGuessWordRow(IEnumerable<GuessWordRowViewModel> guessWordRowViewModels)
    {
        return Ok(new { msg = "Successful" });
    }


    public IActionResult GetStartWords()
    {
        return Ok();
    }
    
    public IActionResult WordValidation(string word)
    {
        var validation = new ValidationService();

        var validationResult = validation.ValidationWord(word);
        
        return Json(new ValidationModel()
        {
            State = true,
            Message = "Success"
        });
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

