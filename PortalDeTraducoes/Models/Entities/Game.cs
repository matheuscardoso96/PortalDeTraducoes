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
        public IList<Genre> Genre { get; private set; }
        public IList<Developer> Developers { get; private set; }
        public IList<Publisher> Publishers { get; private set; }
        public IList<Platform> Platforms { get; private set; }
        public IList<Translation> Translations { get; private set; } = new List<Translation>();

       
        public Game(string title, DateTime releaseDate, int iD) :base(iD)
        {
            ReleaseDate = releaseDate;
            Title = title;
            Genre = new List<Genre>();
            Developers = new List<Developer>();
            Publishers = new List<Publisher>();
            Platforms = new List<Platform>();
            
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
