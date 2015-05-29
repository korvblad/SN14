namespace Biblioteket.Entitydata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Copy")]
    public partial class Copy
    {
        public Copy()
        {
            Loans = new HashSet<Loan>();
        }

        public int CopyID { get; set; }

        public int StatusID { get; set; }

        public int BookID { get; set; }

        [Column(TypeName = "money")]
        public decimal? PurchaseCost { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseYear { get; set; }

        public virtual Book Book { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
