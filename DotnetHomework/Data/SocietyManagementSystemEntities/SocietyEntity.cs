using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("society")]
    public class SocietyEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("category")]
        public int Category { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("creator")]
        public int Creator { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}