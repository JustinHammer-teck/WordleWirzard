// var baseURl = "https://localhost:7231/WordleWizard";
var baseURl = window.location.origin + "/WordleWizard";

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
    Row: 1,
    UsedWords: [],
    CorrectnessOfUsedWords:[]
}

function Init() {
    GetStartWord();
    UpdateContextBoxColor(3, $(".word_cast_box"));
    Keyboard();
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
                    $wordList.append("<span class=\"word_list_item position-relative\" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "<span class='position-absolute top-10 start-70 translate-middle badge sm-badge rounded-pill bg-warning'>*</span> </span>");
                } else {
                    $wordList.append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "</span>");
                }
            });
        },
        error: function (ex) {
            console.log("something when wrong");
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
                UpdateAlphabet(3, char);
            });
            $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
            $.each($("#word_guess_row_" + rowUpdate).children(), function () {
                $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background", "rgba(0, 0, 0, 0)");
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
                    UpdateAlphabet(3, char);
                });
                $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background", "rgba(0, 0, 0, 0)");
                $("#guess_word_" + index + "_row_" + rowUpdate).text("");
                wordGuessRowState[index - 1].state = wordGuessRowState[index - 1].row == 1 ? true : false;
                index++;
            });
            $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
            rowUpdate++;
            index = 1;
        })
    }
    wordleWord.PossibleWords = [];
    wordleWord.UsedWords = [];
    wordleWord.CorrectnessOfUsedWords = [];
    wordleWord.Row = 1;
    GetStartWord();

});

function PopulateCastWord(word) {
    $("#word_cast_wrapper").attr("data-cast-word", word);

    UpdateWordCastWrapper(word);
    guessWordBoxIndex = 6;
}

$(".word_box-choice").click(function () {
    isDisabled = $(this).attr("disabled");
    if (!isDisabled) {
        WordInput($(this).data("char"));
    }
});

function WordInput(letter) {
    let wordcast = $("#word_cast_wrapper").attr("data-cast-word");
    wordcast = guessWordBoxIndex < 6 ? wordcast.concat(letter) : wordcast;
    UpdateWordCastWrapper(wordcast);

    $("#word_cast_wrapper").attr("data-cast-word", wordcast);
    guessWordBoxIndex = guessWordBoxIndex < 6 ? guessWordBoxIndex + 1 : 6;
}

function UpdateWordCastWrapper(wordcast) {
    let characterArray = Array.from(wordcast.toUpperCase());
    for (let i = 1; i < 6; i++){
        let castChar = characterArray[i-1] == undefined ? '' : characterArray[i-1];
        if(castChar == ''){
            $("#word_cast_box_id_" + i).attr("data-clickregisted", 3);
            UpdateContextBoxColor(3, $("#word_cast_box_id_" + i)); 
        }
        $("#word_cast-" + i).text(castChar);
        $("#word_cast_box_id_" + i).attr("data-char", castChar);
    }
}

