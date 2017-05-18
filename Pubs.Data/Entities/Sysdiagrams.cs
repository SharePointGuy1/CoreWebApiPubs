using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pubs.Data.Entities
{
    [Table("sysdiagrams")]
    public partial class Sysdiagrams
    {
        [Required]
        [Column("name", TypeName = "sysname")]
        public string Name { get; set; }
        [Column("principal_id")]
        public int PrincipalId { get; set; }
        [Column("diagram_id")]
        public int DiagramId { get; set; }
        [Column("version")]
        public int? Version { get; set; }
        [Column("definition")]
        public byte[] Definition { get; set; }
    }
}
