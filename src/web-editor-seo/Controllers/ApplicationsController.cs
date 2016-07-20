using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_editor_seo.Models;

namespace web_editor_seo.Controllers
{
    public class ApplicationsController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new ApplicationsModel());
        }
    }
}
