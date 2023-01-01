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
    public HashSet<Car> Cars { get; set; } = new HashSet<Car>();
    public Driver(Person person)
    {
        Person = person;
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
    public HashSet<Car> Cars { get; set; } = new HashSet<Car>();

    public Mechanic(Person person)
    {
        Person = person;
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
    public HashSet<Driver> Drivers { get; set; }
    public HashSet<Mechanic> Mechanics { get; set; }

    public Car()
    {
        Drivers = new HashSet<Driver>();
        Mechanics = new HashSet<Mechanic>();
    }
}
