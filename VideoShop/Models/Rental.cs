using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VideoShop.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        

    }
}