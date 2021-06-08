using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class Path : GameObject
    {
        Location _destination = new Location(new string[] { "deadend"}, "null", "null");

        public Path(string[] ids, string name, string desc) : base(ids, name, desc)
        { }

        public Location Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
            }
        }
        
        public void MovePlayer(Player p)
        {
            p.Location = Destination;
        }
    }
}
