// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var guessWordBoxIndex = 0;


$(".word_box-choice").click(function () {
    isDisabled = $(this).attr("disabled");
    if (!isDisabled) {
        var $wordcast = $("#word_cast-" + guessWordBoxIndex);
        var wordcast = $("#word_cast_wrapper").attr("data-cast-word");
        
        UpdateWordCastWrapper(wordcast, $wordcast);
        wordcast = guessWordBoxIndex < 5 ? wordcast.concat($(this).data("char")) : wordcast;
        
        $("#word_cast_wrapper").attr("data-cast-word", wordcast);
        guessWordBoxIndex = guessWordBoxIndex < 5 ? guessWordBoxIndex + 1 : 5;
    }
});

function UpdateWordCastWrapper(wordcast, ctx){
    var index = 1;
    var characterArray = Array.from(wordcast.toUpperCase());

    characterArray.forEach(char => {
        ctx.text(char);
        index++;
    });
}

$(".word_cast_box").click(function () {
    guessWordBoxIndex = guessWordBoxIndex > 0 ? guessWordBoxIndex - 1 : 0;

});

$(".delete_btn").click(function () {
    guessWordBoxIndex = guessWordBoxIndex > 0 ? guessWordBoxIndex - 1 : 0;
    var clickRegistedValue = $("#guess_box_id_" + guessWordBoxIndex).attr("data-clickregisted");
    var guessBoxWordText = $("#guess_box_word_id_" + guessWordBoxIndex).text()
    UpdateColor(guessWordBoxIndex, parseInt(clickRegistedValue), guessBoxWordText, true);
    $("#guess_box_word_id_" + guessWordBoxIndex).empty();
    $("#guess_box_id_" + guessWordBoxIndex).attr("data-clickregisted", "0");
});

$(".word_guess_box").click(function () {
    var guessBoxId = $(this).data("guessboxid");
    var guessBoxText = $("#guess_box_word_id_" + guessBoxId).text();
    if (guessBoxText) {
        var clickRegisted = parseInt($(this).attr("data-clickregisted"));
        UpdateColor(guessBoxId, clickRegisted, guessBoxText, false);
    }
});

function IsWordValidation(wordcast) {
    return wordcast.length == 5;
}

$("#cast_btn").click(function () {
    var wordcast = $("#word_cast_wrapper").attr("data-cast-word");
    if (IsWordValidation(wordcast)) {
        CastingNextWord(wordcast);
        return;
    }
    
    console.log("Not Enough Word to Cast");
});

function WordValidation(){
    
    
    return true;
}

function CastingNextWord(wordcast) {
    var index = 1;
    var word_guess_row = [
        {"row_1" : $("#word_guess_row_1").attr("data-rowtext")},
        {"row_2" : $("#word_guess_row_2").attr("data-rowtext")},
        {"row_3" : $("#word_guess_row_3").attr("data-rowtext")},
        {"row_4" : $("#word_guess_row_4").attr("data-rowtext")},
        {"row_5" : $("#word_guess_row_5").attr("data-rowtext")},
        {"row_6" : $("#word_guess_row_6").attr("data-rowtext")},
    ];
    
    $("#word_guess_row_" + index).attr("data-rowtext", wordcast);
    
    var characterArray = Array.from(wordcast.toUpperCase());
    
    characterArray.forEach(char => {
        $("#guess_box_word_id_" + index).text(char);
        index++;
    });

    console.log(word_guess_row);

}

function UpdateColor(guessBoxId, clickRegisted, guessBoxText, isReset) {
    var clickregistedCxt = 0;
    if (!isReset) {
        clickregistedCxt = clickRegisted < 3 ? clickRegisted + 1 : 0;
    }
    var boxCxt = $("#guess_box_id_" + guessBoxId);
    $(".word_guess_box").attr("data-clickregisted", clickregistedCxt.toString());
    var alphabetChar = $("#alphabet_char_" + guessBoxText);
    switch (clickregistedCxt) {
        case 1:
            boxCxt.css("background-color", "orange");
            UpdateAlphabetRow(guessBoxText, 1, alphabetChar)
            break;
        case 2:
            boxCxt.css("background-color", "green");
            UpdateAlphabetRow(guessBoxText, 2, alphabetChar)
            break;
        case 3:
            boxCxt.css("background-color", "blue");
            UpdateAlphabetRow(guessBoxText, 3, alphabetChar)
            break
        default:
            UpdateAlphabetRow(guessBoxText, 0, alphabetChar)
            boxCxt.css("background-color", "white");
    }
}

function UpdateAlphabetRow(text, status, cxt) {
    switch (status) {
        case 1:
            cxt.css("background-color", "orange");
            break;
        case 2:
            cxt.css("background-color", "green");
            break;
        case 3:
            cxt.attr("disabled", true);
            cxt.css("background-color", "blue");
            break
        default:
            cxt.css("background-color", "white");
    }
}

    




    

