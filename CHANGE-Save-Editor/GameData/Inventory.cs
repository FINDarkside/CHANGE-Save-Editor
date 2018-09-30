using System.Collections.Generic;

namespace CHANGE_Save_Editor.GameData
{
    public class Inventory
    {

        public List<Item> Items { get; set; }

        public Inventory()
        {
            this.Items = new List<Item>();
        }

        public void CreateItem(string name, int amount)
        {
            Items.Add(new Item(name, amount));
        }

        public Item GetByName(string name)
        {
            return Items.Find(item => item.name == name);
        }

        public void SetAmount(string name, int amount)
        {
            var item = GetByName(name);
            if (item != null)
            {
                item.amount = amount;
            }
        }

    }

    public class Item
    {
        public Item(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public string name { get; set; }
        public int amount { get; set; }
    }
}
