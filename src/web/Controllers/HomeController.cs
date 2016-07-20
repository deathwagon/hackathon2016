using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace web.Controllers
{
    [Route("{*path}")]
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Index(string path)
        {
            var requestedPath = "/" + path ?? string.Empty;
            var market = Request.Query["market"].FirstOrDefault() ?? "en-US";

            var pageData = LookupPageData(requestedPath, market);
            if (pageData == null)
            {
                return NotFound();
            }

            if (pageData.StatusCode == (int)HttpStatusCode.MovedPermanently)
            {
                return Redirect(pageData.PageData.MarketPath + $"?market={market}");
            }

            return View(pageData);
        }

        private PageLookupData LookupPageData(string path, string market)
        {
            // http://localhost:5001/seo/v1/pagelookup/1/es-ES?path=%2Fhosting%2Fweb-hosting
            var urlBuilder = new UriBuilder("http://localhost:5001");
            urlBuilder.Path = $"/seo/v1/pagelookup/1/{market}";
            var encodedPath = path.Replace("/", "%2F");
            urlBuilder.Query = $"?path={encodedPath}";

            var request = new HttpRequestMessage();
            request.RequestUri = urlBuilder.Uri;

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(30000);
                response = client.SendAsync(request).Result;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var serializedJson = response.Content.ReadAsStringAsync().Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PageLookupData>(serializedJson);
            }

            return null;
        }
    }
}
