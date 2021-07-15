using System.ComponentModel.DataAnnotations;


namespace PortalDeTraducoes.Models.InputModels
{
    public class RoleInputModel
    {
        [Required(ErrorMessage = "É preciso que o campo seja preenchido.")]
        public string Role { get; set; }
    }
}
