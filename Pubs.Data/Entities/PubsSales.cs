using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_sales")]
    public partial class PubsSales
    {
        [Column("stor_id", TypeName = "char(4)")]
        public string StorId { get; set; }
        [Column("ord_num", TypeName = "varchar(20)")]
        public string OrdNum { get; set; }
        [Column("ord_date", TypeName = "datetime")]
        public DateTime OrdDate { get; set; }
        [Column("qty")]
        public short Qty { get; set; }
        [Required]
        [Column("payterms", TypeName = "varchar(12)")]
        public string Payterms { get; set; }
        [Column("title_id", TypeName = "tid")]
        public string TitleId { get; set; }

        [ForeignKey("StorId")]
        [InverseProperty("PubsSales")]
        public PubsStores Stor { get; set; }
        [ForeignKey("TitleId")]
        [InverseProperty("PubsSales")]
        public PubsTitles Title { get; set; }
    }
}
