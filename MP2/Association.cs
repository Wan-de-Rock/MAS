
namespace MP2
{
    public class Engine { }
    public class CarType { }
    public class Person
    {
        public string Name { get; }
        public List<Rent> Rents { get; private set; }

        public Person(string name)
        {
            Name = name;
            Rents = new List<Rent>();
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
    }
    public class Car
    {
        public int Id { get; }
        public int DayRentalCost { get; }
        public CarType Type { get; set; } // Zwykła
        public Engine Engine { get; } // Kompozycja
        public Station Station { get; set; }
        public List<Rent> Rents { get; private set; }

        private static int id = 0;
        public Car(int dayRentalCost)
        {
            Id = ++id;
            Engine = new Engine();
            DayRentalCost = dayRentalCost;
            Rents = new List<Rent>();
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

        public override string ToString()
        {
            return $"ID: {Id} | Rental: {DayRentalCost} | Station: {Station.Id}";
        }
    }

    public class Rent
    {
        public int Time { get; }
        public int Price => Car.DayRentalCost * Time;

        private Car Car;
        private Person Person;

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
        public int Id { get; }

        public Dictionary<int, Car> Cars { get; private set; } = new Dictionary<int, Car>();

        private static int id = 0;
        public Station()
        {
            Id = ++id;
        }

        public void AddCar(Car car)
        {
            if (!Cars.ContainsKey(car.Id))
                Cars.Add(car.Id, car);
        }
        public void RemoveCar(int id)
        {
            if (Cars.ContainsKey(Id))
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

}
