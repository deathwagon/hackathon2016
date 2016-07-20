using System;
using System.Collections.Generic;
using web_editor_seo.Models;

namespace web_editor_seo.Services
{
    public class MarketPagesService : IMarketPagesService
    {
        public MarketPagesModel GetMarketPages(string pageId)
        {
            IDictionary<string, MarketPagesModel> marketPagesMap = new Dictionary<string, MarketPagesModel>
            {
                { "website-builder", new MarketPagesModel {
                    MarketPages = new List<MarketPageModel> {
                        new MarketPageModel { PageId = "website-builder", Market = "en-US" },
                        new MarketPageModel { PageId = "website-builder", Market = "es-ES" } }
                    } 
                },
                { "web-hosting", new MarketPagesModel {
                    MarketPages = new List<MarketPageModel> {
                        new MarketPageModel { PageId = "web-hosting", Market = "en-US" },
                        new MarketPageModel { PageId = "web-hosting", Market = "es-ES" } }
                    } 
                }
            };

            return marketPagesMap[pageId];
        }
    }
}