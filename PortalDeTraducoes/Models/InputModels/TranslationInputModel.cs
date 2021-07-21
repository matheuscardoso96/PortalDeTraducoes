using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.InputModels
{
    public class TranslationInputModel
    {
        [Required(ErrorMessage = "É necessária a língua cadastrada")]
        public int LanguageID { get; set; }
        [Required(ErrorMessage = "A tradução precisar estar vinculada a um jogo")]
        public string GameName { get; set; }
        [Required(ErrorMessage = "Id de jogo inválido")]
        public int GameId { get; set; }
        [Required(ErrorMessage = "A tradução precisa estar vinculada a pelo menos um usuário")]
        public List<string> Users { get; set; } = new List<string>();
        [Required(ErrorMessage = "A tradução precisa de imagens")]
        public List<string> TranslationImages { get;  set; } = new List<string>();
        public int? GroupID { get; set; }
        [Required(ErrorMessage = "A tradução precisa de idenficador de versão")]
        public string Version { get;  set; }
        [Required(ErrorMessage = "A tradução precisa de um link para download")]
        public string DownloadLink { get;  set; }
        [Required(ErrorMessage = "A tradução precisa de uma nota de versão")]
        [MaxLength(1024)]
        public string PatchNote { get;  set; }
    }
}
