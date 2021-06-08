using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {
        }

        public bool HasItem(string Id)
        {
            foreach(Item i in _items)
            {
                if (i.AreYou(Id))
                    return true;
            }
            return false;
        }

        public void Put(Item Itm)
        {
            _items.Add(Itm);
        }

        public Item Take(string Id)
        {
            foreach(Item i in _items)
            {
                if(i.AreYou(Id))
                {
                    _items.Remove(i);
                    return i;
                }
            }
            return null;
        }

        public Item Fetch(string Id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(Id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string ToBeReturned = "";
                foreach(Item i in _items)
                {
                    ToBeReturned += "\n\t" + i.ShortDescription;
                }
                return ToBeReturned;
            }
        }
    }
}
