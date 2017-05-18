using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsSales
    {
        public string StorId { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
        public string TitleId { get; set; }

        public virtual PubsStores Stor { get; set; }
        public virtual PubsTitles Title { get; set; }
    }
}
