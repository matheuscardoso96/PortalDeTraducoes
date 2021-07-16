using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalDeTraducoes.Models.InputModels
{
    public class EditRoleInputModel
    {
        public string Id { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<string> Users = new List<string>();
    }
}
