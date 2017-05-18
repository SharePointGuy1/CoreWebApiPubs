using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_publishers")]
    public partial class PubsPublishers
    {
        public PubsPublishers()
        {
            PubsEmployee = new HashSet<PubsEmployee>();
            PubsTitles = new HashSet<PubsTitles>();
        }

        [Column("pub_id", TypeName = "char(4)")]
        public string PubId { get; set; }
        [Column("pub_name", TypeName = "varchar(40)")]
        public string PubName { get; set; }
        [Column("city", TypeName = "varchar(20)")]
        public string City { get; set; }
        [Column("state", TypeName = "char(2)")]
        public string State { get; set; }
        [Column("country", TypeName = "varchar(30)")]
        public string Country { get; set; }

        [InverseProperty("Pub")]
        public ICollection<PubsEmployee> PubsEmployee { get; set; }
        [InverseProperty("Pub")]
        public PubsPubInfo PubsPubInfo { get; set; }
        [InverseProperty("Pub")]
        public ICollection<PubsTitles> PubsTitles { get; set; }
    }
}
