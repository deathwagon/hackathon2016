using System.Collections.Generic;

namespace api_seo.Services
{
    public class PageLookupService : IPageLookupService
    {
        private ICassandraData _cassandraData; 
        public PageLookupService(ICassandraData cassandraData)
        {
            _cassandraData = cassandraData;
        }
        
        public PageLookupData GetPage(string appId, string market, string path)
        {
            var query = "select * from seo.pages_data_active";
            var results = _cassandraData.ActiveSession.Execute(query);

            foreach(var rowData in results) 
            {
                var result = new PageLookupData
                {
                    PageId = rowData.GetValue<string>("page_id"),
                    Market = rowData.GetValue<string>("market"),
                    StatusCode = 200
                };

                return result;
            }

            return null;
        }
    }
}