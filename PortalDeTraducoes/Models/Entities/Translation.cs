using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class Translation : Entity
    {
        public string Language { get; private set; }
        public Game Game { get; set; }
        public int GameID { get; set; }
        public ICollection<User> Users { get; private set; }
        public ICollection<TranslationImage> TranslationImages { get; private set; } = new List<TranslationImage>();
        public Group Group { get; set; }
        public int? GroupID { get; set; }
        public ICollection<TranslationVersion> TranslationVersions { get; set; } = new List<TranslationVersion>();

        public Translation(string language, int gameID, int? groupID, int iD) : base(iD)
        {            
            Language = language;
            GameID = gameID;
            GroupID = groupID;

        }
        public void AddUser(User user) 
        {
            Users.Add(user);
        }

        public void AddImageUrl(TranslationImage translationImage)
        {
            TranslationImages.Add(translationImage);
        }

        public void AddTranslationVersion(TranslationVersion translationVersion)
        {
            TranslationVersions.Add(translationVersion);
        }

        public override string ToString()
        {
            return $"Traduzido em: {Language}";
        }
    }
}
