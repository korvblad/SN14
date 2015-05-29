namespace Biblioteket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status
    {
        public Status()
        {
            Copies = new HashSet<Copy>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
    }
}
