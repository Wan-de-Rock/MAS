namespace MP1;

using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Storage
{
    private const string DIRECTORY = "Saves";
    public const string FILE_NAME = "save.json";
    public static readonly string PATH = Path.Combine(Directory.GetCurrentDirectory(), @"../../../", DIRECTORY);

    public int ID { get; }
    public static int NumberOfAllItems  // Derived attribute / Class attribute
    {
        get
        {
            return GetNumberOfAllItems();
        }
    }
    public List<Item> StoreHouse { get; private set; } // Multivalued attribute
    public static List<Storage> Storages { get; private set; } // Extent

    private static int counter = 0; // Class attribute

    static Storage()
    {
        var json = LoadJson(PATH, FILE_NAME);
        Storages = new List<Storage>(json);
    }
    public Storage()
    {
        ID = counter;
        counter++;

        if (ID < Storages.Count)
        {
            StoreHouse = Storages[ID].StoreHouse;
        }
        else
        {
            Storages.Add(this);
            StoreHouse = new List<Item>();
        }
    }

    [JsonConstructor]
    public Storage(int id, List<Item> storeHouse)
    {
        ID = id;
        StoreHouse = storeHouse;
    }

    ////// Overload ///////
    public void AddItem(Item item)
    {
        StoreHouse.Add(item);
        SaveJson(PATH, FILE_NAME, Storages);
    }
    public void AddItem(int size, DateOnly date, string? name)
    {
        AddItem(new Item(size, date, name));
    }
    ///////////////////////////
    public void ExtractItem(Item item)
    {
        if (StoreHouse.Contains(item))
        {
            StoreHouse.Remove(item);
            SaveJson(PATH, FILE_NAME, Storages);
        }
        else
            throw new ArgumentException("Storehouse does not contain this item");
    }

    private static int GetNumberOfAllItems()
    {
        int numOfItems = 0;
        foreach (var store in Storages)
            numOfItems += store.StoreHouse.Count;

        return numOfItems;
    }

    ////  Extent - persistency / Class method
    public static void SaveJson(string path, string fileName, ICollection<Storage> data)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IgnoreReadOnlyProperties = false,
            //DefaultIgnoreCondition = JsonIgnoreCondition.Never

            //Converters = { new DateOnlyJsonConverter() }
        };

        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, data, options);
        }
    }
    public static List<Storage> LoadJson(string path, string fileName)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var list = new List<Storage>();
        using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.OpenOrCreate))
        {
            if (fs.Length != 0)
            {
                list = JsonSerializer.Deserialize<List<Storage>>(fs);
            }
        }
        return list;
    }
    //////////////////////////
}

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "dd-MM-yyyy";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}