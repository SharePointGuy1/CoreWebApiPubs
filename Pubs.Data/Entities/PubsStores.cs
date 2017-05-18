using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_stores")]
    public partial class PubsStores
    {
        public PubsStores()
        {
            PubsSales = new HashSet<PubsSales>();
        }

        [Column("stor_id", TypeName = "char(4)")]
        public string StorId { get; set; }
        [Column("stor_name", TypeName = "varchar(40)")]
        public string StorName { get; set; }
        [Column("stor_address", TypeName = "varchar(40)")]
        public string StorAddress { get; set; }
        [Column("city", TypeName = "varchar(20)")]
        public string City { get; set; }
        [Column("state", TypeName = "char(2)")]
        public string State { get; set; }
        [Column("zip", TypeName = "char(5)")]
        public string Zip { get; set; }

        [InverseProperty("Stor")]
        public ICollection<PubsSales> PubsSales { get; set; }
    }
}
