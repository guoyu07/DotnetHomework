using System.Linq;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class UserDbSetExtend
    {
        public static UserEntity FindByUsername(this DbSet<UserEntity> user, string username)
        {
            return user.SingleOrDefault(d => d.Username.Equals(username));
        }
    }
}