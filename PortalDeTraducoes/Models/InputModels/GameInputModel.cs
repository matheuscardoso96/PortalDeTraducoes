using PortalDeTraducoes.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Models.InputModels
{
    public class GameInputModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Developers { get; set; }
        public string Publishers { get; set; } 
        public string Platforms { get; set; }
        public string Translations { get; set; }
       
    }
}
