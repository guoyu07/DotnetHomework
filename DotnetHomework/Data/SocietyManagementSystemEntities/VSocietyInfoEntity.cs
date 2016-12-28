using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("v_society_info")]
    public class VSocietyInfoEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("creator_id")]
        public int CreatorId { get; set; }

        [Column("creator_name")]
        public string CreatorName { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}