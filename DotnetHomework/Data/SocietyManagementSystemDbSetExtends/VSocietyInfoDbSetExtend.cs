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

        public static async Task<List<VSocietyInfoEntity>> FindTop9AndStatusIsActiveOderByMemberCountDescAsync(
            this DbSet<VSocietyInfoEntity> vSocietyInfoEntities)
        {
            return (await vSocietyInfoEntities.Where(d =>
                        d.Status == SocietyDbSetStatusEnum.Active.ToString())
                    .OrderByDescending(d => d.MemberCount)
                    .ToListAsync()).Take(9)
                .ToList();
        }

        public static async Task<List<VSocietyInfoEntity>>
            FindByNameContainsAndCategoryIdAndDescriptionContainsAndStatusIsActiveAsync(
                this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string name, int categoryId, string description)
        {
            return (await vSocietyInfoEntities.Where(d =>
                        d.CategoryId == categoryId)
                    .ToListAsync()).Where(d =>
                    d.Name.Contains(name) &&
                    d.Description.Contains(description) &&
                    d.Status == SocietyDbSetStatusEnum.Active.ToString())
                .ToList();
        }

        public static async Task<List<VSocietyInfoEntity>>
            FindByNameContainsAndDescriptionContainsAndStatusIsActiveAsync(
                this DbSet<VSocietyInfoEntity> vSocietyInfoEntities, string name, string description)
        {
            return (await vSocietyInfoEntities
                    .ToListAsync()).Where(d =>
                    d.Name.Contains(name) &&
                    d.Description.Contains(description) &&
                    d.Status == SocietyDbSetStatusEnum.Active.ToString())
                .ToList();
        }

        public static async Task<VSocietyInfoEntity> FindByIdAsync(this DbSet<VSocietyInfoEntity> vSocietyInfoEntities,
            int id)
        {
            return await vSocietyInfoEntities.SingleOrDefaultAsync(d => d.Id == id);
        }

        public static async Task<VSocietyInfoEntity> FindByNameAsync(this DbSet<VSocietyInfoEntity> vSocietyInfoEntities,
            string name)
        {
            return await vSocietyInfoEntities.SingleOrDefaultAsync(d => d.Name.Equals(name));
        }
    }
}
