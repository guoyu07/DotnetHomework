using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VMemberInfoDbSetExtend
    {
        public static List<VMemberInfoEntity> FindByUserIdAndStatusIsAccept(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return vMemberInfoEntities.Where(d =>
                    d.UserId.Equals(userId) &&
                    d.Status == MemberDbSetStatusEnum.Accept.ToString())
                .ToList();
        }

        public static async Task<List<VMemberInfoEntity>> FindTop5ByUserIdAndStatusIsAccept(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return (await vMemberInfoEntities.Where(d =>
                        d.UserId.Equals(userId) &&
                        d.Status == MemberDbSetStatusEnum.Accept.ToString())
                    .ToListAsync()).Take(5)
                .ToList();
        }

        public static List<VMemberInfoEntity> FindByUserIdAndStatusIsPending(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return vMemberInfoEntities.Where(d =>
                    d.UserId.Equals(userId) &&
                    d.Status == MemberDbSetStatusEnum.Pending.ToString())
                .ToList();
        }

        public static async Task<List<VMemberInfoEntity>> FindTop5ByUserIdAndStatusIsPendingAsync(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return (await vMemberInfoEntities.Where(d =>
                        d.UserId.Equals(userId) &&
                        d.Status == MemberDbSetStatusEnum.Pending.ToString())
                    .ToListAsync())
                .Take(5)
                .ToList();
        }
    }
}