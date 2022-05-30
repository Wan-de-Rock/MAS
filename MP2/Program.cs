using MP2;

var type1 = new CarType();
var type2 = new CarType();

var car1 = new Car(100);
var car2 = new Car(200);
var car3 = new Car(300);

var person1 = new Person("Nick");
var person2 = new Person("Jack");
var person3 = new Person("Tom");

car1.Type = type1;

var rent = new Rent(10, car3, person3);
car3.AddRent(rent);
person3.AddRent(rent);

Console.WriteLine(rent + "\n");

var station = new Station();
station.AddCar(car1);
station.AddCar(car2);
station.AddCar(car3);

car1.Station = station;
car2.Station = station;
car3.Station = station;

Console.WriteLine(station);
