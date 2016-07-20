

using web_editor_seo.Models;

namespace web_editor_seo.Services
{
    public interface IMarketPagesService
    {
        MarketPagesModel GetMarketPages(string pageId);
    }
}