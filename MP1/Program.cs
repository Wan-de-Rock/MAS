using MP1;

var store1 = new Storage();
var store2 = new Storage();

Console.WriteLine($"\n\n Number of elements after reading from file:  {Storage.NumberOfAllItems}\n\n");

var a1 = new Item(15, null, ItemType.A);
var a2 = new Item(54, "a2", ItemType.A);
var a3 = new Item(12, "a3", ItemType.A);
var a4 = new Item(41, "a4", ItemType.A);
var a5 = new Item(23, null, ItemType.A);
var b1 = new Item(11, "b1", ItemType.B);
var b2 = new Item(89, null, ItemType.B);
var b3 = new Item(19, "b3", ItemType.B);
var b4 = new Item(90, null, ItemType.B);
var b5 = new Item(21, "b5", ItemType.B);
var c1 = new Item(13, "c1", ItemType.C);
var c2 = new Item(84, null, ItemType.C);
var c3 = new Item(24, "c3", ItemType.C);
var c4 = new Item(77, "c4", ItemType.C);
var c5 = new Item(50, null, ItemType.C);

store1.AddItem(a1);
store1.AddItem(a2);
store1.AddItem(a5);
store1.AddItem(b4);
store1.AddItem(c2);
store1.AddItem(c4);
store1.AddItem(c5);

store2.AddItem(a3);
store2.AddItem(a4);
store2.AddItem(b1);
store2.AddItem(b2);
store2.AddItem(b3);
store2.AddItem(b5);
store2.AddItem(c1);
store2.AddItem(c3);

Console.WriteLine($"All items in storage {store1.ID} :");
foreach (var item in store1.StoreHouse)
{
    Console.WriteLine(item);
}
Console.WriteLine($"\n\nAll items in storage {store2.ID} :");
foreach (var item in store2.StoreHouse)
{
    Console.WriteLine(item);
}

Console.WriteLine("\n\n");
Console.WriteLine($"Number of type {ItemType.A} Items: {Storage.GetItemsCountForType(ItemType.A)}");
Console.WriteLine($"Number of type {ItemType.B} Items: {Storage.GetItemsCountForType(ItemType.B)}");
Console.WriteLine($"Number of type {ItemType.C} Items: {Storage.GetItemsCountForType(ItemType.C)}");