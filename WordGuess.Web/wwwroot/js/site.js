﻿var baseURl = "https://localhost:7231/WordleWizard";
var guessWordBoxIndex = 1;
var wordGuessRowState = [
    {"row": 1, "state": true},
    {"row": 2, "state": false},
    {"row": 3, "state": false},
    {"row": 4, "state": false},
    {"row": 5, "state": false},
    {"row": 6, "state": false},
];

var wordleWord = {
    PossibleWords: [],
    GuessWord: "",
    Correctness: [],
    Row: 1
}

var gameModal;

function Init() {
    GetStartWord();
    KeyBoardRegister();

    gameModal = new bootstrap.Modal(document.getElementById('exampleModal'), {
        keyboard: false
    });

}

Init();

function GetStartWord() {
    var $wordList = $("#next_word_list");
    $wordList.empty();
    $.ajax({
        type: 'GET',
        url: baseURl + "/GetStartWords",
        dataType: 'json',
        success: function (data) {
            $.each(data.startWords, (key, value) => {
                if (data.bestWord === value) {
                    $wordList.append("<span class=\"word_list_item position-relative\" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value + "<span class='position-absolute top-10 start-70 translate-middle badge sm-badge rounded-pill bg-warning'>*</span> </span>");
                } else {
                    $wordList.append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value + "</span>");
                }
            });
        },
        error: function (ex) {
            var r = jQuery.parseJSON(ex.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
}

$(".dropdown-item").click(function () {
    var rowUpdate = 1;
    var index = 1;
    var value = $(this).attr("data-value");


    if (value == 1) {
        if ($("#word_guess_row_" + rowUpdate).attr("data-rowtext")) {
            var text = $("#word_guess_row_" + rowUpdate).attr("data-rowtext");
            $.each(Array.from(text), function (index, char) {
                UpdateAlphabet(0, char);
            });
            $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
            $.each($("#word_guess_row_" + rowUpdate).children(), function () {
                $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background-color", "rgba(0, 0, 0, 0)");
                $("#guess_word_" + index + "_row_" + rowUpdate).text("");
                wordGuessRowState[index - 1].state = wordGuessRowState[index - 1].row == rowUpdate ? true : false;
                index++;
            });
        }
    } else if (value == 2) {
        $.each($(".word_guess_row"), function () {
            $.each($("#word_guess_row_" + rowUpdate).children(), function () {
                var text = $("#word_guess_row_" + rowUpdate).attr("data-rowtext");
                $.each(Array.from(text.toUpperCase()), function (index, char) {
                    UpdateAlphabet(0, char);
                });
                $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background-color", "rgba(0, 0, 0, 0)");
                $("#guess_word_" + index + "_row_" + rowUpdate).text("");
                wordGuessRowState[index - 1].state = wordGuessRowState[index - 1].row == 1 ? true : false;
                index++;
            });
            $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
            rowUpdate++;
            index = 1;
        })
    }
    GetStartWord();

});

function PopulateCastWord(word) {
    var $wordcast = $("#word_cast-" + guessWordBoxIndex);

    $("#word_cast_wrapper").attr("data-cast-word", word);

    UpdateWordCastWrapper(word, $wordcast);
}

$(".word_box-choice").click(function () {
    isDisabled = $(this).attr("disabled");
    if (!isDisabled) {
        WordInput($(this).data("char"));
    }
});

function WordInput(letter) {
    var $wordcast = $("#word_cast-" + guessWordBoxIndex);
    var wordcast = $("#word_cast_wrapper").attr("data-cast-word");

    wordcast = guessWordBoxIndex < 6 ? wordcast.concat(letter) : wordcast;
    UpdateWordCastWrapper(wordcast, $wordcast);

    $("#word_cast_wrapper").attr("data-cast-word", wordcast);
    guessWordBoxIndex = guessWordBoxIndex < 6 ? guessWordBoxIndex + 1 : 6;
}

function UpdateWordCastWrapper(wordcast, $ctx) {
    var index = 1;
    var characterArray = Array.from(wordcast.toUpperCase());
    characterArray.forEach(char => {
        $("#word_cast-" + index).text(char);
        $("#word_cast_box_id_" + index).attr("data-char", char);
        index++;
    });
}

$(".word_cast_box").click(function () {
    let status = parseInt($(this).attr("data-clickregisted"));
    status = status < 4 ? status + 1 : 0;
    if ($(this).attr("data-char")) {
        UpdateContextBoxColor(status, $(this));
        $(this).attr("data-clickregisted", status.toString());
    }
});

function WordValidation(callback, word) {
    $.ajax({
        type: 'POST',
        url: baseURl + "/WordValidation",
        dataType: 'json',
        data: {"word": word},
        async: false,
        success: callback,
        error: function (ex) {
        }
    });
}

function IsWordHasLengthOfFive(wordcast) {
    return wordcast.length == 5;
}

$("#cast_btn").click(function () {
    var castingWord = $("#word_cast_wrapper").attr("data-cast-word");
    var correctness = $("#word_cast_wrapper").attr("data-correctness");
    console.log("click");
    console.log(correctness);
    
    if (correctness === "GGGGG") {
        gameModal.toggle();
        console.log("yeah");
        return;
    }

    $(".word_list_item").filter(":contains(" + castingWord + ")").remove();

    var validationResult;
    WordValidation((data) => {
        validationResult = data.state;
    }, castingWord);

    if (IsWordHasLengthOfFive(castingWord) && validationResult) {
        CastingNextWord(castingWord);
    }
    ClearWordCastState();
});


function ClearWordCastState() {
    $(".word_cast").text("");
    $(".word_cast_box").attr("data-clickregisted", 0);
    $(".word_cast_box").attr("data-char", '');
    UpdateContextBoxColor(0, $(".word_cast_box"));
    $("#word_cast_wrapper").attr("data-cast-word", "");
    guessWordBoxIndex = 1;
}

function CastingNextWord(castingWord) {
    var index = 1;
    var row = 1;
    var rowIndex = 0;
    var characterArray = Array.from(castingWord.toUpperCase());

    while (wordGuessRowState[rowIndex].state == false) {
        if (row < 6 && rowIndex < 5) {
            row = row + 1;
            rowIndex = rowIndex + 1;
        }
    }
    $("#word_guess_row_" + row).attr("data-rowtext", castingWord);

    var correctness = [];

    characterArray.forEach(char => {
        var boxStatus = parseInt($("#word_cast_box_id_" + index).attr("data-clickregisted"));
        switch (boxStatus) {
            case 1:
                correctness.push('Y');
                break;
            case 2:
                correctness.push('G');
                break;
            case 3:
                correctness.push('B');
                break
            default:
                correctness.push('B');
        }

        $("#guess_word_" + index + "_row_" + row).text(char);
        UpdateContextBoxColor(boxStatus, $("#guess_box_id_" + index + "_row_" + row));
        UpdateAlphabet(boxStatus, char);
        index++;
    });

    wordleWord.GuessWord = $("#word_cast_wrapper").attr("data-cast-word");
    wordleWord.Correctness = correctness;


    var $wordList = $("#next_word_list");
    $wordList.empty();
    ProcessGuessWord((data) => {
        $.each(data.guessWords, (key, value) => {
            if (data.bestWord === value) {
                $wordList.append("<span class=\"word_list_item position-relative\" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value + "<span class='position-absolute top-10 start-70 translate-middle badge sm-badge rounded-pill bg-warning'>*</span> </span>");
            } else {
                $wordList.append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value + "</span>");
            }
        });

        wordleWord.PossibleWords = data.guessWords;
    });

    wordGuessRowState[rowIndex].state = false;
    wordGuessRowState[rowIndex + 1].state = true;
}

function ProcessGuessWord(callback) {
    $.ajax({
        type: 'POST',
        url: baseURl + "/ProcessGuessWord",
        dataType: 'JSON',
        contentType: 'application/x-www-form-urlencoded',
        data: {wordleWord},
        async: false,
        success: callback,
        error: function (ex) {
        }
    });
}

function UpdateContextBoxColor(status, $ctx) {
    switch (status) {
        case 1:
            $ctx.css("background-color", "#ffc107");
            break;
        case 2:
            $ctx.css("background-color", "#198754");
            break;
        case 3:
            $ctx.css("background-color", "#0d6efd");
            break
        default:
            $ctx.css("background-color", "rgba(0, 0, 0, 0)");
    }
}

function UpdateAlphabet(status, char) {
    var $alphabet = $("#alphabet_char_" + char);
    switch (status) {
        case 1:
            $alphabet.css("background-color", "#ffc107");
            break;
        case 2:
            $alphabet.css("background-color", "#198754");
            break;
        case 3:
            $alphabet.attr("disabled", true);
            $alphabet.css("background-color", "#0d6efd");
            break
        default:
            $alphabet.css("background-color", "rgba(0, 0, 0, 0)");
    }
}


function KeyBoardRegister() {
    $("body").keypress(function (e) {
        if ($("#word_cast_wrapper").attr("data-cast-word").length != 5) {
            var char = KeyCodeHandler(e.keyCode);
            console.log(char);
        }
    });
}

    




    

