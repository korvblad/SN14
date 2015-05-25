using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace labb888.Models
{
    public class Contact
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Du måste ange en email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Namnet måste vara minst 2 tecken")]
        public string FirstName { get; set; }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Efternamnet måste innehålla minst 2 tecken")]
        public string LastName { get; set; }
    }
}