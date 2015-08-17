require(["Employee", "Person"], function (Employee, Person) {
	
	var p1 = new Person('petter', 'pettersen', 1990);
	var p2 = new Employee('ole', 'olsen', 1980, 'salg');


	console.log(p2.toString());
	console.log(p2.getAge());
	console.log(p2.department);

	console.log(p1 instanceof Person);
	console.log(p1 instanceof Employee);

});




