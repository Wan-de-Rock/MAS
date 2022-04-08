using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MP1
{
    public class Storage
    {
        private const string PATH = "Data.bin";

        public int ID { get; }
        public List<Item> StoreHouse { get; private set; }

        private static Dictionary<ItemType, int> ItemTypeCounter = new Dictionary<ItemType, int>();
        private static List<Storage> Storages = new List<Storage>();

        private static int counter = 1;
        public Storage()
        {
            ID = counter;
            counter++;
            Storages.Add(this);

            if (File.Exists(checkPathForId()))
            {
                StoreHouse = Load(checkPathForId());

                foreach (var item in StoreHouse)
                {
                    AddItem(item.Type);
                }

            }
            else
            {
                StoreHouse = new List<Item>();
            }

        }



        public void AddItem(Item item)
        {
            StoreHouse.Add(item);
            AddItem(item.Type);
            Save(checkPathForId(), StoreHouse);
        }

        private static void AddItem(ItemType type)
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
                ItemTypeCounter[item.Type]--;

                Save(checkPathForId(), StoreHouse);
            }
            else
                throw new ArgumentException("Storehouse does not contain this item");
        }

        public static int GetItemsCountForType(ItemType type)
        {
            int count = ItemTypeCounter[type];
            return count;
        }
        public static int GetNumberOfAllItems()
        {
            return ItemTypeCounter.Values.Sum();
        }

        private void Save(string fileName, List<Item> data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream writer = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                bf.Serialize(writer, data);
            }
        }
        private List<Item> Load(string fileName)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream reader = new FileStream(fileName, FileMode.Open))
            {
                return (List<Item>)bf.Deserialize(reader);
            }
        }

        private string checkPathForId()
        {
            string path = ID.ToString() + PATH;
            return path;
        }
    }
}
