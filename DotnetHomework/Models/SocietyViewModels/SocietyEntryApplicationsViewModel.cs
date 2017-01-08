using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietyEntryApplicationsViewModel
    {
        public List<VMemberInfoEntity> VMemberInfoEntities { get; set; }

        public VSocietyInfoEntity VSocietyInfoEntity { get; set; }
    }
}