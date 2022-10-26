namespace MP1;

[Serializable]
public class Item : IComparable<Item>
{
    public int ID { get; }
    public int Size { get; }
    public string? Name { get; }
    public ItemType Type { get; }

    private static int counter = 0;
    public Item(int size, string? name, ItemType type)
    {
        ID = ++counter + Storage.MaxItemId;
        Size = size;
        Type = type;

        if (name is null)
            Name = "none";
        else
            Name = name;
    }

    public int CompareTo(Item? other)
    {
        if (other == null)
            throw new ArgumentNullException("other");

        if (Size > other.Size)
            return 1;
        if (Size < other.Size)
            return -1;

        return ID.CompareTo(other.ID);
    }

    public override string? ToString()
    {
        return $"ID: {ID} \tSize: {Size} \tName: {Name} \tType: {Type}";
    }
}

public enum ItemType
{
    A,
    B,
    C
}
