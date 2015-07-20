String.prototype.Concat = function () {
    var stringOne = this;
    for (i = 0; i < arguments.length; i++) {
        if(arguments[i] == "null")
            stringOne += "null";
        if(arguments[i] =="undefined")
            stringOne +="undefined";
        stringOne += arguments[i];
    }
    return stringOne;
};