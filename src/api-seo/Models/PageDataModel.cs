using System.Collections.Generic;

namespace api_seo.Models
{
    public class PageDataModel
    {
        public string PageId { get; set; }
        public int AppId {get; set;}
        public string Market { get; set; }
        public int Version { get; set; }
        public string MarketPath { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }
}