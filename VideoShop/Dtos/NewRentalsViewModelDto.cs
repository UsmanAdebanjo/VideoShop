using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Dtos
{
    public class NewRentalsViewModelDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
 
    }
}