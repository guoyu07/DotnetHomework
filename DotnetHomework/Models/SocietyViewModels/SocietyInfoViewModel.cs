using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietyInfoViewModel
    {
        public VSocietyInfoEntity VSocietyInfoEntity { get; set; }

        public bool IsPending { get; set; }

        public bool IsCreator { get; set; }

        public bool IsJoined { get; set; }

        public List<VMemberInfoEntity> VMemberInfoEntities { get; set; }

        public string Post { get; set; }
    }
}