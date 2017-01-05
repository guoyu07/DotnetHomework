using System.ComponentModel.DataAnnotations;

namespace DotnetHomework.Models.SocietyViewModels
{
    public class SocietyCreateViewModel
    {
        [Required(ErrorMessage = "社团名不能为空")]
        [Display(Name = "社团名")]
        public string Name { get; set; }

        [Display(Name = "社团种类")]
        public int Category { get; set; }

        [Required(ErrorMessage = "详细描述不可为空")]
        [Display(Name = "详细描述")]
        public string Description { get; set; }
    }
}