using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("activity")]
    public class ActivityEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("society")]
        public int Society { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("time")]
        public Nullable<DateTime> Time { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}