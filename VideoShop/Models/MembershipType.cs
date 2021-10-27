using System;
using System.ComponentModel.DataAnnotations;
namespace VideoShop.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public int DiscountRate { get; set; }
        public byte DurationInMonth { get; set; }

    }
}