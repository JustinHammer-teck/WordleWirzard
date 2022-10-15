// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var guessWordBoxIndex = 1;

var wordCast = [
    {"id" : 1 , "char" : '' , "status" : 0},
    {"id" : 2 , "char" : '' , "status" : 0},
    {"id" : 3 , "char" : '' , "status" : 0},
    {"id" : 4 , "char" : '' , "status" : 0},
    {"id" : 5 , "char" : '' , "status" : 0},
];

var wordGuessRowState = [
    {"row" : 1, "state" : true},
    {"row" : 2, "state" : false},
    {"row" : 3, "state" : false},
    {"row" : 4, "state" : false},
    {"row" : 5, "state" : false},
    {"row" : 6, "state" : false},
];

$(".word_box-choice").click(function () {
    isDisabled = $(this).attr("disabled");
    if (!isDisabled) {
        var $wordcast = $("#word_cast-" + guessWordBoxIndex);
        var wordcast = $("#word_cast_wrapper").attr("data-cast-word");
        
        wordcast = guessWordBoxIndex < 6 ? wordcast.concat($(this).data("char")) : wordcast;
        UpdateWordCastWrapper(wordcast, $wordcast);

        $("#word_cast_wrapper").attr("data-cast-word", wordcast);
        guessWordBoxIndex = guessWordBoxIndex < 6 ? guessWordBoxIndex + 1 : 6;
    }
});

$(".word_cast_box").click(function () {
    var clickRegisted = parseInt($(this).attr("data-clickregisted"));
    clickRegisted = clickRegisted < 4 ?  clickRegisted + 1 : 0;
    if($(this).attr("data-char")){
        UpdateContextBoxColor(clickRegisted, $(this));
    }
    $(this).attr("data-clickregisted", clickRegisted.toString());
});

function UpdateWordCastWrapper(wordcast, $ctx){
    var index = 1;
    var characterArray = Array.from(wordcast.toUpperCase());

    characterArray.forEach(char => {
        $ctx.text(char);
        $("#word_cast_box_id_" + index).attr("data-char", char);
        index++;
    });
}

function WordValidation(word){
    return true;
}

function IsWordHasLengthOfFive(wordcast) {
    return wordcast.length == 5;
}

$("#cast_btn").click(function () {
    var castingWord = $("#word_cast_wrapper").attr("data-cast-word");
    if (IsWordHasLengthOfFive(castingWord) && WordValidation(castingWord)) {
        CastingNextWord(castingWord);
        ClearState();
    }
});

function ClearState(){
    $(".word_cast").text("");
    $(".word_cast_box").attr("data-clickregisted" , 0);
    UpdateContextBoxColor(0 , $(".word_cast_box"));
    $("#word_cast_wrapper").attr("data-cast-word", "");
    guessWordBoxIndex = 1;
}

function CheckForDuplication(){
    
}

function CastingNextWord(castingWord) {
    var index = 1;
    var row = 1;
    var rowIndex = 0;
    var characterArray = Array.from(castingWord.toUpperCase());
    
    while (wordGuessRowState[rowIndex].state == false){
        if( row < 6 && rowIndex < 5){
            row = row + 1;
            rowIndex = rowIndex + 1;
        }
    }
    $("#word_guess_row_" + row).attr("data-rowtext", castingWord);
    characterArray.forEach(char => {
        var boxStatus = parseInt($("#word_cast_box_id_" + index).attr("data-clickregisted"));
        $("#guess_word_" + index + "_row_" + row).text(char);
        UpdateContextBoxColor(boxStatus, $("#guess_box_id_" + index + "_row_" + row));
        UpdateAlphabet(boxStatus, char);
        index++;
    });
    wordGuessRowState[rowIndex].state = false;
    wordGuessRowState[rowIndex + 1].state = true;
}

function UpdateContextBoxColor(status, $ctx) {
    switch (status) {
        case 1:
            $ctx.css("background-color", "orange");
            break;
        case 2:
            $ctx.css("background-color", "green");
            break;
        case 3:
            $ctx.css("background-color", "blue");
            break
        default:
            $ctx.css("background-color", "white");
    }
}

function UpdateAlphabet(status, char) {
    var $alphabet = $("#alphabet_char_" + char);
    switch (status) {
        case 1:
            $alphabet.css("background-color", "orange");
            break;
        case 2:
            $alphabet.css("background-color", "green");
            break;
        case 3:
            $alphabet.attr("disabled", true);
            $alphabet.css("background-color", "blue");
            break
        default:
            $alphabet.css("background-color", "white");
    }
}

    




    

