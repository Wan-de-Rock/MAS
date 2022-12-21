namespace MP2;

public class Engine
{
    public EngineType Type { get; }

    public Engine(EngineType type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return $"Engine type: {Type}";
    }
}
public class Person
{
    public string Name { get; }
    public Station ?Station { get; set; } /* Binary association */
    public List<Rent> Rents { get; private set; } = new List<Rent>(); /* Association with attribute */

    public Person(string name)
    {
        Name = name;
    }

    public void AddRent(Car car, int time)
    {
        var rent = new Rent(time, car, this);
        if (Rents.Contains(rent))
            return;

        Rents.Add(rent);
        car.AddRent(rent);
    }
    public void RemoveRent(Rent rent)
    {
        if (Rents.Contains(rent))
            Rents.Remove(rent);
    }

    public override string ToString()
    {
        return $"Name: {Name}\nStation:\n{Station}";
    }
}
public class Car
{
    public int Id { get; }
    public int DayRentalCost { get; }
    public List<Rent> Rents { get; private set; } = new List<Rent>(); /* Association with attribute */

    private Engine _engine; // Composition

    private static int counter = 0;
    public Car(int dayRentalCost, EngineType type)
    {
        Id = counter++;
        DayRentalCost = dayRentalCost;

        _engine = new Engine(type); // Composition
    }

    public void AddRent(Rent rent)
    {
        if (Rents.Contains(rent))
            return;

        Rents.Add(rent);
    }

    public void RemoveRent(Rent rent)
    {
        if (Rents.Contains(rent))
            Rents.Remove(rent);
    }

    public EngineType GetEngineType()
    {
        return _engine.Type;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Rental: {DayRentalCost}";
    }
}

public class Rent /* Attribute of association */
{
    public Car Car { get; }
    public Person Person { get; }
    public int Time { get; }
    public int Price => Car.DayRentalCost * Time;

    public Rent(int time, Car car, Person person)
    {
        Time = time;
        Car = car;
        Person = person;
    }
    public override string ToString()
    {
        return $"Person: {Person.Name}\nCar Identificator: {Car.Id}\nTotal Price: {Price}";
    }
}

public class Station
{
    public Person ?Owner { get; set; } /* Binary association */
    public Dictionary<int, Car> Cars { get; private set; } = new Dictionary<int, Car>(); /* Qualified association */

    public void AddCar(Car car)
    {
        if (Cars.ContainsKey(car.Id))
            return;

        Cars.Add(car.Id, car);
    }
    public void RemoveCar(int id)
    {
        if (Cars.ContainsKey(id))
            Cars.Remove(id);
    }
    public Car GetCar(int id)
    {
        return Cars[id];
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, Cars);
    }
}

public enum EngineType
{
    Petrol,
    Diesel,
    Electric,
    Gas
}