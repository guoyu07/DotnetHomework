﻿using System.Collections.Generic;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietyManageViewModel
    {
        public VSocietyInfoEntity VSocietyInfoEntity { get; set; }

        public List<VMemberInfoEntity> VMemberInfoEntities { get; set; }

        public List<VActivityInfoEntity> VActivityInfoEntities { get; set; }
    }
}
