function Employee(firstname, lastname, birthyear, department) {
	Person.apply(this, arguments)
	this.department = department;
}

Employee.prototype = Object.create(Person.prototype);
