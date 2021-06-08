using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (!AreYou(text[0]))
                return "Error in put/drop input.";
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to put/drop things like that";
            }
            else if (text.Length == 2)
            {
                if (p.Inventory.HasItem(text[1]))
                {
                    Item i = p.Inventory.Take(text[1]);
                    p.Location.Inventory.Put(i);
                    return "You have put/droped " + i.Name + " in " + p.Location.Name + ".";
                }
                else
                    return "I cannot find " + text[1] + ".";
            }
            else
            {
                if (text[2] != "in")
                    return "Error in put/drop input.";
                IHaveInventory container = FetchContainer(p, text[3]);
                if(!p.Inventory.HasItem(text[1]))
                {
                    return "I cannot find " + text[1] + ".";
                }
                else if (container == null)
                {
                    return "I cannot find " + text[3] + ".";
                }
                else
                {
                    Item i = p.Inventory.Take(text[1]);
                    container.Inventory.Put(i);
                    return "You have put/dropped " + i.Name + " into " + container.Name + ".";
                }
            }
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
    }
}
