using System;
using System.Collections.Generic;
using Cassandra;
using api_seo.Models;


namespace api_seo.Services
{
    public class ApplicationService: IApplicationService 
    {
        private ICassandraData _database;

        public ApplicationService(ICassandraData database) 
        {
            _database = database;   
        }
        
        public IEnumerable<ApplicationDataModel> GetAll() 
        {
            var results = _database.ActiveSession.Execute("select * from seo.applications");

           var list = new List<ApplicationDataModel>();

           foreach (var row in results)
           {
               var item = new ApplicationDataModel();
               
               item.ApplicationID = row.GetValue<int>(ApplicationDataModel.APPLICATION_ID);
               item.ApplicationName = row.GetValue<string>(ApplicationDataModel.APPLICATION_NAME);
               
               list.Add(item);
           }
           
            return list;
        }
        
        public ApplicationDataModel Get(int id) 
        {
            var statement = _database.ActiveSession.Prepare("select * from seo.applications WHERE id = :app_id"); 
            
            var results = _database.ActiveSession.Execute(statement.Bind( new { app_id = id} ));

            var model = new ApplicationDataModel();
            model.ApplicationID = id;
            
            foreach(var row in results)
            {
                model.ApplicationName = row.GetValue<string>(ApplicationDataModel.APPLICATION_NAME);
            }
                            
            return model;
        }
        
        public void Create(ApplicationDataModel model) 
        {
            var statement = _database.ActiveSession.Prepare("insert into seo.applications (id, name) values(:app_id, :app_name)");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = model.ApplicationID, app_name = model.ApplicationName }));  
        }
        
        public void Update(int id, ApplicationDataModel model)
        {
            var statement = _database.ActiveSession.Prepare("update seo.applications set name = :app_name where id = :app_id");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = id, 
                app_name = model.ApplicationName }));
        }
        
        public void Delete(int id)
        {
            var statement = _database.ActiveSession.Prepare("delete from seo.applications where id = :app_id");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = id}));
        }
    }
}