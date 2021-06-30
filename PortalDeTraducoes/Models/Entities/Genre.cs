using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public ICollection<Game> Games { get; private set; } = new List<Game>();

        public Genre(string name, int iD) : base(iD)
        {
            Name = name;       
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
