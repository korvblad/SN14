namespace Biblioteket.Entitydata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime YearOfBirth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? YearOfDeath { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
