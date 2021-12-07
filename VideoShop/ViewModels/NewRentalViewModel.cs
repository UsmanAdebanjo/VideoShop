using System;
using VideoShop.Models;
using System.Linq;
using System.Collections.Generic;

namespace VideoShop.ViewModels
{
    public class NewRentalViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<int> MovieId { get; set; }


    }
}