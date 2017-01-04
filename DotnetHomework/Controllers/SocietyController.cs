using System.Linq;
using System.Threading.Tasks;
using DotnetHomework.Models;
using DotnetHomework.Models.SocietyViewModels;
using DotnetHomework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetHomework.Controllers
{
    [Authorize]
    public class SocietyController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SocietyServices _societyServices;
        private readonly ActivityServices _activityServices;

        public SocietyController(UserManager<ApplicationUser> userManager, SocietyServices societyServices, ActivityServices activityServices)
        {
            _userManager = userManager;
            _societyServices = societyServices;
            _activityServices = activityServices;
        }

        //
        // GET: /Society/Index
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            SystemInfoOverviewViewModel systemInfoOverviewViewModel = new SystemInfoOverviewViewModel
            {
                CountOfSocieties = await _societyServices.GetCountOfAvailableSocietiesAsync(),
                CountOfActivities = await _activityServices.GetCountOfAvailableAvtivitiesAsync(),
                CountOfUsers = await _userManager.Users.CountAsync()
            };

            SocietyIndexViewModel societyIndexViewModel = new SocietyIndexViewModel
            {
                SystemInfoOverviewViewModel = systemInfoOverviewViewModel,
                VSocietyInfoEntities = await _societyServices.GetTop9MostPopularSocieties()
            };

            return View(societyIndexViewModel);
        }
    }
}
