using MP4;

Person mechanic1 = null!, mechanic2 = null!, mechanic3 = null!;
Person driver1 = null!, driver2 = null!;
Car car1 = null!, car2 = null!, car3 = null!, car4 = null!, car5 = null!;

try
{
    mechanic1 = new Person("m1", "11111111111", PersonType.MECHANIC); // ograniczenie {unique} Pesel
    mechanic2 = new Person("m2", "11111111111", PersonType.MECHANIC); // ograniczenie statyczne Pesel
    mechanic3 = new Person("m3", "11111111113", PersonType.MECHANIC); // ograniczenie {XOR}

    driver1 = new Person("d1", "11111111121", PersonType.DRIVER); // ograniczenie {unique} Pesel / ograniczenie statyczne Pesel
    driver2 = new Person("d2", "11111111122", PersonType.DRIVER); // ograniczenie {XOR}

    car1 = new Car("WF5K6"); // ograniczenie {unique} Number / ograniczenie statyczne Number
    car2 = new Car("AJLNJ");
    car3 = new Car("AKJNK");
    car4 = new Car("LMK77");
    car5 = new Car("35KNJ");

    // ograniczenie {Bag} Driver <-> Car
    // ograniczenie dynamiczne Date To > Date From
    var rent = new Rent(new DateOnly(2000, 12, 1), new DateOnly(2000, 12, 2), car1, driver1.Driver);

    // ograniczenie {ordered} / ograniczenia wlasne
    mechanic1.Mechanic.AddCar(car1);
    mechanic1.Mechanic.AddCar(car2);
    ////////////////////////////////
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

foreach (var person in Person.PeselDB.Values)
{
    Console.WriteLine(person);
}
