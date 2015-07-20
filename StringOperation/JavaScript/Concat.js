String.prototype.Concat = function () {
    var stringOne = this;
    var stringResult = stringOne;
    for (i = 0; i < arguments; i++) {
		for(j=0;j<arguments[i].length;j++)
		{
			stringResult += arguments[i].charAt(j);
		}
    }
    return stringResult;
};