using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte GenreId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateReleased { get; set; }
        //public Genre Genre { get; set; }
    }
}