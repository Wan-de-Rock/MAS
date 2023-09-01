namespace MP4;
public class Person
{
    private const int NUMBER_OF_DIGITS_IN_PESEL = 11;

    private string? _pesel; // ograniczenie {unique} / ograniczenie statyczne

    public string Name { get; private set; }
    public string? Pesel // ograniczenie {atrybutu}
    {
        get { return _pesel; }
        set
        {
            /*
            if (_pesel is not null)
                throw new InvalidOperationException("Pesel already assigned");
            */

            if (ValidatePesel(value))
            {
                if (PeselDB.ContainsKey(value))
                {
                    if (PeselDB[value] == this)
                        return;
                    else
                        throw new ArgumentException("Pesel is not unique");
                }

                _pesel = value;
                PeselDB.Add(_pesel, this);
            }
        }
    }

    public Driver? Driver { get; }
    public Mechanic? Mechanic { get; }

    public static Dictionary<string, Person> PeselDB { get; } = new();

    protected Person(string name, string pesel)
    {
        Name = name;
        Pesel = pesel;
    }
    public Person(string name, string pesel, PersonType type) : this(name, pesel) // ograniczenie {XOR}
    {
        switch (type)
        {
            case PersonType.DRIVER:
                Driver = new Driver(this);
                Mechanic = null;
                break;
            case PersonType.MECHANIC:
                Mechanic = new Mechanic(this);
                Driver = null;
                break;
        }
    }

    private bool ValidatePesel(string pesel)
    {
        if (string.IsNullOrEmpty(pesel))
            throw new ArgumentException("Pesel can't be null or empty");

        if (pesel.Length != NUMBER_OF_DIGITS_IN_PESEL)
            throw new ArgumentException("Number of digits in PESEL number is not correct");

        var peselNumbers = new byte[NUMBER_OF_DIGITS_IN_PESEL];
        for (int i = 0; i < NUMBER_OF_DIGITS_IN_PESEL; i++)
        {
            try
            {
                peselNumbers[i] = byte.Parse(pesel[i].ToString());
            }
            catch (FormatException)
            {
                throw new FormatException($"Character on {i} position is not integer");
            }
        }


        return true;
    }

    public override string ToString()
    {
        return $"Name: {Name}\tPesel: {Pesel}";
    }
}

public class Driver
{
    public Person Person { get; }
    public List<Rent> Rents { get; private set; } = new List<Rent>();
    public Driver(Person person) { Person = person; }

    public void AddRent(Rent rent)
    {
        Rents.Add(rent);
    }
}

public class Mechanic
{
    public Person Person { get; }
    /* samochody mogą być serwisowane wyłącznie na zasadzie „kto pierwszy, ten lepszy”. */
    private readonly Queue<Car> Cars = new(); // ograniczenie {ordered} / ograniczenia wlasne

    public Mechanic(Person person) { Person = person; }

    public void AddCar(Car car)
    {
        Cars.Enqueue(car);
        car.Mechanic = this;
    }
    public Car RemoveFirstCar()
    {
        Car car = GetFirstCar();
        car.Mechanic = null;
        return Cars.Dequeue();
    }
    public Car GetFirstCar()
    {
        return Cars.Peek();
    }
}

public class Rent // ograniczenie {Bag} 
{
    public DateOnly From { get; }
    public DateOnly To { get; }

    public Car Car { get; }
    public Driver Driver { get; }

    public Rent(DateOnly from, DateOnly to, Car car, Driver driver)
    {
        From = from;
        if (to > from) // Ograniczenie dynamiczne
            To = to;
        else
            throw new ArgumentException("To have to be > then From");
        Car = car;
        Driver = driver;

        Car.AddRent(this);
        Driver.AddRent(this);
    }
}

public class Car
{
    private const int NUMBER_LENGTH = 5;
    private string _number; // ograniczenie {unique}

    public string Number // ograniczenie statyczne
    {
        get { return _number; }
        set
        {
            if (ValidateCarNumber(value))
            {
                if (Numbers.Add(value))
                    _number = value;
                else
                    throw new ArgumentException("Car number is not unique");
            }
        }
    }
    public Mechanic? Mechanic { get; set; } = null; // ograniczenie {ordered}
    public List<Rent> Rents { get; private set; } = new List<Rent>();
    public static HashSet<string> Numbers { get; private set; } = new HashSet<string>();

    public Car(string number)
    {
        Number = number;
    }

    public void AddRent(Rent rent)
    {
        Rents.Add(rent);
    }
    private bool ValidateCarNumber(string number)
    {
        if (number == null)
            throw new ArgumentNullException("Number can't be null");

        if (number.Length != NUMBER_LENGTH)
            throw new ArgumentException("Number lenght must be " + NUMBER_LENGTH);

        if (Numbers.Contains(number))
            throw new ArgumentException("Car number is not unique");

        return true;
    }
}

public enum PersonType
{
    DRIVER,
    MECHANIC
}