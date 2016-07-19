namespace api_seo.Services
{
    public interface IRedirectService
    {
        PageRedirectData GetRedirectData(string appId, string market, string path);
    }
}