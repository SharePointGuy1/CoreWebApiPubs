using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsEmployee
    {
        public string EmpId { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public short JobId { get; set; }
        public byte? JobLvl { get; set; }
        public string PubId { get; set; }
        public DateTime HireDate { get; set; }

        public virtual PubsJobs Job { get; set; }
        public virtual PubsPublishers Pub { get; set; }
    }
}
