using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "leave", "go", "head" })
        { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "leave")
                return "Leave using which exit?";
            if (text.Length != 2)
                return "I don't know how to move like that.";
            else if (!AreYou(text[0]))
                return "Error in movement input.";
            else
            {
                Path targetedPath = IdentifyPath(p, text[1]);
                if (targetedPath == null)
                    return "You couldn't find that path/exit.";
                else
                {
                    p.HeadThrough(text[1]);
                    return "You head " + targetedPath.FirstId + ".\n" + targetedPath.FullDescription + "\nYou have arrived in " + targetedPath.Destination.Name;
                }
            }
        }

        public Path IdentifyPath(Player p, string pathId)
        {
            return p.Location.LocatePathing(pathId) as Path;
        }
    }

    public interface IHaveInventory
    {
        GameObject Locate(string id);
        string Name { get; }
        Inventory Inventory { get; }
    }

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
                if (!p.Inventory.HasItem(text[1]))
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
                else if (container.Locate(text[1]) == null)
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
