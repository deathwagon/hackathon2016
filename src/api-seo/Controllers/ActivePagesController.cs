using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api_seo.Models;

namespace api_seo.Controllers
{
    [Route("seo/v1/redirect")]
    public class ActivePagesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<ActivePage> Get(string appId, string market, string path)
        {
            var result = GetActivePages(appId, market, path);
            return result;
        }

        public IEnumerable<ActivePage> GetActivePages(string appId, string market, string path)
        {
            return new [] {
                new ActivePage { Name = "Sample 1", EnPath = "/something/or/other" },
                new ActivePage { Name = "Sample 2", EnPath = "/something/else" },
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
