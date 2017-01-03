using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class MemberDbSetExtend
    {
        public static async Task<int> GetCountByUserAndStatusIsAcceptAsync(this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return await memberEntities.CountAsync(d =>
                d.User.Equals(user) &&
                d.Status == MemberDbSetStatusEnum.Accept.ToString()
            );
        }

        public static List<MemberEntity> FindByUserAndStatusIsAccept(this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return memberEntities.Where(d =>
                    d.User.Equals(user) &&
                    d.Status == MemberDbSetStatusEnum.Accept.ToString()
                )
                .ToList();
        }

        public static async Task<List<MemberEntity>> FindByUserAndStatusNotPendingAysnc(
            this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return await memberEntities.Where(d =>
                    d.User.Equals(user) &&
                    d.Status != MemberDbSetStatusEnum.Pending.ToString()
                )
                .ToListAsync();
        }

        public static async Task<int> GetCountByUserAndStatusIsPendingAsync(this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return await memberEntities.CountAsync(d =>
                d.User.Equals(user) &&
                d.Status == MemberDbSetStatusEnum.Pending.ToString()
            );
        }
    }

    public enum MemberDbSetStatusEnum
    {
        Pending,
        Accept
    }
}