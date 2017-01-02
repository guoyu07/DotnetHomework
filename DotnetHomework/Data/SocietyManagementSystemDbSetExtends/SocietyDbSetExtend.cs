using System.Collections.Generic;
using System.Linq;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class SocietyDbSetExtend
    {
        public static int GetCountByCreatorAndStatusIsActive(this DbSet<SocietyEntity> societyEntities, string creator)
        {
            return societyEntities.Count(d =>
                d.Creator.Equals(creator) &&
                d.Status == SocietyDbSetStatusEnum.Active.ToString()
            );
        }

        public static List<SocietyEntity> FindByCreator(this DbSet<SocietyEntity> societyEntities, string creator)
        {
            return societyEntities.Where(d => d.Creator.Equals(creator)).ToList();
        }

        public static List<SocietyEntity> FindByCreatorAndStatusNotPending(this DbSet<SocietyEntity> societyEntities,
            string creator)
        {
            return societyEntities.Where(d =>
                    d.Creator.Equals(creator) &&
                    d.Status != SocietyDbSetStatusEnum.Pending.ToString()
                )
                .ToList();
        }
    }

    public enum SocietyDbSetStatusEnum
    {
        Pending,
        Active,
        Reject
    }
}