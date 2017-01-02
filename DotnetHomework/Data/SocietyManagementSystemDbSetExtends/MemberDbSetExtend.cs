using System.Collections.Generic;
using System.Linq;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class MemberDbSetExtend
    {
        public static int GetCountByUserAndStatusIsAccept(this DbSet<MemberEntity> memberEntities, string user)
        {
            return memberEntities.Count(d =>
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

        public static List<MemberEntity> FindByUserAndStatusNotPending(this DbSet<MemberEntity> memberEntities,
            string user)
        {
            return memberEntities.Where(d =>
                    d.User.Equals(user) &&
                    d.Status != MemberDbSetStatusEnum.Pending.ToString()
                )
                .ToList();
        }

        public static int GetCountByUserAndStatusIsPending(this DbSet<MemberEntity> memberEntities, string user)
        {
            return memberEntities.Count(d =>
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