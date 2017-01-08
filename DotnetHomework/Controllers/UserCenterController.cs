using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var model = new UserCenterIndexViewModel
            {
                AmountOfSocietiesIJoined = await _userCenterServices.GetAmountOfJoinedSocieties(HttpContext.User),
                AmountOfSocietiesICreated = await _userCenterServices.GetAmountOfCreatedSocieties(HttpContext.User),
                AmountOfActivitiesITakingPart =
                    await _userCenterServices.GetAmountOfTakingPartActivities(HttpContext.User),
                AmountOfEntryApplications = await _userCenterServices.GetAmountOfEntryApplications(HttpContext.User),
                SocietiesIJoined = await _userCenterServices.GetJoinedSocieties(HttpContext.User),
                SocietiesICreated = await _userCenterServices.GetCreatedSocieties(HttpContext.User),
                RecentActivities = await _userCenterServices.GetRecentActivities(HttpContext.User),
                EntryApplications = await _userCenterServices.GetEntryApplications(HttpContext.User)
            };

            return View(model);
        }
    }
}