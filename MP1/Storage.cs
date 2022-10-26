namespace MP1;

using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class Storage
{
    private const string DIRECTORY = "Saves";
    private const string FILE_NAME = "Data";
    private static readonly string PATH = Path.Combine(Directory.GetCurrentDirectory(), @"../../../", DIRECTORY);

    public int ID { get; }
    public static int MaxItemId { get; private set; } = -1;
    public static int NumberOfAllItems => GetNumberOfAllItems();
    public List<Item> StoreHouse { get; private set; }

    private static int counter = 0;

    private static Dictionary<ItemType, int> ItemTypeCounter = new Dictionary<ItemType, int>();
    private static List<Storage> Storages = new List<Storage>();

    static Storage()
    {
        if (Directory.Exists(PATH))
        {
            string[] files = Directory.GetFiles(PATH);

            foreach (var file in files)
            {
                var list = Load(Path.Combine(PATH, file));
                var storage = new Storage(list);
                Storages.Add(storage);
                foreach (var item in list)
                {
                    if (item.ID > MaxItemId)
                        MaxItemId = item.ID;

                    storage.AddItem(item.Type);
                }
            }
            //NumberOfAllItems = GetNumberOfAllItems();
        }
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
    private Storage(List<Item> storeHouse)
    {
        StoreHouse = storeHouse;
    }

    public void AddItem(Item item)
    {
        StoreHouse.Add(item);
        AddItem(item.Type);
        Save(checkPathForId(), StoreHouse);
        //NumberOfAllItems++;
    }
    private void AddItem(ItemType type)
    {
        if (ItemTypeCounter.ContainsKey(type))
            ItemTypeCounter[type]++;
        else
            ItemTypeCounter.Add(type, 1);
    }
    public void ExtractItem(Item item)
    {
        if (StoreHouse.Contains(item))
        {
            StoreHouse.Remove(item);
            //NumberOfAllItems--;
            ItemTypeCounter[item.Type]--;
            Save(checkPathForId(), StoreHouse);
        }
        else
            throw new ArgumentException("Storehouse does not contain this item");
    }
    public static int GetItemsCountForType(ItemType type)
    {
        if (ItemTypeCounter.ContainsKey(type))
            return ItemTypeCounter[type];

        return 0;
    }
    private static int GetNumberOfAllItems()
    {
        return ItemTypeCounter.Values.Sum();
        /*
        int num = 0;

        foreach (var storage in Storages)
        {
            num += storage.StoreHouse.Count;
        }

        return num;
        */
    }
    private void Save(string fileName, List<Item> data)
    {
        if (!Directory.Exists(PATH))
            Directory.CreateDirectory(PATH);

        BinaryFormatter bf = new BinaryFormatter();
        using (Stream writer = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            bf.Serialize(writer, data);
        }
    }
    private static List<Item> Load(string fileName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (Stream reader = new FileStream(fileName, FileMode.Open))
        {
            return (List<Item>)bf.Deserialize(reader);
        }
    }
    private string checkPathForId()
    {
        return Path.Combine(PATH, FILE_NAME + (ID + 1).ToString() + ".dat");
    }
}