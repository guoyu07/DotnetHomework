using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemDbSetExtends;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using DotnetHomework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetHomework.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SocietyServices _societyServices;
        private readonly ActivityServices _activityServices;

        public AdminController(SocietyServices societyServices, ActivityServices activityServices)
        {
            _societyServices = societyServices;
            _activityServices = activityServices;
        }

        //
        // GET: /Admin/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["PendingSocieties"] = (await _societyServices.GetPendingSocietiesAsync()).Count;
            ViewData["PendingActivities"] = (await _activityServices.GetPendingActivitiesAsync()).Count;

            return View();
        }

        //
        // GET: /Admin/PendingSocieties
        [HttpGet]
        public async Task<IActionResult> PendingSocieties()
        {
            List<VSocietyInfoEntity> vSocietyInfoEntities = await _societyServices.GetPendingSocietiesAsync();
            ViewData["PendingSocieties"] = (await _societyServices.GetPendingSocietiesAsync()).Count;
            ViewData["PendingActivities"] = (await _activityServices.GetPendingActivitiesAsync()).Count;

            return View(vSocietyInfoEntities);
        }

        //
        // GET: /Admin/SocietyActive/{id}
        [HttpGet]
        public async Task<IActionResult> SocietyActive(int id)
        {
            await _societyServices.EditSocietyStatus(id, SocietyDbSetStatusEnum.Active);
            return RedirectToAction("PendingSocieties");
        }

        //
        // GET: /Admin/SocietyReject/{id}
        [HttpGet]
        public async Task<IActionResult> SocietyReject(int id)
        {
            await _societyServices.EditSocietyStatus(id, SocietyDbSetStatusEnum.Reject);
            return RedirectToAction("PendingSocieties");
        }

        //
        // GET: /Admin/PendingActivities
        [HttpGet]
        public async Task<IActionResult> PendingActivities()
        {
            List<VActivityInfoEntity> vActivityInfoEntities = await _activityServices.GetPendingActivitiesAsync();
            ViewData["PendingSocieties"] = (await _societyServices.GetPendingSocietiesAsync()).Count;
            ViewData["PendingActivities"] = (await _activityServices.GetPendingActivitiesAsync()).Count;

            return View(vActivityInfoEntities);
        }

        //
        // GET: /Admin/ActivityActive/{id}
        [HttpGet]
        public async Task<IActionResult> ActivityActive(int id)
        {
            await _activityServices.EditActivityStatusAsync(id, ActivityDbSetStatusEnum.Active);
            return RedirectToAction("PendingActivities");
        }

        //
        // GET: /Admin/ActivityReject/{id}
        [HttpGet]
        public async Task<IActionResult> ActivityReject(int id)
        {
            await _activityServices.EditActivityStatusAsync(id, ActivityDbSetStatusEnum.Reject);
            return RedirectToAction("PendingActivities");
        }
    }
}