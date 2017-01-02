using DotnetHomework.Models.UserCenterViewModels;
using DotnetHomework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetHomework.Controllers
{
    [Authorize]
    public class UserCenterController : Controller
    {
        private readonly UserCenterServices _userCenterServices;

        public UserCenterController(UserCenterServices userCenterServices)
        {
            _userCenterServices = userCenterServices;
        }

        //
        // GET: /UserCenter/Index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new UserCenterIndexViewModel
            {
                AmountOfSocietiesIJoined = _userCenterServices.GetAmountOfJoinedSocieties(HttpContext.User),
                AmountOfSocietiesICreated = _userCenterServices.GetAmountOfCreatedSocieties(HttpContext.User),
                AmountOfActivitiesITakingPart = _userCenterServices.GetAmountOfTakingPartActivities(HttpContext.User),
                AmountOfEntryApplications = _userCenterServices.GetAmountOfEntryApplications(HttpContext.User),
                SocietiesIJoined = _userCenterServices.GetJoinedSocieties(HttpContext.User),
                SocietiesICreated = _userCenterServices.GetCreatedSocieties(HttpContext.User),
                RecentActivities = _userCenterServices.GetRecentActivities(HttpContext.User),
                EntryApplications = _userCenterServices.GetEntryApplications(HttpContext.User)
            };

            return View(model);
        }
    }
}
