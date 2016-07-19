using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_seo.Services;

namespace api_seo.Controllers
{
    [Route("seo/v1/Redirect")]
    public class RedirectController : Controller
    {
        private readonly IRedirectService _redirectService;

        public RedirectController(IRedirectService redirectService)
        {
            _redirectService = redirectService;
        }

        public PageRedirectData Get(string appId, string market, string path)
        {
            var result = _redirectService.GetRedirectData(appId, market, path);
            return result;
        }
    }
}
