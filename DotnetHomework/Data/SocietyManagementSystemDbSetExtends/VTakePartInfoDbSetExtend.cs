using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class VTakePartInfoDbSetExtend
    {
        public static async Task<int>  GetCountByUserIdAndActivityStatusIsActiveAsync(
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
    }
}