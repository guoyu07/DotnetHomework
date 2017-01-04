using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietyIndexViewModel
    {
        public SystemInfoOverviewViewModel SystemInfoOverviewViewModel { get; set; }

        public List<VSocietyInfoEntity> VSocietyInfoEntities { get; set; }
    }
}