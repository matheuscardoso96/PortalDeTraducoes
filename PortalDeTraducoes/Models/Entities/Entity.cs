using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public abstract class Entity
    {
        public int ID { get; private set; }

        public Entity(int iD)
        {
            ID = iD;
        }
        
    }
}
