using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Dtos
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DiscountRate { get; set; }
        public byte DurationInMonth { get; set; }
    }
}