using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoShop.Models;

namespace VideoShop.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genre { get; set; }

    }
}