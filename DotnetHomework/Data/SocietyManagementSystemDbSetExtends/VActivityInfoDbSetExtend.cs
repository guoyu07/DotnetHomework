using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VActivityInfoDbSetExtend
    {
        public static List<VActivityInfoEntity> FindBySocietyIdInAndStatusNotPendingOderByCreateTimeDesc(
            this DbSet<VActivityInfoEntity> vActivityInfoEntities,
            List<int> societyIds)
        {
            return vActivityInfoEntities.Where(d =>
                    societyIds.Contains(d.SocietyId) &&
                    d.Status != ActivityDbSetStatusEnum.Pending.ToString())
                .OrderByDescending(d => d.CreateTime)
                .ToList();
        }

        public static async Task<List<VActivityInfoEntity>>
            FindTop5BySocietyIdInAndStatusIsActiveOrStatusIsClosedOderByCreateTimeDescAsync(
                this DbSet<VActivityInfoEntity> vActivityInfoEntities,
                List<int> societyIds)
        {
            return (await vActivityInfoEntities.Where(d =>
                        societyIds.Contains(d.SocietyId) &&
                        (d.Status == ActivityDbSetStatusEnum.Active.ToString() ||
                         d.Status == ActivityDbSetStatusEnum.Closed.ToString()))
                    .OrderByDescending(d => d.CreateTime)
                    .ToListAsync())
                .Take(5)
                .ToList();
        }

        public static async Task<List<VActivityInfoEntity>> FindBySocietyIdOderByCreateTimeDescAsync(
            this DbSet<VActivityInfoEntity> vActivityInfoEntities, int societyId)
        {
            return await vActivityInfoEntities.Where(d => d.SocietyId == societyId)
                .OrderByDescending(d => d.CreateTime)
                .ToListAsync();
        }

        public static async Task<VActivityInfoEntity> FindById(
            this DbSet<VActivityInfoEntity> vActivityInfoEntities, int id)
        {
            return await vActivityInfoEntities.SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}