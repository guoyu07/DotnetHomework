using System;
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
    public class ActivityController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ActivityServices _activityServices;
        private readonly TakePartServices _takePartServices;
        private readonly SocietyServices _societyServices;

        public ActivityController(UserManager<ApplicationUser> userManager, ActivityServices activityServices,
            TakePartServices takePartServices, SocietyServices societyServices)
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
                IsTakedPart = await _takePartServices.IsTakedPart(_userManager.GetUserId(User), id)
            };

            return View(activityInfoViewModel);
        }

        //
        // GET: /Activity/TakePart/{id}
        [HttpGet]
        public async Task<IActionResult> TakePart(int id)
        {
            await _takePartServices.TakePart(_userManager.GetUserId(User), id);
            return RedirectToAction("Info", new {id});
        }

        // GET: /Activity/Create/{id}
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            ActivityCreateViewModel activityCreateViewModel = new ActivityCreateViewModel
            {
                VSocietyInfoEntity = await _societyServices.GetVSocietyInfo(id)
            };
            return View(activityCreateViewModel);
        }

        // POST: /Activity/Create/{id}
        [HttpPost]
        public async Task<IActionResult> Create(int id, ActivityCreateViewModel activityCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _activityServices.CreateActivity(id, activityCreateViewModel))
                {
                    ViewData["Result"] = ActivityServices.ActivityCreateResultEnum.Success;
                }
            }

            activityCreateViewModel.VSocietyInfoEntity = await _societyServices.GetVSocietyInfo(id);
            return View(activityCreateViewModel);
        }
    }
}