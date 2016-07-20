using System;
using System.Collections.Generic;
using api_seo.Models;

namespace api_seo.Services
{
    public interface IApplicationService
    {
        IEnumerable<ApplicationDataModel> GetAll();
        ApplicationDataModel Get(int id);
        void Create(ApplicationDataModel model);
        void Update(int id, ApplicationDataModel model);
        void Delete(int id);
    }
}