using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.InputModels
{
    public class EditUserInputModel
    {
        [Required(ErrorMessage = "O Id é necesárrio")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Apelido é necesárrio")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "E-mail é necesárrio")]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Country { get;  set; }
    }
}
