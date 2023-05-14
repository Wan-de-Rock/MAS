using MP2;

public class Program
{
    public static void Main(string[] args)
    {
        var car1 = new Car(110, EngineType.Petrol);
        var car2 = new Car(270, EngineType.Diesel);
        var car3 = new Car(350, EngineType.Electric);
        var car4 = new Car(250, EngineType.Gas);
        var car5 = new Car(400, EngineType.Electric);
        var car6 = new Car(120, EngineType.Diesel);
        var car7 = new Car(480, EngineType.Petrol);

        Console.WriteLine(car1.GetEngineType() + "\n"); // Composition

        var person1 = new Person("Nick");
        var person2 = new Person("Jack");
        var person3 = new Person("Tom");

        var station1 = new Station();
        var station2 = new Station();
        var station3 = new Station();

        /* Qualified association */
        station1.AddCar(car1);
        station1.AddCar(car2);
        station1.AddCar(car3);

        station2.AddCar(car4);
        station2.AddCar(car5);

        station3.AddCar(car6);
        station3.AddCar(car7);
        ///////////////

        /* Association with attribute */
        person1.AddRent(car3, 7);
        person1.AddRent(car6, 9);
        person2.AddRent(car2, 5);
        person2.AddRent(car7, 3);
        person3.AddRent(car1, 2);
        person3.AddRent(car4, 4);
        person3.AddRent(car5, 8);
        ///////////////

        /* Binary association */
        person1.Station = station1;
        station1.Owner = person1;
        person2.Station = station2;
        station2.Owner = person2;
        person3.Station = station3;
        station3.Owner = person3;
        ///////////////

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
    }
}