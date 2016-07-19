using System;
using System.Collections.Generic;

namespace api_seo.Services
{
    public interface IActivePagesService
    {
        IEnumerable<PageData> GetAll(string appId, string market);
        PageData Get(Guid id);
        void Create(PageDataModel model);
        void Update(Guid id, PageDataModel model);
        void Delete(Guid id);
    }
}