using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<VMemberInfoEntity> FindTop5ByUserIdAndStatusIsAccept(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return vMemberInfoEntities.Where(d =>
                    d.UserId.Equals(userId) &&
                    d.Status == MemberDbSetStatusEnum.Accept.ToString())
                .ToList()
                .Take(5)
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

        public static List<VMemberInfoEntity> FindTop5ByUserIdAndStatusIsPending(
            this DbSet<VMemberInfoEntity> vMemberInfoEntities,
            string userId)
        {
            return vMemberInfoEntities.Where(d =>
                    d.UserId.Equals(userId) &&
                    d.Status == MemberDbSetStatusEnum.Pending.ToString())
                .ToList()
                .Take(5)
                .ToList();
        }
    }
}