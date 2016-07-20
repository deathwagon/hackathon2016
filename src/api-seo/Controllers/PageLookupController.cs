using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_seo.Services;

namespace api_seo.Controllers
{
    [Route("seo/v1/pagelookup")]
    public class PageLookupController : Controller
    {
        private readonly IPageLookupService _pageLookupService;

        public PageLookupController(IPageLookupService pageLookupService)
        {
            _pageLookupService = pageLookupService;
        }

        [HttpGet("{appId}/{market}")]
        public ActionResult Get(string appId, string market, string path)
        {
            var result = _pageLookupService.GetPage(appId, market, path);

            if (result == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return Json(result);
            }
        }
    }
}
