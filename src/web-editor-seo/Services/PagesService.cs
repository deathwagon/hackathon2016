using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using web_editor_seo.Models;

namespace web_editor_seo.Services
{
    public class PagesService
    {
        public async Task<PagesModel> GetAll()
        {
            using (var client = new HttpClient())
            {
                var baseUri = "http://localhost:5001/seo/v1/pages";
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var pages = JsonConvert.DeserializeObject<IList<PageModel>>(responseJson);
                    return new PagesModel { Pages = pages };
                }
            }
            return null;
        }
    }
}