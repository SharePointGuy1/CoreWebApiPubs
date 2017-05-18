using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsTitles
    {
        public PubsTitles()
        {
            PubsSales = new HashSet<PubsSales>();
            PubsTitleauthor = new HashSet<PubsTitleauthor>();
        }

        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }

        public virtual ICollection<PubsSales> PubsSales { get; set; }
        public virtual ICollection<PubsTitleauthor> PubsTitleauthor { get; set; }
        public virtual PubsPublishers Pub { get; set; }
    }
}
