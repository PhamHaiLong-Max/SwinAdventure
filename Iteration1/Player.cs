using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class Player : GameObject, IHaveInventory
    {
        private Location _location = new Location(new string[] { "hall", "room" }, "Main Hall", "This is the starting room of the game");
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        { }

        public GameObject Locate(string Id)
        {
            if (AreYou(Id))
                return this;
            if (Inventory.HasItem(Id))
            {
                return Inventory.Fetch(Id);
            }
            else
                return Location.Locate(Id);
        }

        public void HeadThrough(string dir)
        {
            Path path = Location.LocatePathing(dir);
            if(path != null)
                path.MovePlayer(this);
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + Name + ", " + base.FullDescription + ".\nYou are carrying:" + Inventory.ItemList;
            }
        }
        
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}