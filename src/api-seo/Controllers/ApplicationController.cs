using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_seo.Models;
using api_seo.Services;

namespace api_seo.Controllers
{
    [Route("seo/v1/Application")]
    public class ApplicationController: Controller 
    {
        private readonly IApplicationService _applicationService;
        
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        
        [HttpGet]
        public IEnumerable<ApplicationDataModel> Get()
        {
            var result = _applicationService.GetAll();
            return result;
        }
        
        [HttpGet("{id}")]
        public ApplicationDataModel Get(int id)
        {
            return _applicationService.Get(id);
        }
        
        [HttpPost]
        public void Post([FromBody]ApplicationDataModel value)
        {
            _applicationService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ApplicationDataModel value)
        {
            _applicationService.Update(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _applicationService.Delete(id);
        }
    }
}