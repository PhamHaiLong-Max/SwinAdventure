using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "pickup", "take" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (!AreYou(text[0]))
                return "Error in pickup/take input.";
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to pickup/take things like that";
            }
            else if (text.Length == 2)
            {
                if (p.Location.Inventory.HasItem(text[1]))
                {
                    Item i = p.Location.Inventory.Take(text[1]);
                    p.Inventory.Put(i);
                    return "You have taken " + i.Name + " from " + p.Location.Name + ".";
                }
                else
                    return "I cannot find " + text[1] + ".";
            }
            else
            {
                IHaveInventory container = FetchContainer(p, text[3]);

                if (container == p)
                    return "Taking things from yourself for yourself is quite dumb, aye?";
                if (container == null)
                {
                    return "I cannot find the " + text[3] + ".";
                }
                else if(container.Locate(text[1]) == null)
                {
                    return "I can't find the " + text[1] + ".";
                }
                else
                {
                    Item i = container.Inventory.Take(text[1]);
                    p.Inventory.Put(i);
                    return "You have taken " + i.Name + " from " + container.Name + ".";
                }
            }
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }
    }
}
