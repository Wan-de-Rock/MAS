namespace MP5;

using System.Collections.Generic;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }


    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"Name: {Name}\tSurname: {Surname}";
    }
}

public class Driver
{
    public int Id { get; set; }
    public Person Person { get; set; }
    public HashSet<Car> Cars { get; private set; } = new HashSet<Car>();
    public Driver() { }

    public Driver(Person person)
    {
        Person = person;
    }

    public Driver(string name, string surname)
    {
        Person = new Person(name, surname);
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
        car.Drivers.Add(this);
    }


    public override string ToString()
    {
        return $"Driver {Person} drives cars {Cars.Count}";
    }
}

public class Mechanic
{
    public int Id { get; set; }
    public Person Person { get; set; }
    public HashSet<Car> Cars { get; private set; } = new HashSet<Car>();

    public Mechanic() { }
    public Mechanic(Person person)
    {
        Person = person;
    }

    public Mechanic(string name, string surname)
    {
        Person = new Person(name, surname);
    }

    public void AddCar(Car car)
    {
        Cars.Add(car);
        car.Mechanics.Add(this);
    }

    public override string ToString()
    {
        return $"Mechanic {Person} repairs cars {Cars.Count}";
    }
}

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public HashSet<Driver> Drivers { get; set; } = new HashSet<Driver>();
    public HashSet<Mechanic> Mechanics { get; set; } = new HashSet<Mechanic>();

    public Car() { }
    public Car(string name)
    {
        Name = name;
    }
}
