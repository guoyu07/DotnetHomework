using System.Collections.Generic;
using System.Linq;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VSocietyInfoDbSetExtend
    {
        public static List<VSocietyInfoEntity> FindByCreatorIdAndStatusIsActive(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string creatorId)
        {
            return vSocietyInfoEntities.Where(d =>
                    d.CreatorId.Equals(creatorId) &&
                    d.Status == ActivityDbSetStatusEnum.Active.ToString()
                ).ToList();
        }

        public static List<VSocietyInfoEntity> FindByCreatorIdAndStatusNotReject(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string creatorId)
        {
            return vSocietyInfoEntities.Where(d =>
                    d.CreatorId.Equals(creatorId) &&
                    d.Status != SocietyDbSetStatusEnum.Reject.ToString()
                ).ToList();
        }

        public static List<VSocietyInfoEntity> FindTop5ByCreatorIdAndStatusNotReject(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string creatorId)
        {
            return vSocietyInfoEntities.Where(d =>
                d.CreatorId.Equals(creatorId) &&
                d.Status != SocietyDbSetStatusEnum.Reject.ToString()
            ).ToList().Take(5).ToList();
        }

        public static List<VSocietyInfoEntity> FindByIdIn(this DbSet<VSocietyInfoEntity> vSocietyInfoEntities,
            List<int> ids)
        {
            return vSocietyInfoEntities.Where(d => ids.Contains(d.Id)).ToList();
        }
    }
}