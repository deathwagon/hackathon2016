using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_editor_seo.Models;
using web_editor_seo.Services;

namespace web_editor_seo.Controllers
{
    public class PagesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var service = new PagesService();
            var pages = await service.GetAll() ?? new PagesModel();
            return View("Index", pages);
        }
    }
}
