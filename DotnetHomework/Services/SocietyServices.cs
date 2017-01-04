using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;

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
            return await _societyManagementSystemDbContext.VSocietyInfo.FindTop9AndStatusIsActiveOderByMemberCountDescAsync();
        }
    }
}
