using System;
using System.Collections.Generic;
using api_seo.Models;

namespace api_seo.Services
{
    public interface IPageService
    {
        IEnumerable<PageModel> GetAll();
        PageModel Get(string id);
        void Create(PageModel model);
        void Update(string id, PageModel model);
        void Delete(string id);
    }
}