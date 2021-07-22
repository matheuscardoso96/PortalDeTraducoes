using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.ViewModels
{
    public class TranslationViewModel
    {
       
        public string Language { get; set; }
       
        public string GameName { get; set; }
       
        public int GameId { get; set; }
       
        public List<string> Users { get; set; } = new List<string>();
       
        public List<string> TranslationImages { get; set; } = new List<string>();
        public int? GroupID { get; set; }
        public string GroupName { get; set; }
        public List<string> Versions { get; set; }
        public List<string> DownloadLinks { get; set; }
        public List<string> Notes { get; set; }
    }
}
