using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pubs.Data.Entities;

namespace Pubs.Data.Entities
{
    [Table("pubs_titleauthor")]
    public partial class PubsTitleauthor
    {
        [Column("au_id", TypeName = "id")]
        public string AuId { get; set; }
        [Column("title_id", TypeName = "tid")]
        public string TitleId { get; set; }
        [Column("au_ord")]
        public byte? AuOrd { get; set; }
        [Column("royaltyper")]
        public int? Royaltyper { get; set; }

        [ForeignKey("AuId")]
        [InverseProperty("PubsTitleauthor")]
        public PubsAuthors Au { get; set; }
        [ForeignKey("TitleId")]
        [InverseProperty("PubsTitleauthor")]
        public PubsTitles Title { get; set; }
    }
}
