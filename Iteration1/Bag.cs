using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;
            if (Inventory.HasItem(id))
            {
                return Inventory.Fetch(id);
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + Name + " you can see:" + Inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
