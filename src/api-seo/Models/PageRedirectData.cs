using System.Collections.Generic;

public class PageRedirectData
{
    public int StatusCode { get; set;}
    public string Market { get; set;}
    public int PageId { get; set;}
    public string PagePath { get; set;}
    public Dictionary<string, string> SeoPageMap { get; set; }

    public PageRedirectData()
    {
        SeoPageMap = new Dictionary<string, sring>(16);
    }
}