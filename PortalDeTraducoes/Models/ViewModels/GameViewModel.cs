using PortalDeTraducoes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.ViewModels
{
    public class GameViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CoverArtUrl { get; set; }
        public DateTime RealeaseDate { get; set; }
        public IList<string> Developers { get; set; } = new List<string>();
        public IList<string> Publishers { get; set; } = new List<string>();
        public IList<string> Platforms { get; set; } = new List<string>();
        public IList<string> Translations { get; set; } = new List<string>();
        public IList<string> Genres { get; set; } = new List<string>();
    }
}
