using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }

        public IEnumerable<MovieDto> Movies { get; set; }
        public MovieDto Movie { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}