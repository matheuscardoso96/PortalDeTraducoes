using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.InputModels
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Apelido é necesárrio")]
        [Remote(action: "CheckNick", controller: "Account", HttpMethod = "Post")]
        [MinLength(4)]
        public string NickName { get; set; }
        [Required(ErrorMessage = "E-mail é necesárrio")]
        [EmailAddress]
        [Remote(action:"CheckEmail", controller:"Account", HttpMethod ="Post")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é necesárria")]
        [DataType(DataType.Password)]      
        public string Password { get; set; }

        [Required(ErrorMessage = "Repetir a senha é necessário")]
        [DisplayName("Confime senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
        public string Country { get; internal set; }

    }
}
