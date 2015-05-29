namespace Biblioteket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loan")]
    public partial class Loan
    {
        public int LoanID { get; set; }

        public int CustomerID { get; set; }

        public int CopyID { get; set; }

        public DateTime? LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
       
        public bool LoanReturn { get; set; }
        
        public virtual Copy Copy { get; set; }

        public virtual Customer Customer { get; set; }

        public bool LateReturn { get; set; }

    }
}
