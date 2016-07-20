using System;
using System.Collections.Generic;
using api_seo.Models;

namespace api_seo.Services
{
    public interface IActivePagesService
    {
        IEnumerable<PageDataModel> GetAll(string appId, string market);
        PageData Get(Guid id);
        void Create(PageDataModel model);
        void Update(Guid id, PageDataModel model);
        void Delete(Guid id);
    }
}