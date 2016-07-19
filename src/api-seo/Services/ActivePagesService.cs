using System.Collections.Generic;

namespace api_seo.Services
{
    public class ActivePagesService : IActivePagesService
    {
        public PageRedirectData GetRedirectData(string appId, string market, string path)
        {
            return new PageRedirectData
            {
              StatusCode = 200,
              Market = "en-us",
              PageId = 1,
              PagePath = "/",  
            };
        }
    }
}