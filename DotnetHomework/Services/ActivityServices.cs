using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using DotnetHomework.Models.ActivityViewModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<VActivityInfoEntity>> GetAllActivitiesDescAsync(int id)
        {
            return await _societyManagementSystemDbContext.VActivityInfo.FindBySocietyIdOderByCreateTimeDescAsync(id);
        }

        public async Task<VActivityInfoEntity> GetVActivityInfo(int id)
        {
            return await _societyManagementSystemDbContext.VActivityInfo.FindById(id);
        }

        public async Task<bool> CreateActivity(int id, ActivityCreateViewModel activityCreateViewModel)
        {
            ActivityEntity activityEntity = new ActivityEntity
            {
                Society = id,
                Name = activityCreateViewModel.Name,
                Description = activityCreateViewModel.Description,
                Time = activityCreateViewModel.Time,
                CreateTime = DateTime.Now,
                Status = ActivityDbSetStatusEnum.Pending.ToString()
            };
            _societyManagementSystemDbContext.Activity.Add(activityEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }

        public async Task<List<VActivityInfoEntity>> GetPendingActivitiesAsync()
        {
            return await _societyManagementSystemDbContext.VActivityInfo.Where(
                    d => d.Status == ActivityDbSetStatusEnum.Pending.ToString())
                .ToListAsync();
        }

        public async Task<bool> EditActivityStatusAsync(int id, ActivityDbSetStatusEnum activityDbSetStatusEnum)
        {
            ActivityEntity activityEntity =
                await _societyManagementSystemDbContext.Activity.SingleOrDefaultAsync(d => d.Id == id);
            activityEntity.Status = activityDbSetStatusEnum.ToString();
            _societyManagementSystemDbContext.Update(activityEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }

        public enum ActivityCreateResultEnum
        {
            Success
        }
    }
}