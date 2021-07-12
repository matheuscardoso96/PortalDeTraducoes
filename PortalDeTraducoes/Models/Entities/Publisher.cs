using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Game> Games { get; private set; } = new List<Game>();

        
        public Publisher(string name, string imageUrl, int iD) : base(iD)
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
