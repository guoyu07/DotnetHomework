using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetHomework.Data.SocietyManagementSystemEntities;
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

        public SocietyController(UserManager<ApplicationUser> userManager, SocietyServices societyServices,
            ActivityServices activityServices)
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

        //
        // GET: /Society/Search
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search()
        {
            SocietySearchViewModel societySearchViewModel = new SocietySearchViewModel
            {
                SocietyCategoryEntities = await _societyServices.GetSocietyCategoriesAsync(),
                VSocietyInfoEntities = new List<VSocietyInfoEntity>()
            };

            return View(societySearchViewModel);
        }

        //
        // POST: /Society/Search
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Search(SocietySearchViewModel societySearchViewModel)
        {
            societySearchViewModel.VSocietyInfoEntities =
                await _societyServices.SearchSocieties(societySearchViewModel);
            societySearchViewModel.SocietyCategoryEntities = await _societyServices.GetSocietyCategoriesAsync();
            return View(societySearchViewModel);
        }

        //
        // GET: /Society/Info/{id}
        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            bool isCreator = await _societyServices.IsCreator(_userManager.GetUserId(User), id);
            bool isJoined = false;
            bool isPending = false;
            string post = null;
            if (!isCreator)
            {
                isJoined = await _societyServices.IsJoined(_userManager.GetUserId(User), id);
                if (!isJoined)
                {
                    isPending = await _societyServices.IsPending(_userManager.GetUserId(User), id);
                    if (isPending)
                    {
                        post = await _societyServices.GetEntryPost(_userManager.GetUserId(User), id);
                    }
                }
            }

            List<VMemberInfoEntity> vMemberInfoEntities = null;
            VSocietyInfoEntity vSocietyInfoEntity = await _societyServices.GetVSocietyInfoEntityByIdAsync(id);

            if (isCreator || isJoined)
            {
                vMemberInfoEntities = await _societyServices.GetAvailableMembersAsync(id);
            }
            if (isCreator)
            {
                vSocietyInfoEntity.CreatorName = "我";
            }

            SocietyInfoViewModel societyInfoViewModel = new SocietyInfoViewModel
            {
                IsCreator = isCreator,
                IsJoined = isJoined,
                IsPending = isPending,
                VMemberInfoEntities = vMemberInfoEntities,
                VSocietyInfoEntity = vSocietyInfoEntity,
                Post = post,
                VActivityInfoEntities = await _activityServices.GetAllActivitiesDescAsync(id)
            };

            return View(societyInfoViewModel);
        }

        //
        // POST: /Society/Join
        [HttpPost]
        public async Task<IActionResult> Join(int societyId, string entryPost)
        {
            string userId = _userManager.GetUserId(User);
            if (await _societyServices.JoinSociety(userId, societyId, entryPost))
            {
                ViewData["Message"] = "您的申请已提交, 请等待审核";
                ViewData["Result"] = true;
            }
            else
            {
                ViewData["Reason"] = "你已提交申请或已加入该社团";
                ViewData["Message"] = "入团申请提交失败";
                ViewData["Result"] = false;
            }
            ViewData["SocietyId"] = societyId;

            return View();
        }

        //
        // GET: /Society/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["SocietyCategoryEntities"] = await _societyServices.GetSocietyCategoriesAsync();
            return View();
        }

        //
        // POST: /Society/Create
        [HttpPost]
        public async Task<IActionResult> Create(SocietyCreateViewModel societyCreateViewModel)
        {
            ViewData["SocietyCategoryEntities"] = await _societyServices.GetSocietyCategoriesAsync();

            if (ModelState.IsValid)
            {
                ViewData["Result"] =
                    await _societyServices.CreateSociety(_userManager.GetUserId(User), societyCreateViewModel);
            }

            return View(societyCreateViewModel);
        }

        //
        // GET: /Society/Manage/{id}
        [HttpGet]
        public async Task<IActionResult> Manage(int id)
        {
            if (!await _societyServices.IsCreator(_userManager.GetUserId(User), id))
            {
                return View("Error");
            }

            SocietyManageViewModel societyManageViewModel = new SocietyManageViewModel
            {
                VSocietyInfoEntity = await _societyServices.GetVSocietyInfo(id),
                VMemberInfoEntities = await _societyServices.GetAvailableMembersAsync(id),
                VActivityInfoEntities = await _activityServices.GetAllActivitiesDescAsync(id)
            };

            return View(societyManageViewModel);
        }

        //
        // POST: /Society/Manage/{id}
        [HttpPost]
        public async Task<IActionResult> Manage(SocietyManageViewModel societyManageViewModel)
        {
            if (!await _societyServices.EditSocietyDescription(societyManageViewModel.VSocietyInfoEntity.Id,
                societyManageViewModel.VSocietyInfoEntity.Description))
            {
                return View("Error");
            }
            return RedirectToAction("Manage");
        }
    }
}