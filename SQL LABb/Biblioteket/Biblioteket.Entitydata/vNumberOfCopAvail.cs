namespace Biblioteket.Entitydata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vNumberOfCopAvail")]
    public partial class vNumberOfCopAvail
    {
        [Key]
        [StringLength(50)]
        public string BookTitle { get; set; }

        public int? NRAvail { get; set; }
    }
}
