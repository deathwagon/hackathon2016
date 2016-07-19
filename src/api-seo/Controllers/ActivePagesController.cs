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

        [HttpGet]
        public IEnumerable<PageData> Get(string appId, string market)
        {
            var result = _activePagesService.GetAll(appId, market);
            return result;
        }

        [HttpGet("{id}")]
        public PageDataModel Get(Guid id)
        {
            return new PageDataModel();
        }

        [HttpPost]
        public void Post([FromBody]PageDataModel value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PageDataModel value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
