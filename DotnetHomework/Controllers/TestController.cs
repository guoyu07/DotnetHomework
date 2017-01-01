using System.Collections.Generic;
using System.Linq;
using DotnetHomework.Data;
using DotnetHomework.Data.SocietyManagementSystemEntities;
using Microsoft.AspNetCore.Mvc;

namespace DotnetHomework.Controllers
{
    public class TestController :Controller
    {
        private readonly SocietyManagementSystemDbContext _societyManagementSystemDbContext;

        public TestController(SocietyManagementSystemDbContext societyManagementSystemDbContext)
        {
            _societyManagementSystemDbContext = societyManagementSystemDbContext;
        }

        public List<VSocietyInfoEntity> Index()
        {
            return _societyManagementSystemDbContext.VSocietyInfo.ToList();
        }
    }
}