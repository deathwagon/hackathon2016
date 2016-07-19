using System;
using System.Collections.Generic;
using System.Linq;

namespace api_seo.Services
{   
    public class PageUrlService : IPageUrlService
    {
        public string GetMarket(string pageUrl)
        {
            var result = string.Empty;
            
            Uri pageUri;
            if (Uri.TryCreate(pageUrl, UriKind.Absolute, out pageUri))
            {
                int iqs = pageUrl.IndexOf('?');
                if (iqs > 0)
                {
                    Dictionary<string, string> dicQueryString = 
                            pageUrl.Substring(iqs+1).Split('&')
                                .ToDictionary(c => c.Split('=')[0],
                                            c => Uri.UnescapeDataString(c.Split('=')[1]));

                    result = dicQueryString["market"];     
                }
            }

            return !string.IsNullOrEmpty(result) ? result : "en";
        }
    }
}