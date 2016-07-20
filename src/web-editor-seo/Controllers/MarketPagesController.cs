using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_editor_seo.Models;
using web_editor_seo.Services;

namespace web_editor_seo.Controllers
{
    public class MarketPagesController : Controller
    {
        private readonly IMarketPagesService _marketPagesServices;
        public MarketPagesController(IMarketPagesService marketPagesService)
        {
            _marketPagesServices = marketPagesService;
        }

        public IActionResult Index(string pageId)
        {
            return View("Index", _marketPagesServices.GetMarketPages(pageId));
        }
    }
}
