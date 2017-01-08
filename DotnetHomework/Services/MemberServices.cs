using System.Threading.Tasks;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Services
{
    public class MemberServices
    {
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public MemberServices(SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public async Task<bool> EditStatusAsync(int id, MemberDbSetStatusEnum memberDbSetStatusEnum)
        {
            MemberEntity memberEntity = await _societyManagementSystemDbContext.Member.FindById(id);
            memberEntity.Status = memberDbSetStatusEnum.ToString();
            _societyManagementSystemDbContext.Member.Update(memberEntity);
            return await _societyManagementSystemDbContext.SaveChangesAsync() != 0;
        }
    }
}