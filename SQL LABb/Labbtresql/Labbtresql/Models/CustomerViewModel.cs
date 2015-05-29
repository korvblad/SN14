using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labbtresql.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthYear { get; set; }
    }
}