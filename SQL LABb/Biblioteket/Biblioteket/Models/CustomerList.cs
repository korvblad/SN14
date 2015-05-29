using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Biblioteket.Models
{
    public class CustomerList
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
        [DisplayName("Antal lån")]
        public int Loans { get; set; }

        public bool ActiveLoans{ get; set; }
        public bool ActiveCustomer { get; set; }

    }
}