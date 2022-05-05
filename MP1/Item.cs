using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1
{
    [Serializable]
    public class Item : IComparable<Item>
    {

        //public int ID { get; }
        public int Size { get; }
        public string? Name { get; }
        public ItemType Type { get; }


        //private static int counter = Storage.GetNumberOfAllItems();


        public Item(int size, string? name, ItemType type)
        {
            //ID = ++counter;
            Size = size;
            Name = name;
            Type = type;
        }

        public int CompareTo(Item? other)
        {
            if (Size > other.Size)
                return 1;
            if (Size < other.Size)
                return -1;
            return 0;
        }

        public override string? ToString()
        {
            return //$"ID: {ID}\t" +
                $"Size: {Size}\t" +
                $"Name: {Name}\t" +
                $"Type: {Type}";
        }
    }

    public enum ItemType
    {
        A,
        B,
        C
    }
}