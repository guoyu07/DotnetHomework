using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data.SocietyManagementSystemDbSetExtends
{
    public static class ActivityDbSetExtend
    {
        public static async Task<int> GetCountAndStatusIsActiveOrStatusIsClosedAsync(
            this DbSet<ActivityEntity> activityEntities)
        {
            return await activityEntities.CountAsync(d =>
                d.Status == ActivityDbSetStatusEnum.Active.ToString() ||
                d.Status == ActivityDbSetStatusEnum.Closed.ToString());
        }
    }

    public enum ActivityDbSetStatusEnum
    {
        Pending,
        Active,
        Closed,
        Reject
    }
}