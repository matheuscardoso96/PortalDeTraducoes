using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Group : Entity
    {
        public string Name { get; private set; }
        public ICollection<User> Users { get; private set; } = new List<User>();
        public string ImageUrl { get; private set; }
        public ICollection<Translation> Translations { get; set; } = new List<Translation>();

        public Group(string name, string imageUrl, int iD) : base(iD)
        {            
            Name = name;
            ImageUrl = imageUrl;
        }

        public void AddUser(User user) 
        {
            Users.Add(user);
        }
    }
}
