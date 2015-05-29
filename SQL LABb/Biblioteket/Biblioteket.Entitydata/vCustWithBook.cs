namespace Biblioteket.Entitydata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vCustWithBook
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(101)]
        public string Customer { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BookTitle { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
