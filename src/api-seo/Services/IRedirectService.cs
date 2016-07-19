namespace api_seo.Services
{
    public interface IActivePagesService
    {
        PageRedirectData GetRedirectData(string appId, string market, string path);
    }
}