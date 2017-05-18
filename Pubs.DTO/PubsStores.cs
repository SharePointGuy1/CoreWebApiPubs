using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsStores
    {
        public PubsStores()
        {
            PubsSales = new HashSet<PubsSales>();
        }

        public string StorId { get; set; }
        public string StorName { get; set; }
        public string StorAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<PubsSales> PubsSales { get; set; }
    }
}
