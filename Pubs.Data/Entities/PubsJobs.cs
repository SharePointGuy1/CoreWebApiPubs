using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_jobs")]
    public partial class PubsJobs
    {
        public PubsJobs()
        {
            PubsEmployee = new HashSet<PubsEmployee>();
        }

        [Column("job_id")]
        public short JobId { get; set; }
        [Required]
        [Column("job_desc", TypeName = "varchar(50)")]
        public string JobDesc { get; set; }
        [Column("min_lvl")]
        public byte MinLvl { get; set; }
        [Column("max_lvl")]
        public byte MaxLvl { get; set; }

        [InverseProperty("Job")]
        public ICollection<PubsEmployee> PubsEmployee { get; set; }
    }
}
