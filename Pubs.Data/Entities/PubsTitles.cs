using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_titles")]
    public partial class PubsTitles
    {
        public PubsTitles()
        {
            PubsSales = new HashSet<PubsSales>();
            PubsTitleauthor = new HashSet<PubsTitleauthor>();
        }

        [Column("title_id", TypeName = "tid")]
        public string TitleId { get; set; }
        [Required]
        [Column("title", TypeName = "varchar(80)")]
        public string Title { get; set; }
        [Required]
        [Column("type", TypeName = "char(12)")]
        public string Type { get; set; }
        [Column("pub_id", TypeName = "char(4)")]
        public string PubId { get; set; }
        [Column("price", TypeName = "money")]
        public decimal? Price { get; set; }
        [Column("advance", TypeName = "money")]
        public decimal? Advance { get; set; }
        [Column("royalty")]
        public int? Royalty { get; set; }
        [Column("ytd_sales")]
        public int? YtdSales { get; set; }
        [Column("notes", TypeName = "varchar(200)")]
        public string Notes { get; set; }
        [Column("pubdate", TypeName = "datetime")]
        public DateTime Pubdate { get; set; }

        [InverseProperty("Title")]
        public ICollection<PubsSales> PubsSales { get; set; }
        [InverseProperty("Title")]
        public ICollection<PubsTitleauthor> PubsTitleauthor { get; set; }
        [ForeignKey("PubId")]
        [InverseProperty("PubsTitles")]
        public PubsPublishers Pub { get; set; }
    }
}
