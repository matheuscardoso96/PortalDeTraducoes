using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class UserRole : Entity
    {
        public string Description { get; private set; }
        public UserRole(int iD, string description): base(iD)
        {
            Description = description;
        }
    }
}
