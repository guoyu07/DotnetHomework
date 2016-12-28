using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("society_category")]
    public class SocietyCategoryEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}