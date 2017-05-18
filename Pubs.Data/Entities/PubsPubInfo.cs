using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_pub_info")]
    public partial class PubsPubInfo
    {
        [Column("pub_id", TypeName = "char(4)")]
        public string PubId { get; set; }
        [Column("logo", TypeName = "image")]
        public byte[] Logo { get; set; }
        [Column("pr_info", TypeName = "text")]
        public string PrInfo { get; set; }

        [ForeignKey("PubId")]
        [InverseProperty("PubsPubInfo")]
        public PubsPublishers Pub { get; set; }
    }
}
