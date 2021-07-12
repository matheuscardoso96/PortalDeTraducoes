using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Platform : Entity
    {
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Game> Games { get; private set; } = new List<Game>();

        public Platform(string name, string imageUrl, int iD) : base(iD)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
