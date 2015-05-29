namespace Biblioteket.Entitydata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            Copies = new HashSet<Copy>();
        }

        public int BookID { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishedYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Copy> Copies { get; set; }
    }
}
