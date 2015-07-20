String.prototype.SubString = function (startIndex, endIndex) {
    var string = this;
    if (startIndex >= string.length || startIndex < 0) {
        throw new TypeError;
        return;
    }
    if (endIndex >= string.length || endIndex < startIndex) {
        throw new TypeError;
        return;
    }
    var result = "";
    for (i = startIndex; i < endIndex; i++) {

        result += string.charAt(i);
    }
    return result;
};