using System.Text.Json.Serialization;

namespace MP1;

public class Item
{
    public int ID { get; }
    public int Size { get; }
    public string? Name { get; } = "unknown"; // Atrybut opcjonalny

    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly DateOfManufacture { get; } // Atrybut zlozony

    private static int counter = 0; // Atrybut klasowy
    public Item(int size, DateOnly dateOfManufacture, string? name = "none", int id = -1)
    {
        if (id < 0)
        {
            ID = counter;
            counter++;
        }
        else
        {
            ID = id;
            if (counter <= id)
                counter = id + 1;
        }

        Size = size;
        DateOfManufacture = dateOfManufacture;
        Name = name;

        /*
        if (name is not null)
            Name = name;
        */
    }

    //Przesłonięcie
    public override string? ToString()
    {
        return $"ID: {ID} \tSize: {Size} \tName: {Name} \tDate of Manufacture: {DateOfManufacture}";
    }
}