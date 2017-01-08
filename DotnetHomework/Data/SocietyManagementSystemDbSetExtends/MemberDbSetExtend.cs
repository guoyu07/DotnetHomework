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

        public static async Task<List<MemberEntity>> FindByUserAndStatusIsAcceptAysnc(
            this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return await memberEntities.Where(d =>
                    d.User.Equals(user) &&
                    d.Status == MemberDbSetStatusEnum.Accept.ToString()
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

        public static async Task<MemberEntity> FindByUserAndSocietyAsync(this DbSet<MemberEntity> memberEntities,
            string user, int society)
        {
            return await memberEntities.SingleOrDefaultAsync(d =>
                d.User.Equals(user) &&
                d.Society == society);
        }

        public static async Task<MemberEntity> FindById(this DbSet<MemberEntity> memberEntities, int id)
        {
            return await memberEntities.SingleOrDefaultAsync(d => d.Id == id);
        }
    }

    public enum MemberDbSetStatusEnum
    {
        Pending,
        Accept,
        Reject
    }
}