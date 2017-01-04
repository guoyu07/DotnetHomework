using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class SocietyDbSetExtend
    {
        public static async Task<int> GetCountByCreatorAndStatusIsActiveAsync(this DbSet<SocietyEntity> societyEntities,
            string creator)
        {
            return await societyEntities.CountAsync(d =>
                d.Creator.Equals(creator) &&
                d.Status == SocietyDbSetStatusEnum.Active.ToString()
            );
        }

        public static List<SocietyEntity> FindByCreator(this DbSet<SocietyEntity> societyEntities, string creator)
        {
            return societyEntities.Where(d => d.Creator.Equals(creator)).ToList();
        }

        public static async Task<List<SocietyEntity>> FindByCreatorAndStatusIsActiveAysnc(
            this DbSet<SocietyEntity> societyEntities,
            string creator)
        {
            return await societyEntities.Where(d =>
                    d.Creator.Equals(creator) &&
                    d.Status == SocietyDbSetStatusEnum.Active.ToString()
                )
                .ToListAsync();
        }

        public static async Task<int> GetCountAndStatusIsActiveAsync(this DbSet<SocietyEntity> societyEntities)
        {
            return await societyEntities.CountAsync(d => d.Status == SocietyDbSetStatusEnum.Active.ToString());
        }
    }

    public enum SocietyDbSetStatusEnum
    {
        Pending,
        Active,
        Reject
    }
}