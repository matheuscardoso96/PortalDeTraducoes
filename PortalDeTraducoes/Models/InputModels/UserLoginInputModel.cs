using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.InputModels
{
    public class UserLoginInputModel
    {
        [Required(ErrorMessage = "Apelido é necesárrio")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Senha é necesárria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }      
        [Required]
        [Display(Name = "Permanecer na conta")]
        public bool StayLogged { get; set; }
    }
}
