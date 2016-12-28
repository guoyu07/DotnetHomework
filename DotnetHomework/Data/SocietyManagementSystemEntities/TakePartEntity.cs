using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("take_part")]
    public class TakePartEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user")]
        public int User { get; set; }

        [Column("activity")]
        public int Activity { get; set; }
    }
}