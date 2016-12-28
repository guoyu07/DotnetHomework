using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("admin")]
    public class AdminEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}