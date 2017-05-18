using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pubs.Data.Entities;

namespace Pubs.Data.Entities
{
    [Table("pubs_authors")]
    public partial class PubsAuthors
    {
        public PubsAuthors()
        {
            PubsTitleauthor = new HashSet<PubsTitleauthor>();
        }

        [Column("au_id", TypeName = "id")]
        public string AuId { get; set; }
        [Required]
        [Column("au_lname", TypeName = "varchar(40)")]
        public string AuLname { get; set; }
        [Required]
        [Column("au_fname", TypeName = "varchar(20)")]
        public string AuFname { get; set; }
        [Required]
        [Column("phone", TypeName = "char(12)")]
        public string Phone { get; set; }
        [Column("address", TypeName = "varchar(40)")]
        public string Address { get; set; }
        [Column("city", TypeName = "varchar(20)")]
        public string City { get; set; }
        [Column("state", TypeName = "char(2)")]
        public string State { get; set; }
        [Column("zip", TypeName = "char(5)")]
        public string Zip { get; set; }
        [Column("contract")]
        public bool Contract { get; set; }

        [InverseProperty("Au")]
        public ICollection<PubsTitleauthor> PubsTitleauthor { get; set; }
    }
}
