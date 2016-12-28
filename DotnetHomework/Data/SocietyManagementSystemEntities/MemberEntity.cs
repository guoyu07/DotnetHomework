using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("member")]
    public class MemberEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user")]
        public int User { get; set; }

        [Column("society")]
        public int Society { get; set; }
    }
}