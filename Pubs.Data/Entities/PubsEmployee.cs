using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("pubs_employee")]
    public partial class PubsEmployee
    {
        [Column("emp_id", TypeName = "empid")]
        public string EmpId { get; set; }
        [Required]
        [Column("fname", TypeName = "varchar(20)")]
        public string Fname { get; set; }
        [Column("minit", TypeName = "char(1)")]
        public string Minit { get; set; }
        [Required]
        [Column("lname", TypeName = "varchar(30)")]
        public string Lname { get; set; }
        [Column("job_id")]
        public short JobId { get; set; }
        [Column("job_lvl")]
        public byte? JobLvl { get; set; }
        [Required]
        [Column("pub_id", TypeName = "char(4)")]
        public string PubId { get; set; }
        [Column("hire_date", TypeName = "datetime")]
        public DateTime HireDate { get; set; }

        [ForeignKey("JobId")]
        [InverseProperty("PubsEmployee")]
        public PubsJobs Job { get; set; }
        [ForeignKey("PubId")]
        [InverseProperty("PubsEmployee")]
        public PubsPublishers Pub { get; set; }
    }
}
