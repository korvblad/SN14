//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labbtresql
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Loans = new HashSet<Loan>();
        }
    
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public System.DateTime BirthYear { get; set; }
    
        public virtual ICollection<Loan> Loans { get; set; }
    }
}