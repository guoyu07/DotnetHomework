using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using DotnetHomework.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetHomework.Services
{
    public class UserCenterServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public UserCenterServices(UserManager<ApplicationUser> userManager,
            SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _userManager = userManager;
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public async Task<int> GetAmountOfJoinedSocieties(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.Member.GetCountByUserAndStatusIsAcceptAsync(
                _userManager.GetUserId(user));
        }

        public async Task<int> GetAmountOfCreatedSocieties(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.Society.GetCountByCreatorAndStatusIsActiveAsync(
                _userManager.GetUserId(user));
        }

        public async Task<int> GetAmountOfTakingPartActivities(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.VTakePartInfo.GetCountByUserIdAndActivityStatusIsActiveAsync(
                _userManager.GetUserId(user));
        }

        public async Task<int> GetAmountOfEntryApplications(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.Member.GetCountByUserAndStatusIsPendingAsync(_userManager
                .GetUserId(user));
        }

        public async Task<List<VMemberInfoEntity>> GetJoinedSocieties(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.VMemberInfo.FindTop5ByUserIdAndStatusIsAccept(
                _userManager.GetUserId(user));
        }

        public async Task<List<VSocietyInfoEntity>> GetCreatedSocieties(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.VSocietyInfo.FindTop5ByCreatorIdAndStatusNotRejectAsync(
                _userManager
                    .GetUserId(user));
        }

        public async Task<List<VActivityInfoEntity>> GetRecentActivities(ClaimsPrincipal user)
        {
            List<int> societies = new List<int>();
            //我创建的社团
            (await _societyManagementSystemDbContext.Society.FindByCreatorAndStatusIsActiveAysnc(_userManager
                    .GetUserId(user)))
                .ForEach(societyEntity => { societies.Add(societyEntity.Id); });
            //我加入的社团
            (await _societyManagementSystemDbContext.Member.FindByUserAndStatusIsAcceptAysnc(
                    _userManager.GetUserId(user)))
                .ForEach(memberEntity => { societies.Add(memberEntity.Society); });

            //返回状态为 Active 或 Closed 的活动
            return await _societyManagementSystemDbContext.VActivityInfo
                .FindTop5BySocietyIdInAndStatusIsActiveOrStatusIsClosedOderByCreateTimeDescAsync(societies);
        }

        public async Task<List<VMemberInfoEntity>> GetEntryApplications(ClaimsPrincipal user)
        {
            return await _societyManagementSystemDbContext.VMemberInfo.FindTop5ByUserIdAndStatusIsPendingAsync(
                _userManager.GetUserId(user));
        }
    }
}