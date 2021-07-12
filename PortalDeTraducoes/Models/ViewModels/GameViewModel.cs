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
        public IList<Developer> Developers { get; set; } = new List<Developer>();
        public IList<Publisher> Publishers { get; set; } = new List<Publisher>();
        public IList<Platform> Platforms { get; set; } = new List<Platform>();
        public IList<Translation> Translations { get; set; } = new List<Translation>();
        public IList<Genre> Genres { get; set; } = new List<Genre>();
    }
}
