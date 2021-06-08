using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { "quit", "end"})
        { }

        public override string Execute(Player p, string[] text)
        {
            if (!AreYou(text[0]) || text.Length != 1)
                return "Error in quit/end input.";
            return "Game ended. Bye.";
        }
    }
}
