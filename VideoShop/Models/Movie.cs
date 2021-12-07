using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoShop.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DateAddedGreaterThanDateReleased]
        [Display(Name ="Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name ="Released Date")]
        public DateTime? DateReleased { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        public int NumberInStock { get; set; }

        public int AvailabileInStock { get; set; }
    }
}