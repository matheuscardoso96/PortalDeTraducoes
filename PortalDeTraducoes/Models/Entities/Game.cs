using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Game : Entity
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string CoverArtUrl { get; private set; }
        public IList<Genre> Genre { get; private set; } = new List<Genre>();
        public IList<Developer> Developers { get;  set; } = new List<Developer>();
        public IList<Publisher> Publishers { get;  set; } = new List<Publisher>();
        public IList<Platform> Platforms { get;  set; } = new List<Platform>();
        public IList<Translation> Translations { get;  set; } = new List<Translation>();

       
        public Game(string title, DateTime releaseDate, string coverArtUrl , int iD) :base(iD)
        {
            ReleaseDate = releaseDate;
            Title = title;
            CoverArtUrl = coverArtUrl;
           
        }

        public void AddGenre(Genre genre) 
        {
            Genre.Add(genre);
        }

        public void AddDeveloper(Developer developer)
        {
            Developers.Add(developer);
        }

        public void AddPublisher(Publisher publisher)
        {
            Publishers.Add(publisher);
        }

        public void AddPlatform(Platform platform)
        {
            Platforms.Add(platform);
        }

        public void AddTranslation(Translation translation)
        {
            Translations.Add(translation);
        }
    }
}
