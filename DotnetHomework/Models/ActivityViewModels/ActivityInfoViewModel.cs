using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.ActivityViewModels
{
    public class ActivityInfoViewModel
    {
        public VActivityInfoEntity VActivityInfoEntity { get; set; }

        public List<VTakePartInfoEntity> VTakePartInfoEntities { get; set; }

        public bool IsCreator { get; set; }

        public bool IsTakedPart { get; set; }
    }
}
