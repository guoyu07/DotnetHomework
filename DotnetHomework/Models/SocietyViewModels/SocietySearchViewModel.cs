using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietySearchViewModel
    {
        [Display(Name = "名称")]
        public string NameContains { get; set; }

        [Display(Name = "类型")]
        public List<SocietyCategoryEntity> SocietyCategoryEntities { get; set; }

        public int? SelectedCategory { get; set; }

        [Display(Name = "描述")]
        public string DescriptionContains { get; set; }

        public List<VSocietyInfoEntity> VSocietyInfoEntities { get; set; }
    }
}
