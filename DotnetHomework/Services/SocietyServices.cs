using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using DotnetHomework.Models.SocietyViewModels;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Services
{
    public class SocietyServices
    {
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public SocietyServices(SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public async Task<int> GetCountOfAvailableSocietiesAsync()
        {
            return await _societyManagementSystemDbContext.Society.GetCountAndStatusIsActiveAsync();
        }

        public async Task<List<VSocietyInfoEntity>> GetTop9MostPopularSocieties()
        {
            return await _societyManagementSystemDbContext.VSocietyInfo
                .FindTop9AndStatusIsActiveOderByMemberCountDescAsync();
        }

        public async Task<List<SocietyCategoryEntity>> GetSocietyCategoriesAsync()
        {
            return await _societyManagementSystemDbContext.SocietyCategory.ToListAsync();
        }

        public async Task<List<VSocietyInfoEntity>> SearchSocieties(SocietySearchViewModel societySearchViewModel)
        {
            if (societySearchViewModel.NameContains == null)
            {
                societySearchViewModel.NameContains = "";
            }
            if (societySearchViewModel.DescriptionContains == null)
            {
                societySearchViewModel.DescriptionContains = "";
            }

            if (societySearchViewModel.SelectedCategory == null)
            {
                return await _societyManagementSystemDbContext.VSocietyInfo
                    .FindByNameContainsAndDescriptionContainsAndStatusIsActiveAsync(societySearchViewModel.NameContains,
                        societySearchViewModel.DescriptionContains);
            }
            return await _societyManagementSystemDbContext.VSocietyInfo
                .FindByNameContainsAndCategoryIdAndDescriptionContainsAndStatusIsActiveAsync(
                    societySearchViewModel.NameContains,
                    (int) societySearchViewModel.SelectedCategory, societySearchViewModel.DescriptionContains);
        }

        public async Task<VSocietyInfoEntity> GetVSocietyInfoEntityByIdAsync(int id)
        {
            return await _societyManagementSystemDbContext.VSocietyInfo.FindByIdAsync(id);
        }

        public async Task<bool> IsPending(string user, int society)
        {
            return await _societyManagementSystemDbContext.Member.SingleOrDefaultAsync(
                       d => d.User.Equals(user) && d.Society == society &&
                            d.Status == MemberDbSetStatusEnum.Pending.ToString()) != null;
        }

        public async Task<bool> IsJoined(string user, int society)
        {
            return await _societyManagementSystemDbContext.Member.SingleOrDefaultAsync(
                       d => d.User.Equals(user) && d.Society == society &&
                            d.Status == MemberDbSetStatusEnum.Accept.ToString()) != null;
        }

        public async Task<bool> IsCreator(string user, int society)
        {
            return await _societyManagementSystemDbContext.Society.SingleOrDefaultAsync(
                       d => d.Id == society && d.Creator.Equals(user) &&
                            d.Status == SocietyDbSetStatusEnum.Active.ToString()) != null;
        }

        public async Task<List<VMemberInfoEntity>> GetAvailableMembersAsync(int society)
        {
            return await _societyManagementSystemDbContext.VMemberInfo.FindBySocietyIdAndStatusIsAccept(society);
        }

        public async Task<bool> JoinSociety(string user, int society, string entryPost)
        {
            if (await _societyManagementSystemDbContext.Member.FindByUserAndSocietyAsync(user, society) != null)
            {
                return false;
            }

            MemberEntity memberEntity = new MemberEntity
            {
                User = user,
                Society = society,
                EntryPost = entryPost,
                EntryTime = DateTime.Now,
                Status = MemberDbSetStatusEnum.Pending.ToString()
            };
            _societyManagementSystemDbContext.Member.Add(memberEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }

        public async Task<string> GetEntryPost(string user, int society)
        {
            return (await _societyManagementSystemDbContext.Member.SingleOrDefaultAsync(
                d => d.User.Equals(user) && d.Society == society)).EntryPost;
        }

        public async Task<SocietyCreateResultEnum> CreateSociety(string user,
            SocietyCreateViewModel societyCreateViewModel)
        {
            if (await _societyManagementSystemDbContext.VSocietyInfo.FindByNameAsync(societyCreateViewModel.Name) !=
                null)
            {
                return SocietyCreateResultEnum.AlreadyExists;
            }

            SocietyEntity societyEntity = new SocietyEntity
            {
                Name = societyCreateViewModel.Name,
                Category = societyCreateViewModel.Category,
                Description = societyCreateViewModel.Description,
                Creator = user,
                CreateTime = DateTime.Now,
                Status = SocietyDbSetStatusEnum.Pending.ToString()
            };
            _societyManagementSystemDbContext.Society.Add(societyEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0
                ? SocietyCreateResultEnum.Success
                : SocietyCreateResultEnum.AlreadyExists;
        }

        public async Task<VSocietyInfoEntity> GetVSocietyInfo(int id)
        {
            return await _societyManagementSystemDbContext.VSocietyInfo.FindByIdAsync(id);
        }

        public async Task<bool> EditSocietyDescription(int id, string description)
        {
            SocietyEntity societyEntity = await _societyManagementSystemDbContext.Society.FindById(id);
            societyEntity.Description = description;
            _societyManagementSystemDbContext.Society.Update(societyEntity);

            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }
    }

    public enum SocietyCreateResultEnum
    {
        Success,
        AlreadyExists
    }
}