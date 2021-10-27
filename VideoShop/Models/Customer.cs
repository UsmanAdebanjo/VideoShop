using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VideoShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Birtdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Min18Years]
        [Display(Name ="MembershipType")]
        public int MembershipTypeId { get; set; }


        public bool IsSubscibedToNewsLetter { get; set; }
    }
}