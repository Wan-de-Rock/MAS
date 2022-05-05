using MP1;

var store1 = new Storage();
var store2 = new Storage();

Console.WriteLine(Storage.GetNumberOfAllItems());

var a1 = new Item(5, "a1", ItemType.A);
var b1 = new Item(5, null, ItemType.B);
var c1 = new Item(4, null, ItemType.C);
var c2 = new Item(3, "c2", ItemType.C);
var c3 = new Item(2, "c3", ItemType.C);
var c4 = new Item(1, "c4", ItemType.C);
var c5 = new Item(5, null, ItemType.C);

store1.AddItem(a1);
store1.AddItem(b1);
store1.AddItem(c1);
store1.AddItem(c2);
store1.AddItem(c3);

foreach (var item in store1.StoreHouse)
{
    Console.WriteLine(item);
}
Console.WriteLine("\n\n");
foreach (var item in store2.StoreHouse)
{
    Console.WriteLine(item);
}
Console.WriteLine(Storage.GetItemsCountForType(ItemType.A));
Console.WriteLine(Storage.GetItemsCountForType(ItemType.B));
Console.WriteLine(Storage.GetItemsCountForType(ItemType.C));