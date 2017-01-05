using System.Collections.Generic;
using System.Linq;
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
            if (await _societyManagementSystemDbContext.Member.FindByUserAndSocietyAsync(user,society)!=null)
            {
                return false;
            }

            MemberEntity memberEntity = new MemberEntity
            {
                User = user,
                Society = society,
                EntryPost = entryPost,
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
    }
}