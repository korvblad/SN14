using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Biblioteket.Models
{
    public class CustomerDetails
    {
        public int CustomerID { get; set; }
        [DisplayName("Förnamn")]
        public string FirstName { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("Telefonnummer")]
        public int? TelephoneNumber { get; set; }
        [DisplayName("Epost")]
        public string Email { get; set; }
        [DisplayName("Kön")]
        public string Gender { get; set; }
        [DisplayName("Födelseår")]
        public DateTime BirthYear { get; set; }


        [DisplayName("Litterature Title")]
        public string Name { get; set; }
        public int BookID { get; set; }
        [DisplayName("Borrow Date")]
        public DateTime? LoanDate { get; set; }
        [DisplayName("Return Date")]
        public DateTime? ReturnDate { get; set; }
        public bool LateReturn { get; set; }
    }
    
}