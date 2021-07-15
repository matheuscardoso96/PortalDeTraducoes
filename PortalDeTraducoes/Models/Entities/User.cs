using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class User : IdentityUser
    {
        public string Country { get; set; }
        public bool Active { get; private set; }
        public Group Group { get; set; }
        public int? GroupID { get; set; }       
        public IList<Translation> Translations { get; private set; }
        public User()
        {
            Translations = new List<Translation>();         
            Active = true;           
            
        }
        public void AddTranslation(Translation translation) 
        {
            Translations.Add(translation);
        }

        public void Deactivate() 
        {
            Active = false;
        }
    }
}
