using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>(idents);
        }

        public bool AreYou(string passedIn)
        {
            if (_identifiers == null)
                return false;
            foreach (string existing in _identifiers)
            {
                if (string.Compare(existing, passedIn, StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
            }
            return false;
        }

        public string FirstId
        {
            get
            {
                if (_identifiers[0] == null)
                    return "";
                return _identifiers[0];
            }
        }

        public void AddIdentifier(string toBeAdded)
        {
            if (!AreYou(toBeAdded))
                _identifiers.Add(toBeAdded.ToLower());
        }
    }

}
