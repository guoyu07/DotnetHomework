﻿using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;

namespace DotnetHomework.Services
{
    public class ActivityServices
    {
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public ActivityServices(SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public async Task<int> GetCountOfAvailableAvtivitiesAsync()
        {
            return await _societyManagementSystemDbContext.Activity.GetCountAndStatusIsActiveOrStatusIsClosedAsync();
        }
    }
}