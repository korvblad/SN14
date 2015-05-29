//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labbtresql.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Copies = new HashSet<Copy>();
        }
    
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public System.DateTime PublishedYear { get; set; }
        public string Language { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual ICollection<Copy> Copies { get; set; }
    }
}
