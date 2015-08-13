function Person(firstname, lastname, birthyear) {
	this.firstname = firstname;
	this.lastname = lastname;
	this.birthyear = birthyear;

}

Person.prototype.getAge = function () {
	return 2015 - this.birthyear;
};

Person.prototype.toString = function () {
	return this.firstname + ' ' + this.lastname;
};
