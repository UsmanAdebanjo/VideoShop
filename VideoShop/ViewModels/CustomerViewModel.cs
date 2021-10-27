using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoShop.Models;

namespace VideoShop.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}