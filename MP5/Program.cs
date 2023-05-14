using MP5;

public class Program
{
    public static void Main(string[] args)
    {
        var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        using (var context = new Context(connectionString))
        {
            var person1 = new Person("Don", "Karnage");
            var person2 = new Person("Nick", "Akimov");
            var person3 = new Person("Jack", "Vendi");
            var person4 = new Person("Tom", "Kimbo");
            var person5 = new Person("Don", "Amodedov");

            var car0 = new Car("car0");
            var car1 = new Car("car1");
            var car2 = new Car("car2");
            var car3 = new Car("car3");
            var car4 = new Car("car4");
            var car5 = new Car("car5");
            var car6 = new Car("car6");
            var car7 = new Car("car7");
            var car8 = new Car("car8");
            var car9 = new Car("car9");

            /* Inheritance accomplished with association: Driver, Mechanic —> Person */
            var driver1 = new Driver(person1);
            var driver2 = new Driver(person2);
            var driver3 = new Driver(person3);
            var driver4 = new Driver("Ali", "BaBa");
            var driver5 = new Driver("Albert", "Sohlmann");

            var mechanic1 = new Mechanic(person1);
            var mechanic2 = new Mechanic(person1);
            var mechanic3 = new Mechanic(person1);
            var mechanic4 = new Mechanic("Odin", "Hale");
            var mechanic5 = new Mechanic("Ivor", "Watkins");

            /* Association Driver -- Car */
            driver1.AddCar(car1);
            driver1.AddCar(car2);
            driver1.AddCar(car3);
            driver3.AddCar(car4);
            driver5.AddCar(car5);

            /* Association Mechanic -- Car */
            mechanic1.AddCar(car0);
            mechanic2.AddCar(car6);
            mechanic2.AddCar(car7);
            mechanic3.AddCar(car8);
            mechanic4.AddCar(car9);

            /* Saving changes to the database */
            context.Add(driver1);
            context.Add(driver2);
            context.Add(driver3);
            context.Add(driver4);
            context.Add(driver5);

            context.Add(mechanic1);
            context.Add(mechanic2);
            context.Add(mechanic3);
            context.Add(mechanic4);
            context.Add(mechanic5);

            context.SaveChanges();
        }
    }
}