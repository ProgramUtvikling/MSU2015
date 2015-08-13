define(["Person"], function (Person) {

	var Employee = function (firstname, lastname, birthyear, department) {
		Person.apply(this, arguments)
		this.department = department;
	};

	Employee.prototype = Object.create(Person.prototype);

	return Employee;

});

