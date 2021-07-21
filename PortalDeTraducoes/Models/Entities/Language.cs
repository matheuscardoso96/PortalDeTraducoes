using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Language : Entity
    {
        public string Name { get; private set; }
        public string EmojiFlag { get; private set; }
        public Language(int iD, string name, string emojiFlag):base(iD)
        {
            Name = name;
            EmojiFlag = emojiFlag;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
