"use strict";

var moduleCount = 0;
$("#addNewModule").click(addNewModule);

function addNewModule() {
    var module = "<div>" +
        "Назва: <input type='text' name='modules[" + moduleCount + "].Title'/>" +
        "Є лабораторна: <input type='checkbox' value='true' name='modules[" + moduleCount + "].IsLabExists' />" +
        "Є тест:<input type='checkbox' value='true' name='modules[" + moduleCount + "].IsTestExists' />" +
        "</div>";

    $("#modules").append(module);

    moduleCount++;
}