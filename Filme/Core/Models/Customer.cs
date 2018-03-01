using System;
using System.ComponentModel.DataAnnotations;

namespace Filme.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter costumer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; } //navigation property

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [Display(Name="Address")]
        public string Address { get; set; }

        [Display(Name="Date of birth")]
        [Is18YearsOldOrMember]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
    }
}