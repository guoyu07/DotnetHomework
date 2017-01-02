using System.Collections.Generic;
using System.Linq;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VTakePartInfoDbSetExtend
    {
        public static int GetCountByUserIdAndActivityStatusIsActive(
            this DbSet<VTakePartInfoEntity> vTakePartInfoEntities, string user)
        {
            return vTakePartInfoEntities.Count(d =>
                d.UserId.Equals(user) &&
                d.ActivityStatus == ActivityDbSetStatusEnum.Active.ToString()
            );
        }

        public static List<VTakePartInfoEntity> FindByUserId(this DbSet<VTakePartInfoEntity> vTakePartInfoEntities,
            string userId)
        {
            return vTakePartInfoEntities.Where(d => d.UserId.Equals(userId)).ToList();
        }
    }
}