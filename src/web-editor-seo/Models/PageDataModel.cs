using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace web_editor_seo.Models
{
    public class PageDataModel
    {
        public int AppId { get; set; }

        public string PageId { get; set; }

        public string Market { get; set; }

        public int Version { get; set; }        

        public string MarketPath { get; set; }

        public IList<KeyValuePair<string, string>> Data { get; set; } 
    }
}