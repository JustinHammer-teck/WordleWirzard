﻿let baseURl = window.location.origin + "/WordleWizard";

let guessWordBoxIndex = 1;
let wordGuessRowState = [
    {"row": 1, "state": true},
    {"row": 2, "state": false},
    {"row": 3, "state": false},
    {"row": 4, "state": false},
    {"row": 5, "state": false},
    {"row": 6, "state": false},
];

let wordleWord = {
    PossibleWords: [],
    GuessWord: "",
    Correctness: [],
    Row: 1,
    UsedWords: [],
    WordleStagePattern: ""
}

function Init() {
    GetStartWord();
    UpdateContextBoxColor(3, $(".word_cast_box"));
    Keyboard();
    localStorage.clear();
}

Init();

function GetStartWord() {
    let $wordList = $("#next_word_list");
    $wordList.empty();
    $.ajax({
        type: 'GET',
        url: baseURl + "/GetStartWords",
        dataType: 'json',
        success: function (data) {
            $.each(data.startWords, (key, value) => {
                $wordList.append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "</span>");
            });
        },
        error: function (ex) {
            console.log("something when wrong");
        }
    });
}

function ClearAll() {
    let rowUpdate = 1;
    let index = 1;

    $.each($(".word_guess_row"), function () {
        $.each($("#word_guess_row_" + rowUpdate).children(), function () {
            $("#guess_box_id_" + index + "_row_" + rowUpdate).css("background", "rgba(0, 0, 0, 0)");
            $("#guess_word_" + index + "_row_" + rowUpdate).text("");
            wordGuessRowState[index - 1].state = wordGuessRowState[index - 1].row == 1 ? true : false;
            index++;
        });
        $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
        rowUpdate++;
        index = 1;
    });

    localStorage.clear();
}

function ClearLastRow() {
    let rowUpdate = wordGuessRowState.find(x => x.state).row - 1;
    let row = wordleWord.Row == 0 ? "" : wordleWord.Row - 1;
    let lastPossibleWord = localStorage.getItem("lastPossibleWord" + row);
    
    wordleWord.PossibleWords = lastPossibleWord.split(",");
    wordleWord.UsedWords.pop();
    wordleWord.Row = wordleWord.Row - 1;
    wordleWord.Correctness = [];

    let $wordList = $("#next_word_list");
    $wordList.empty();
    
    if (lastPossibleWord == "") {
        GetStartWord();
    } else {

        $.each(lastPossibleWord.split(","), (key, value) => {
            $wordList.append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "</span>");
        });
    }

    let lastEliminationWord = localStorage.getItem("lastEliminationWord" + row);
    $("#elimination_word").empty();

    if (lastEliminationWord != "") {
        $("#elimination_word").append("<span class=\"word_list_item \" data-word=\"" + lastEliminationWord + "\" onclick='PopulateCastWord(\"" + lastEliminationWord + "\")'>" + lastEliminationWord.toUpperCase() + "</span>");
    }
    if ($("#word_guess_row_" + rowUpdate).attr("data-rowtext")) {
        let text = $("#word_guess_row_" + rowUpdate).attr("data-rowtext");
        $.each(Array.from(text), function (index, char) {
            UpdateAlphabet(3, char);
        });
        $("#word_guess_row_" + rowUpdate).attr("data-rowtext", "");
        for (let i = 1; i < 6; i++) {
            $("#guess_box_id_" + i + "_row_" + rowUpdate).css("background", "rgba(0, 0, 0, 0)");
            $("#guess_word_" + i + "_row_" + rowUpdate).text("");
            wordGuessRowState[i - 1].state = wordGuessRowState[i - 1].row == wordleWord.Row;
        }
    }
    localStorage.removeItem("lastPossibleWord" + row);
    localStorage.removeItem("lastEliminationWord" + row);

    ClearWordCastState();
    ReRenderAlphaChoice(wordleWord.Row);
}

function ReRenderAlphaChoice(row) {
    $(".word_box-choice").attr("disabled", false);
    $(".word_box-choice").css("background", "");
    let lastAlphabetStatus = localStorage.getItem("lastAlphabetStatus" + row);
    lastAlphabetStatus.split('-').forEach((value, index) => {
        UpdateAlphabet(parseInt(value[1]), value[0]);
    });
    localStorage.removeItem("lastAlphabetStatus" + row);
}

$(".clear-row").click(function () {
    let value = $(this).attr("data-value");
    if (wordleWord.Row == 1) return;
    if (value == 1) {
        ClearLastRow();
    } else if (value == 2) {
        ClearAll();
        ClearStage();
        GetStartWord();
        localStorage.clear();
    }
});

function ClearStage() {
    ClearWordCastState();
    $("#elimination_word").empty();
    wordleWord.PossibleWords = [];
    wordleWord.UsedWords = [];
    wordleWord.Row = 1;
    $(".word_box-choice").attr("disabled", false);
    $(".word_box-choice").css("background", "");
}

function PopulateCastWord(word) {
    ClearWordCastState();
    $("#word_cast_wrapper").attr("data-cast-word", word);
    UpdateWordCastWrapper(word);
    guessWordBoxIndex = 6;
}

