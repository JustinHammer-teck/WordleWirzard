
var baseURl = "https://localhost:7231/WordleWizard";

var guessWordBoxIndex = 1;

var guessWord = {
    "Word" : "CRANE",
    "Status" : [1,2,3,1,2]
}

var wordCast = [
    {"id": 1, "char": '', "status": 0},
    {"id": 2, "char": '', "status": 0},
    {"id": 3, "char": '', "status": 0},
    {"id": 4, "char": '', "status": 0},
    {"id": 5, "char": '', "status": 0},
];

var wordGuessRowState = [
    {"row": 1, "state": true},
    {"row": 2, "state": false},
    {"row": 3, "state": false},
    {"row": 4, "state": false},
    {"row": 5, "state": false},
    {"row": 6, "state": false},
];

var WordGuessStage = [
    {
        "row": 1,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }, {
        "row": 2,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }, {
        "row": 3,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }, {
        "row": 4,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }, {
        "row": 5,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }, {
        "row": 6,
        "word": [
            {"index": 1, "letter": "", "state": 0},
            {"index": 2, "letter": "", "state": 0},
            {"index": 3, "letter": "", "state": 0},
            {"index": 4, "letter": "", "state": 0},
            {"index": 5, "letter": "", "state": 0},
        ],
    }];


function Init() {
    GetStartWord();
    KeyBoardRegister();
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
            $.each(data, (key, value) => {
                $wordList.append("<span class=\"word_list_item\" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value + "</span>");
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
            $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
            $.each($("#word_guess_row_" + rowUpdate).children(), function () {
                $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background-color", "rgba(0, 0, 0, 0)");
                $("#guess_word_" + index + "_row_" + rowUpdate).text("");
                wordGuessRowState[index - 1].state = wordGuessRowState[index - 1].row == 1 ? true : false;
                index++;
            });
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

function WordInput(letter){
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
    var clickRegisted = parseInt($(this).attr("data-clickregisted"));
    clickRegisted = clickRegisted < 4 ? clickRegisted + 1 : 0;
    if ($(this).attr("data-char")) {
        UpdateContextBoxColor(clickRegisted, $(this));
        $(this).attr("data-clickregisted", clickRegisted.toString());
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
    var validationResult;
    
    $(".word_list_item").filter(":contains("+ castingWord +")").remove();
    
    WordValidation((data) => {
        validationResult = data.state;
    }, castingWord);

    if (IsWordHasLengthOfFive(castingWord) && validationResult) {
        CastingNextWord(castingWord);
    }
    ClearWordCastState();
});

function ProcessGuessWord(callback, guessWord){
    $.ajax({
        type: 'POST',
        url: baseURl + "/ProcessGuessWord",
        dataType: 'json',
        data: {"guessWord": guessWord},
        async: false,
        success: callback,
        error: function (ex) {
        }
    });
}

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
    characterArray.forEach(char => {
        var boxStatus = parseInt($("#word_cast_box_id_" + index).attr("data-clickregisted"));
        $("#guess_word_" + index + "_row_" + row).text(char);
        UpdateContextBoxColor(boxStatus, $("#guess_box_id_" + index + "_row_" + row));
        UpdateAlphabet(boxStatus, char);
        index++;
    });
    
    ProcessGuessWord((data) => {
        console.log(data);
    }, guessWord);
    
    wordGuessRowState[rowIndex].state = false;
    wordGuessRowState[rowIndex + 1].state = true;
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

    




    

