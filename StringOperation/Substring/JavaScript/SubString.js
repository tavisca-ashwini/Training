﻿String.prototype.SubString = function (startIndex, endIndex) {
    var string = this;
    if (startIndex >= string.length || startIndex < 0) {
        alert('Entered Start Index is Invalid');
        return;
    }
    if (endIndex >= string.length || endIndex < startIndex) {
        alert('Entered End Index is Invalid');
        return;
    }
    var result = "";
    for (i = startIndex; i < endIndex; i++) {

        result += string.charAt(i);
    }
    return result;
};