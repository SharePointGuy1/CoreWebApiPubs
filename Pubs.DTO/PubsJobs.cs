using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsJobs
    {
        public PubsJobs()
        {
            PubsEmployee = new HashSet<PubsEmployee>();
        }

        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }

        public virtual ICollection<PubsEmployee> PubsEmployee { get; set; }
    }
}
