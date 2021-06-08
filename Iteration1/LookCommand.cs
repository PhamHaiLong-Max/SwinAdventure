using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "look")
                return p.Location.FullDescription;
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that.";
            else if (text[0] != "look")
                return "Error in look input.";
            else if (text[1] != "at")
                return "What do you want to look AT?";
            else
            {
                if (text.Length == 3)
                {
                    return LookAtIn(text[2], FetchContainer(p, p.FirstId));
                }
                else
                {
                    IHaveInventory a = FetchContainer(p, text[4]);
                    if (a == null)
                        return "I can't find the " + text[4] + ".";
                    return LookAtIn(text[2], a);
                }
            }
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if(container.Locate(thingId) == null)
                return "I can't find the " + thingId + ".";
            else
                return container.Locate(thingId).FullDescription;
        }
    }
}
