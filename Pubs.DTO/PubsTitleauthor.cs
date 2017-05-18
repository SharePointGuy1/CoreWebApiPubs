using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsTitleauthor
    {
        public string AuId { get; set; }
        public string TitleId { get; set; }
        public byte? AuOrd { get; set; }
        public int? Royaltyper { get; set; }

        public virtual PubsAuthors Au { get; set; }
        public virtual PubsTitles Title { get; set; }
    }
}
