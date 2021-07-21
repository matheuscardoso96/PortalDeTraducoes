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
        public string Title { get; set; }
        public string CovertArtUrl { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Developers { get; set; }
        public string Publishers { get; set; }
        public int[] PlatformsId { get; set; }
        public int[] GenresId { get; set; }
       
    }
}
