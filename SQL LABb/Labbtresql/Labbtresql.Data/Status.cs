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
    
    public partial class Status
    {
        public Status()
        {
            this.Copies = new HashSet<Copy>();
        }
    
        public int StatusID { get; set; }
        public string Value { get; set; }
    
        public virtual ICollection<Copy> Copies { get; set; }
    }
}
