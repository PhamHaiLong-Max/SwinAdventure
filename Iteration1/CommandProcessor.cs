using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class CommandProcessor
    {
        private List<Command> _commandTypes = new List<Command>();

        public CommandProcessor()
        {
            _commandTypes.Add(new LookCommand());
            _commandTypes.Add(new MoveCommand());
            _commandTypes.Add(new PutCommand());
            _commandTypes.Add(new TakeCommand());
            _commandTypes.Add(new QuitCommand());
        }

        public string Execute(Player p, string[] command)
        {
            foreach(Command cmdType in _commandTypes)
            {
                if (cmdType.AreYou(command[0]))
                    return cmdType.Execute(p, command);
            }
            return "Unknown command. Start a command with 'look', 'move', 'go', 'leave', 'head', 'put', 'take', or 'quit'.";
        }
    }
}
