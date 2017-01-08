using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.UserCenterViewModels
{
    public class UserCenterIndexViewModel
    {
        public int AmountOfSocietiesIJoined { get; set; }

        public int AmountOfSocietiesICreated { get; set; }

        public int AmountOfActivitiesITakingPart { get; set; }

        public int AmountOfEntryApplications { get; set; }

        public List<VMemberInfoEntity> SocietiesIJoined { get; set; }

        public List<VSocietyInfoEntity> SocietiesICreated { get; set; }

        public List<VActivityInfoEntity> RecentActivities { get; set; }

        public List<VMemberInfoEntity> EntryApplications { get; set; }
    }
}