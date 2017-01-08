using System;
using System.ComponentModel.DataAnnotations;
using DotnetHomework.Data.SocietyManagementSystemEntities;

namespace DotnetHomework.Models.ActivityViewModels
{
    public class ActivityCreateViewModel
    {
        public VSocietyInfoEntity VSocietyInfoEntity { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [Display(Name = "活动名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "描述不能为空")]
        [Display(Name = "活动描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "必须指定时间")]
        [Display(Name = "活动时间")]
        public DateTime Time { get; set; }
    }
}