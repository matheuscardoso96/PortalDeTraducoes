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
        public string NickName { get; set; }
        [Required(ErrorMessage = "E-mail é necesárrio")]
        [EmailAddress]
        [Remote(action:"IsEmailInUse", controller:"Account")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é necesárria")]
        [DataType(DataType.Password)]      
        public string Password { get; set; }

        [Required(ErrorMessage = "Repetir a senha é necessário")]
        [DisplayName("Confime senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool StayLogged { get; set; }
    }
}
