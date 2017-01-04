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
            if (societySearchViewModel.NameContains==null)
            {
                societySearchViewModel.NameContains = "";
            }
            if (societySearchViewModel.DescriptionContains==null)
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
                .FindByNameContainsAndCategoryIdAndDescriptionContainsAndStatusIsActiveAsync(societySearchViewModel.NameContains,
                    (int) societySearchViewModel.SelectedCategory, societySearchViewModel.DescriptionContains);
        }

        public async Task<VSocietyInfoEntity> GetVSocietyInfoEntityByIdAsync(int id)
        {
            return await _societyManagementSystemDbContext.VSocietyInfo.FindByIdAsync(id);
        }
    }
}
