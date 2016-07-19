using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_seo.Controllers;
using api_seo.Services;

namespace api_seo.Controllers
{
    [Route("seo/v1/ActivePages")]
    public class ActivePagesController : Controller
    {
        private readonly IActivePagesService _activePagesService;

        public ActivePagesController(IActivePagesService activePagesService)
        {
            _activePagesService = activePagesService;
        }

        public PageRedirectData Get(string appId, string market, string path)
        {
            var result = _activePagesService.GetRedirectData(appId, market, path);
            return result;
        }
    }
}
