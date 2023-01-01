namespace MP4;
public class Person
{
    private const int NUMBER_OF_DIGITS_IN_PESEL = 11;

    private string _pesel;

    public string Name { get; private set; }

    public string Pesel
    {
        get { return _pesel; }
        set
        {
            if (ValidatePesel(value))
            {
                if (peselDB.ContainsKey(value))
                {
                    if (peselDB[value] == this)
                        return;
                    else
                        throw new ArgumentException("Pesel is not unique");                    
                }

                if (_pesel != null)
                {
                    if (peselDB.ContainsKey(_pesel))
                        peselDB.Remove(_pesel);
                }

                _pesel = value;
                peselDB.Add(_pesel, this);
            }
        }
    }

    private static Dictionary<string, Person> peselDB = new Dictionary<string, Person>();

    public Person(string name, string pesel)
    {
        Name = name;
        Pesel = pesel;
    }

    private bool ValidatePesel(string pesel)
    {
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
