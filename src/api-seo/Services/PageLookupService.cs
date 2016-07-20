using System.Collections.Generic;

namespace api_seo.Services
{
    public class PageLookupService : IPageLookupService
    {
        public PageLookupService()
        {
            
        }
        
        public PageLookupData GetPage(string appId, string market, string path)
        {
            // #1 Redirect
            // #2 Not Found
            // #3 Found, show page data

            return null;
        }
    }
}