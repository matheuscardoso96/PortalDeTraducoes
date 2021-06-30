using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class User : Entity
    {
        public string NickName { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public Group Group { get; set; }
        public int? GroupID { get; set; }       
        public IList<Translation> Translations { get; private set; }
        public User(string nickName, string country, string state, string city, string password, int? groupID, int iD) : base(iD)
        {
            Translations = new List<Translation>();
            NickName = nickName;
            Country = country;
            State = state;
            City = city;
            Password = password;
            Active = true;
            GroupID = groupID;
            
            
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
