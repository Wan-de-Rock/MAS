using MP2;

var car1 = new Car(110);
var car2 = new Car(270);
var car3 = new Car(350);
var car4 = new Car(250);
var car5 = new Car(400);
var car6 = new Car(120);
var car7 = new Car(480);

var person1 = new Person("Nick");
var person2 = new Person("Jack");
var person3 = new Person("Tom");

var station1 = new Station();
var station2 = new Station();
var station3 = new Station();

station1.AddCar(car1);
station1.AddCar(car2);
station1.AddCar(car3);

station2.AddCar(car4);
station2.AddCar(car5);

station3.AddCar(car6);
station3.AddCar(car7);

person1.AddRent(car3, 7);
person1.AddRent(car6, 9);
person2.AddRent(car2, 5);
person2.AddRent(car7, 3);
person3.AddRent(car1, 2);
person3.AddRent(car4, 4);
person3.AddRent(car5, 8);

person1.Station = station1;
station1.Owner = person1;
person2.Station = station2;
station2.Owner = person2;
person3.Station = station3;
station3.Owner = person3;

Console.WriteLine(person1 + "\n");
Console.WriteLine(person2 + "\n");
Console.WriteLine(person3 + "\n");

foreach (var rent in person1.Rents)
{
    Console.WriteLine(rent);
}
Console.WriteLine();
foreach (var rent in person2.Rents)
{
    Console.WriteLine(rent);
}
Console.WriteLine();
foreach (var rent in person3.Rents)
{
    Console.WriteLine(rent);
}


//Console.WriteLine(station1);
//Console.WriteLine(station2);
//Console.WriteLine(station3);