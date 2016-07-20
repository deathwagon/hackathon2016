using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_seo.Models;
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


        [HttpGet()]
        public IEnumerable<PageDataModel> Get()
        {
            var result = _activePagesService.GetAll(string.Empty, string.Empty);
            return result;
        }

        [HttpGet("{appId}")]
        public IEnumerable<PageDataModel> Get(string appId)
        {
            var result = _activePagesService.GetAll(appId, string.Empty);
            return result;       
        }

        [HttpPost]
        public void Post([FromBody]PageDataModel value)
        {
            _activePagesService.Create(value);
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
