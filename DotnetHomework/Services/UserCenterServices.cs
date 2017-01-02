using System.Collections.Generic;
using System.Security.Claims;
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

        public int GetAmountOfJoinedSocieties(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.Member.GetCountByUserAndStatusIsAccept(
                _userManager.GetUserId(user));
        }

        public int GetAmountOfCreatedSocieties(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.Society.GetCountByCreatorAndStatusIsActive(
                _userManager.GetUserId(user));
        }

        public int GetAmountOfTakingPartActivities(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.VTakePartInfo.GetCountByUserIdAndActivityStatusIsActive(
                _userManager.GetUserId(user));
        }

        public int GetAmountOfEntryApplications(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.Member.GetCountByUserAndStatusIsPending(_userManager.GetUserId(user));
        }

        public List<VMemberInfoEntity> GetJoinedSocieties(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.VMemberInfo.FindTop5ByUserIdAndStatusIsAccept(
                _userManager.GetUserId(user));
        }

        public List<VSocietyInfoEntity> GetCreatedSocieties(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.VSocietyInfo.FindTop5ByCreatorIdAndStatusNotReject(_userManager
                .GetUserId(user));
        }

        public List<VActivityInfoEntity> GetRecentActivities(ClaimsPrincipal user)
        {
            List<int> societies = new List<int>();
            //我创建的社团
            _societyManagementSystemDbContext.Society.FindByCreatorAndStatusNotPending(_userManager.GetUserId(user))
                .ForEach(societyEntity => { societies.Add(societyEntity.Id); });
            //我加入的社团
            _societyManagementSystemDbContext.Member.FindByUserAndStatusNotPending(_userManager.GetUserId(user))
                .ForEach(memberEntity => { societies.Add(memberEntity.Society); });

            return _societyManagementSystemDbContext.VActivityInfo.FindTop5BySocietyIdInAndStatusNotPendingOderByCreateTimeDesc(societies);
        }

        public List<VMemberInfoEntity> GetEntryApplications(ClaimsPrincipal user)
        {
            return _societyManagementSystemDbContext.VMemberInfo.FindTop5ByUserIdAndStatusIsPending(
                _userManager.GetUserId(user));
        }
    }
}