using api_seo.Models;

namespace api_seo.Services
{
    public interface IPageLookupService
    {
        PageLookupData GetPage(string appId, string market, string path);
    }
}