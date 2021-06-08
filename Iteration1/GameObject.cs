using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string ShortDescription
        {
            get
            {
                return _name + " (" + FirstId + ")";
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}