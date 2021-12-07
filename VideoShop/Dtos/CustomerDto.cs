using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birtdate { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        //[Min18Years]

        public int MembershipTypeId { get; set; }


        public bool IsSubscibedToNewsLetter { get; set; }
    }
}