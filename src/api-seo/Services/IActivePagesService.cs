namespace api_seo.Services
{
    public interface IActivePagesService
    {
        IEnumerable<PageData> GetAll(string appId, string market);
        void Create(CreatePageDataModel model);
    }
}