$(".word_box-choice").click(function () {
    const isDisabled = $(this).attr("disabled");
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
    for (let i = 1; i < 6; i++) {
        let castChar = characterArray[i - 1] == undefined ? '' : characterArray[i - 1];
        if (castChar == '') {
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
    let index = 1;
    let row = 1;
    let rowIndex = 0;
    const characterArray = Array.from(castingWord.toUpperCase());

    while (!wordGuessRowState[rowIndex].state) {
        if (row < 6 && rowIndex < 5) {
            row = row + 1;
            rowIndex = rowIndex + 1;
        }
    }
    $("#word_guess_row_" + row).attr("data-rowtext", castingWord);

    let correctness = [];
    let lastAlphabetStatus = localStorage.getItem("lastAlphabetStatus" + wordleWord.Row) == null
        ? ""
        : localStorage.getItem("lastAlphabetStatus" + wordleWord.Row);
    characterArray.forEach((char, idx) => {
        lastAlphabetStatus += "-";
        lastAlphabetStatus += char;
        let boxStatus = parseInt($("#word_cast_box_id_" + index).attr("data-clickregisted"));
        switch (boxStatus) {
            case 1:
                correctness.push('Y');
                lastAlphabetStatus += "1";
                break;
            case 2:
                correctness.push('G');
                lastAlphabetStatus += "2";
                break;
            case 3:
            case 0:
                correctness.push('B');
                lastAlphabetStatus += "3";
                break;
        }
        $("#guess_word_" + index + "_row_" + row).text(char);
        UpdateContextBoxColor(boxStatus, $("#guess_box_id_" + index + "_row_" + row));
        UpdateAlphabet(boxStatus, char);
        index++;
    });
    localStorage.setItem("lastPossibleWord" + wordleWord.Row, wordleWord.PossibleWords);
    let eliminationWord = $("#elimination_word").find('span').attr("data-word");
    localStorage.setItem("lastEliminationWord" + wordleWord.Row, eliminationWord == undefined ? "" : eliminationWord);

    wordleWord.GuessWord = $("#word_cast_wrapper").attr("data-cast-word");
    wordleWord.Correctness = correctness;
    wordleWord.UsedWords.push({
        Word: castingWord,
        Correctness: correctness.join("")
    })

    wordleWord.WordleStagePattern = SetStagePattern();
    ProcessGuessWord();
    wordleWord.Row = wordleWord.Row + 1;
    localStorage.setItem("lastAlphabetStatus" + wordleWord.Row, lastAlphabetStatus);
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
        async: false,
        success: function (data) {
            wordleWord.PossibleWords = data.data.possibleWords;
            $("#elimination_word").append("<span class=\"word_list_item \" data-word=\"" + data.data.eliminationWord + "\" onclick='PopulateCastWord(\"" + data.data.eliminationWord + "\")'>" + data.data.eliminationWord.toUpperCase() + "</span>");
            $.each(data.data.possibleWords, (key, value) => {
                $("#next_word_list").append("<span class=\"word_list_item \" data-word=\"" + value + "\" onclick='PopulateCastWord(\"" + value + "\")'>" + value.toUpperCase() + "</span>");
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
        case 0 :
            $ctx.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
    }
}

function UpdateAlphabet(status, char) {
    let $alphabet = $("#alphabet_char_" + char);
    switch (status) {
        case 1:
            $alphabet.css("background", "linear-gradient(179.72deg, #F2C94C 0.24%, #554000 181.83%)");
            break;
        case 2:
            $alphabet.css("background", "linear-gradient(179.72deg, #219653 0.24%, #0C2719 181.83%)");
            break;
        case 3 :
        case 0 :
            $alphabet.attr("disabled", true);
            $alphabet.css("background", "linear-gradient(179.72deg, #497AC4 0.24%, #000000 154.4%)");
            break;
    }
}

function isAlphaKey(evt) {
    evt = (evt) ? evt : event;
    let charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
    return charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122);
}

function WordDelete() {
    let wordcast = $("#word_cast_wrapper").attr("data-cast-word");
    wordcast = guessWordBoxIndex > 0 ? wordcast.slice(0, -1) : wordcast;
    UpdateWordCastWrapper(wordcast);
    $("#word_cast_wrapper").attr("data-cast-word", wordcast);
    guessWordBoxIndex = guessWordBoxIndex > 1 ? guessWordBoxIndex - 1 : guessWordBoxIndex;
}

function Keyboard() {
    //BUG: keyboard auto type in not alphabet letter
    window.addEventListener("keyup", function (event) {
        if (event.defaultPrevented) {
            return; // Do nothing if the event was already processed
        } else if (event.key === "Backspace") {
            WordDelete();
        } else if (isAlphaKey(event) && event.code !== "Tab" && event.code !== "Escape" && event.code !== "Capslock" && event.code !== "Shift" && event.code !== "Ctrl") {
            WordInput(event.key);
        }

        // Cancel the default action to avoid it being handled twice
        event.preventDefault();
    }, true);
}

function SetStagePattern() {
    let result = [];
    let correctplc = ["~", "~", "~", "~", "~"];
    let wrongplc = ["~", "~", "~", "~", "~"];
    if (wordleWord.UsedWords !== null) {
        wordleWord.UsedWords.forEach((item, index) => {
            for (let i = 0; i < 5; i++) {
                if (item.Correctness[i] == 'B') {
                    result.push(item.Word[i]);
                } else if (item.Correctness[i] == 'Y') {
                    wrongplc[i] += item.Word[i];
                } else if (item.Correctness[i] == 'G') {
                    correctplc[i] += item.Word[i];
                }
            }
        });
    }
    result.unshift(correctplc.join("-") + "-");
    result.unshift(wrongplc.join("*") + "*");
    return result.join("").toUpperCase();
}
 
    




    

