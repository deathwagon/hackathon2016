using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_editor_seo.Models;
using web_editor_seo.Services;

namespace web_editor_seo.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsService _applicationsService;
        public ApplicationsController(IApplicationsService applicationsService)
        {
            _applicationsService = applicationsService;
        }

        public IActionResult Index()
        {
            return View("Index", _applicationsService.GetApplications());
        }
    }
}