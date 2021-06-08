using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        { }

        public void ConstructPath(Path path)
        {
            _paths.Add(path);
        }

        public override string FullDescription
        {
            get
            {
                string paths = "";
                foreach (Path p in _paths)
                {
                    if (paths != "")
                        paths += ", ";
                        paths += p.FirstId;
                }
                return "You are in " + Name + ".\n" + base.FullDescription + "\nThere are exits to the " + paths + "\n\nIn this room you can see:" + Inventory.ItemList;
            }
        }

        public Path LocatePathing(string id)
        {
            foreach(Path path in _paths)
            {
                if (path.AreYou(id))
                    return path as Path;
            }
            return null;
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

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}