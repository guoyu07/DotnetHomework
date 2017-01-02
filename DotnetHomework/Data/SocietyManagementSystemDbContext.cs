using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Data
{
    public class SocietyManagementSystemDbContext : DbContext
    {
        public SocietyManagementSystemDbContext(DbContextOptions<SocietyManagementSystemDbContext> options) : base(
            options)
        {
        }

        public virtual DbSet<ActivityEntity> Activity { get; set; }
        public virtual DbSet<MemberEntity> Member { get; set; }
        public virtual DbSet<SocietyEntity> Society { get; set; }
        public virtual DbSet<SocietyCategoryEntity> SocietyCategory { get; set; }
        public virtual DbSet<TakePartEntity> TakePart { get; set; }

        public virtual DbSet<VSocietyInfoEntity> VSocietyInfo { get; set; }
        public virtual DbSet<VActivityInfoEntity> VActivityInfo { get; set; }
        public virtual DbSet<VMemberInfoEntity> VMemberInfo { get; set; }
        public virtual DbSet<VTakePartInfoEntity> VTakePartInfo { get; set; }
    }
}