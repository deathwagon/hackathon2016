using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_seo.Models;
using api_seo.Services;

namespace api_seo.Controllers
{
    [Route("seo/v1/Pages")]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        public IEnumerable<PageModel> Get()
        {            
            return _pageService.GetAll();            
        }

        [HttpGet("{id}")]
        public PageModel Get(string id)
        {            
            return _pageService.Get(id);            
        }

        [HttpPost]
        public void Post([FromBody]PageModel value)
        {
            _pageService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody]PageModel value)
        {
            _pageService.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _pageService.Delete(id);
        }
    }
}
