using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Group { get; set; }
        public List<string> Translations { get; set; }
    }
}
