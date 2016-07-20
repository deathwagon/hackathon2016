using System.Collections.Generic;

public class PageLookupData
{
    public PageLookupData()
    {
        SeoPageMap = new Dictionary<string, string>(16);
    }
    
    public int StatusCode { get; set; }

    public string Market { get; set; }

    public string PageId { get; set; }

    public string PagePath { get; set; }
    
    public Dictionary<string, string> SeoPageMap { get; set; }
}