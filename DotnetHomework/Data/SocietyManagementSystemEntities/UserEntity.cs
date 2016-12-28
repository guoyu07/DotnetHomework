using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetHomework.Data.SocietyManagementSystemEntities
{
    [Table("user")]
    public class UserEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}