$(".word_cast_box").click(function () {
    let status = parseInt($(this).attr("data-clickregisted"));
    status = status > 1 && status <= 3 ? status - 1 : 3;
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
    let castingWord = $("#word_cast_wrapper").attr("data-cast-word");
    $(".word_list_item").filter(":contains(" + castingWord + ")").remove();

    let validationResult;
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
    $(".word_cast_box").attr("data-clickregisted", 3);
    $(".word_cast_box").attr("data-char", '');
    UpdateContextBoxColor(3, $(".word_cast_box"));
    $("#word_cast_wrapper").attr("data-cast-word", "");
    guessWordBoxIndex = 1;
}

function CastingNextWord(castingWord) {
    wordleWord.UsedWords.push(castingWord)
    let index = 1;
    let row = 1;
    let rowIndex = 0;
    const characterArray = Array.from(castingWord.toUpperCase());

    while (wordGuessRowState[rowIndex].state == false) {
        if (row < 6 && rowIndex < 5) {
            row = row + 1;
            rowIndex = rowIndex + 1;
        }
    }
    $("#word_guess_row_" + row).attr("data-rowtext", castingWord);

    let correctness = [];

    characterArray.forEach(char => {
        let boxStatus = parseInt($("#word_cast_box_id_" + index).attr("data-clickregisted"));
        switch (boxStatus) {
            case 1:
                correctness.push('Y');
                break;
            case 2:
                correctness.push('G');
                break;
            case 3:
                correctness.push('B');
                break;
            default:
                correctness.push('B');
                break;
        }
        
        $("#guess_word_" + index + "_row_" + row).text(char);
        UpdateContextBoxColor(boxStatus, $("#guess_box_id_" + index + "_row_" + row));
        UpdateAlphabet(boxStatus, char);
        index++;
    });
    wordleWord.GuessWord = $("#word_cast_wrapper").attr("data-cast-word");
    wordleWord.Correctness = correctness;
    wordleWord.CorrectnessOfUsedWords.push(correctness.join(""));
    
    ProcessGuessWord();

    wordleWord.Row = wordleWord.Row + 1;
    wordGuessRowState[rowIndex].state = false;
    wordGuessRowState[rowIndex + 1].state = true;
}

function ProcessGuessWord() {
    $("#next_word_list").empty();
    $("#elimination_word").empty();
    $.ajax({
        type: 'POST',
        url: baseURl + "/ProcessGuessWord",
        data: {wordleWord},
        dataType: 'json',
        success: function (data) {
            wordleWord.PossibleWords = data.data.possibleWords;
            $("#elimination_word").append("<span class=\"word_list_item \" data-word=\"" + data.data.eliminationWord + "\" onclick='PopulateCastWord(\"" + data.data.eliminationWord + "\")'>" + data.data.eliminationWord.toUpperCase() + "</span>");
            $.each(data.data.possibleWords, (key, value) => {
                if (data.data.bestWord === value) {
                    $("#next_word_list").append("<span class=\"word_list_item position-relative\" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "<span class='position-absolute top-10 start-70 translate-middle badge sm-badge rounded-pill bg-warning'>*</span> </span>");
                } else {
                    $("#next_word_list").append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "</span>");
                }
            });
        },
        error: function (ex) {
            console.log("Something Happened");
        }
    });
}

function UpdateContextBoxColor(status, $ctx) {
    switch (status) {
        case 1:
            $ctx.css("background", "linear-gradient(179.72deg, #F2C94C 0.24%, #554000 181.83%)");
            break;
        case 2:
            $ctx.css("background", "linear-gradient(179.72deg, #219653 0.24%, #0C2719 181.83%)");
            break;
        case 3:
            $ctx.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
        default:
            $ctx.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
    }
}

function UpdateAlphabet(status, char) {
    var $alphabet = $("#alphabet_char_" + char);
    switch (status) {
        case 1:
            $alphabet.css("background", "linear-gradient(179.72deg, #F2C94C 0.24%, #554000 181.83%)");
            break;
        case 2:
            $alphabet.css("background", "linear-gradient(179.72deg, #219653 0.24%, #0C2719 181.83%)");
            break;
        case 3:
            $alphabet.attr("disabled", true);
            $alphabet.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
        default:
            $alphabet.attr("disabled", true);
            $alphabet.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
    }
}

function isAlphaKey(evt)
{
    evt = (evt) ? evt : event;
    let charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :((evt.which) ? evt.which : 0));
    if(charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122)){return false;}
    return true;
}

function WordDelete(){
    let wordcast = $("#word_cast_wrapper").attr("data-cast-word");
    wordcast = guessWordBoxIndex > 0 ? wordcast.slice(0, -1) : wordcast;
    UpdateWordCastWrapper(wordcast);

    $("#word_cast_wrapper").attr("data-cast-word", wordcast);
    guessWordBoxIndex = guessWordBoxIndex > 1 ? guessWordBoxIndex - 1 : guessWordBoxIndex;
}

function Keyboard(){
    window.addEventListener("keyup", function (event) {
        if (event.defaultPrevented) {
            return; // Do nothing if the event was already processed
        }
        
        if(event.key === "Backspace"){
            WordDelete();
        }
        
        if(isAlphaKey(event) && event.key !== "Backspace"){
            WordInput(event.key);
        }

        // Cancel the default action to avoid it being handled twice
        event.preventDefault();
    }, true);
}

    




    

