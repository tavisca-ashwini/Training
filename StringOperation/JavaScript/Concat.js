String.prototype.Concat = function (stringTwo) {
    var stringOne = this;
    var stringResult = stringOne;
    for (i = 0; i < stringTwo.length; i++) {
        stringResult += stringTwo.charAt(i);
    }
    return stringResult;
};