using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.Entities
{
    public class TranslationVersion: Entity
    {
        public string Version { get; private set; }
        public string DownloadLink { get; private set; }
        public string PatchNote { get; private set; }
        public int TranslationID { get; set; }
        public Translation Translation { get; set; }

        public TranslationVersion(string version, string downloadLink, string patchNote, int translationID, int iD) : base(iD)
        {
            Version = version;
            DownloadLink = downloadLink;
            PatchNote = patchNote;
            TranslationID = translationID;
        }

        public override string ToString()
        {
            return $"Versão: {Version}\r\nNota da versão: {PatchNote}";
        }
    }
}
