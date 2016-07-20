using System.Collections.Generic;
using System;
using api_seo.Models;
using System.Linq;

namespace api_seo.Services
{
    public class PageLookupService : IPageLookupService
    {
        private ICassandraData _cassandraData;
        private Lazy<List<PageDataModel>> _pageData;

        public PageLookupService(ICassandraData cassandraData)
        {
            _cassandraData = cassandraData;
            _pageData = new Lazy<List<PageDataModel>>(LoadData);
        }

        private List<PageDataModel> LoadData()
        {
            var result = new List<PageDataModel>(10);
        
            var query = "select * from seo.pages_data_active";
            var results = _cassandraData.ActiveSession.Execute(query);

            foreach(var row in results) 
            {
                var pageDataModel = new PageDataModel();
                pageDataModel.AppId = row.GetValue<int>("app_id");
                pageDataModel.PageId = row.GetValue<string>("page_id");
                pageDataModel.Market = row.GetValue<string>("market");
                pageDataModel.Version = row.GetValue<int>("version");

                var data = row.GetValue<SortedDictionary<string, string>>("data");
                pageDataModel.Data = new Dictionary<string,string>(data);

                pageDataModel.MarketPath = row.GetValue<string>("market_path");
                result.Add(pageDataModel);
            }

            return result;
        }

        public PageLookupData GetPage(string appId, string market, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var pageData = _pageData.Value.FirstOrDefault(p => IsPathValidForMarket(p, path, market));
            if (pageData != null)
            {
                return new PageLookupData
                {
                    StatusCode = 200,
                    PageData = pageData
                };
            }

            var correctMarketPage = FindCorrectMarketPath(path, market);
            if (correctMarketPage != null)
            {
                return new PageLookupData
                {
                    StatusCode = 301,
                    PageData = correctMarketPage
                };
            }

            return null;
        }

        private bool IsPathValidForMarket(PageDataModel pageData, string path, string market)
        {
            return ((string.Equals(pageData.MarketPath, path, StringComparison.OrdinalIgnoreCase)) 
            && (string.Equals(pageData.Market, market, StringComparison.OrdinalIgnoreCase)));
        }

        private PageDataModel FindCorrectMarketPath(string path, string correctMarket)
        {
            PageDataModel result = null;
            var pageWithPath = _pageData.Value.FirstOrDefault(
                p => string.Equals(p.MarketPath, path, StringComparison.OrdinalIgnoreCase));
            if (pageWithPath != null)
            {
                result = _pageData.Value.FirstOrDefault(p => IsPageCorrectIdAndMarket(p, pageWithPath.PageId, correctMarket));
            }

            return result;
        }

        private bool IsPageCorrectIdAndMarket(PageDataModel pageData, string pageId, string market)
        {
            return (pageId == pageData.PageId) &&
                (string.Equals(market, pageData.Market, StringComparison.OrdinalIgnoreCase)); 
        }

    }
}