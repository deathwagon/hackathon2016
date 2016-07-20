using System;
using System.Collections.Generic;
using web_editor_seo.Models;

namespace web_editor_seo.Services
{
    public class ApplicationsService : IApplicationsService
    {
        public ApplicationsModel GetApplications()
        {
            IList<ApplicationModel> applications = new List<ApplicationModel>{
                new ApplicationModel { Id = 1, Name = "sales" },
                new ApplicationModel { Id = 2, Name = "help" },
            };

            return new ApplicationsModel { Applications = applications };
        }
    }
}