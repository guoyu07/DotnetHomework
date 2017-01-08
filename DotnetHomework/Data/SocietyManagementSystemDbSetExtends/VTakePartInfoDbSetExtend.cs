using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VTakePartInfoDbSetExtend
    {
        public static async Task<int> GetCountByUserIdAndActivityStatusIsActiveAsync(
            this DbSet<VTakePartInfoEntity> vTakePartInfoEntities, string user)
        {
            return await vTakePartInfoEntities.CountAsync(d =>
                d.UserId.Equals(user) &&
                d.ActivityStatus == ActivityDbSetStatusEnum.Active.ToString()
            );
        }

        public static List<VTakePartInfoEntity> FindByUserId(this DbSet<VTakePartInfoEntity> vTakePartInfoEntities,
            string userId)
        {
            return vTakePartInfoEntities.Where(d => d.UserId.Equals(userId)).ToList();
        }

        public static async Task<List<VTakePartInfoEntity>> FindByActivityIdAsync(
            this DbSet<VTakePartInfoEntity> vTakePartInfoEntities,
            int activityId)
        {
            return await vTakePartInfoEntities.Where(d => d.ActivityId == activityId).ToListAsync();
        }

        public static async Task<VTakePartInfoEntity> FindByUserIdAndActivityIdAsync(
            this DbSet<VTakePartInfoEntity> vTakePartInfoEntities, string userid, int activityId)
        {
            return await vTakePartInfoEntities.SingleOrDefaultAsync(d =>
                d.UserId.Equals(userid) &&
                d.ActivityId == activityId);
        }
    }
}