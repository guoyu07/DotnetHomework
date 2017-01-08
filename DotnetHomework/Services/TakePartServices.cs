using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Services
{
    public class TakePartServices
    {
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public TakePartServices(SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public async Task<List<VTakePartInfoEntity>> GetParticipatorsAsync(int societyId)
        {
            return await _societyManagementSystemDbContext.VTakePartInfo.FindBySocietyIdAsync(societyId);
        }

        public async Task<bool> IsTakedPart(string user, int id)
        {
            return await _societyManagementSystemDbContext.VTakePartInfo.FindByUserIdAndId(user, id) != null;
        }
    }
}