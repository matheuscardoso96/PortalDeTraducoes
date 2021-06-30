using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class TranslationImage: Entity
    {
        public string Url { get; set; }
        public Translation Translation { get; set; }
        public int TranslationID { get; set; }
        public TranslationImage(string url, int iD):base(iD)
        {
            Url = url;
        }
    }
}
