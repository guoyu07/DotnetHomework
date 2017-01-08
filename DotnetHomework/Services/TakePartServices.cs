using System;
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
            return await _societyManagementSystemDbContext.VTakePartInfo.FindByActivityIdAsync(societyId);
        }

        public async Task<bool> IsTakedPart(string user, int id)
        {
            return await _societyManagementSystemDbContext.VTakePartInfo.FindByUserIdAndActivityIdAsync(user, id) !=
                   null;
        }

        public async Task<bool> TakePart(string user, int id)
        {
            if (await IsTakedPart(user, id))
            {
                return false;
            }

            TakePartEntity takePartEntity = new TakePartEntity
            {
                User = user,
                Activity = id,
                Time = DateTime.Now
            };
            _societyManagementSystemDbContext.TakePart.Add(takePartEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }
    }
}