using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_editor_seo.Models;

namespace web_editor_seo.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index(int appId)
        {
            return View("Index", new PagesModel());
        }
    }
}
