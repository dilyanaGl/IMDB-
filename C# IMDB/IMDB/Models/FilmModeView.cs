using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class FilmModeView
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Genre { get; set; }

        [Required]
        [MinLength(1)]
        public string Director { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Year { get; set; }

        [Key]
        public int Id { get; set; }
    }
}