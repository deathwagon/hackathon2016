using System;
using System.Collections.Generic;

namespace api_seo.Services
{
    public class ActivePagesService : IActivePagesService
    {
        public IEnumerable<PageData> GetAll(string appId, string market)
        {
            return new List<PageData>();
        }

        public PageData Get(Guid id)
        {
            return new PageData();
        }

        public void Create(PageDataModel model)
        {
        }

        public void Update(Guid id, PageDataModel model)
        {
        }

        public void Delete(Guid id)
        {
        }
    }
}