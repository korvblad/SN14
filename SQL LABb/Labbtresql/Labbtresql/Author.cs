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
    
    public partial class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime YearOfBirth { get; set; }
        public Nullable<System.DateTime> YearOfDeath { get; set; }
        public string Language { get; set; }
    
        public virtual ICollection<Book> Books { get; set; }
    }
}
