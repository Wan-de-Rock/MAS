using MP1;

public class Program
{
    public static void Main(string[] args)
    {
        var store1 = new Storage();
        var store2 = new Storage();

        Console.WriteLine($"\n\nNumber of elements after reading from file:  {Storage.NumberOfAllItems}\n\n"); // Derived attribute / Class attribute

        var a1 = new Item(15, new DateOnly(day: 5, month: 11, year: 2005), null); // Optional attribute / Complex attribute
        var a2 = new Item(54, new DateOnly(day: 12, month: 1, year: 2015), "a2"); // Complex attribute
        //var a3 = new Item(12, ItemType.A);
        var a4 = new Item(41, new DateOnly(day: 19, month: 12, year: 2001), "a4");
        var a5 = new Item(23, new DateOnly(day: 1, month: 2, year: 2007));
        var b1 = new Item(11, new DateOnly(day: 14, month: 3, year: 2007), null);
        var b2 = new Item(89, new DateOnly(day: 23, month: 4, year: 2010));
        var b3 = new Item(19, new DateOnly(day: 30, month: 7, year: 2011), "b3");
        var b4 = new Item(90, new DateOnly(day: 18, month: 8, year: 2008), null);
        var b5 = new Item(21, new DateOnly(day: 24, month: 2, year: 2001));
        var c1 = new Item(13, new DateOnly(day: 27, month: 3, year: 2004), "c1");
        var c2 = new Item(84, new DateOnly(day: 24, month: 5, year: 2020));
        var c3 = new Item(24, new DateOnly(day: 7, month: 10, year: 2012));
        var c4 = new Item(77, new DateOnly(day: 7, month: 10, year: 1975), "c4");
        var c5 = new Item(50, new DateOnly(day: 3, month: 6, year: 1572), null);

        var name = a1.Name; // Optional attribute
        var date = a4.DateOfManufacture; // Complex attribute

        store1.AddItem(a1); // Overload
        store1.AddItem(a2);
        store1.AddItem(a5);
        store1.AddItem(b4);
        store1.AddItem(c2);
        store1.AddItem(c4);
        store1.AddItem(c5);

        store2.AddItem(12, date, name); // Overload
        store2.AddItem(a4);
        store2.AddItem(b1);
        store2.AddItem(b2);
        store2.AddItem(b3);
        store2.AddItem(b5);
        store2.AddItem(c1);
        store2.AddItem(c3);

        var storages = Storage.Storages; // Extent

        ////  Extent - persistency / Class method
        Storage.SaveJson(Storage.PATH, Storage.FILE_NAME, storages); // Derived attribute / Class attribute
        storages = Storage.LoadJson(Storage.PATH, Storage.FILE_NAME); // Derived attribute / Class attribute
        ///////////////////////////////////////////

        foreach (Storage store in storages)
        {
            Console.WriteLine($"All items in storage {store.ID} :\n");
            foreach (Item item in store.StoreHouse) // Multivalued attribute
            {
                Console.WriteLine(item); // Override
            }
            Console.WriteLine('\n');
        }
    }
}