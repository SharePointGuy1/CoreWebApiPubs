using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsPublishers
    {
        public PubsPublishers()
        {
            PubsEmployee = new HashSet<PubsEmployee>();
            PubsTitles = new HashSet<PubsTitles>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<PubsEmployee> PubsEmployee { get; set; }
        public virtual PubsPubInfo PubsPubInfo { get; set; }
        public virtual ICollection<PubsTitles> PubsTitles { get; set; }
    }
}
