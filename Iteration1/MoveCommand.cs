using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "leave", "go", "head"})
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
                if(targetedPath == null)
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
}
