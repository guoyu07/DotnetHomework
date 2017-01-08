using System.Threading.Tasks;
using DotnetHomework.Models;
using DotnetHomework.Models.ActivityViewModels;
using DotnetHomework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetHomework.Controllers
{
    [Authorize]
    public class ActivityController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ActivityServices _activityServices;
        private readonly TakePartServices _takePartServices;
        private readonly SocietyServices _societyServices;

        public ActivityController(UserManager<ApplicationUser> userManager, ActivityServices activityServices, TakePartServices takePartServices, SocietyServices societyServices)
        {
            _userManager = userManager;
            _activityServices = activityServices;
            _takePartServices = takePartServices;
            _societyServices = societyServices;
        }

        //
        // GET: /Activity/Info/{id}
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Info(int id)
        {
            ActivityInfoViewModel activityInfoViewModel = new ActivityInfoViewModel
            {
                VActivityInfoEntity = await _activityServices.GetVActivityInfo(id),
                VTakePartInfoEntities = await _takePartServices.GetParticipatorsAsync(id),
                IsCreator = await _societyServices.IsCreator(_userManager.GetUserId(User),id),
                IsTakedPart = await _takePartServices.IsTakedPart(_userManager.GetUserId(User),id)
            };

            return View(activityInfoViewModel);
        }

        // GET: /Activity/Create/{id}
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            return View();
        }

        // POST: /Activity/Create/{id}
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
