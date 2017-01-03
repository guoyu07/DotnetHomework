using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                )
                .ToList();
        }

        public static List<VSocietyInfoEntity> FindByCreatorIdAndStatusNotReject(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string creatorId)
        {
            return vSocietyInfoEntities.Where(d =>
                    d.CreatorId.Equals(creatorId) &&
                    d.Status != SocietyDbSetStatusEnum.Reject.ToString()
                )
                .ToList();
        }

        public static async Task<List<VSocietyInfoEntity>> FindTop5ByCreatorIdAndStatusNotRejectAsync(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string creatorId)
        {
            return (await vSocietyInfoEntities.Where(d =>
                        d.CreatorId.Equals(creatorId) &&
                        d.Status != SocietyDbSetStatusEnum.Reject.ToString()
                    )
                    .ToListAsync()).Take(5)
                .ToList();
        }

        public static List<VSocietyInfoEntity> FindByIdIn(this DbSet<VSocietyInfoEntity> vSocietyInfoEntities,
            List<int> ids)
        {
            return vSocietyInfoEntities.Where(d => ids.Contains(d.Id)).ToList();
        }
    }
}