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
            var statement = _database.ActiveSession.Prepare("select * from seo.applications WHERE app_id = :app_id"); 
            
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
            System.Console.WriteLine("application model data: {0}, {1}", model.ApplicationID, model.ApplicationName);
            var statement = _database.ActiveSession.Prepare("insert into seo.applications (app_id, app_name) values(:app_id, :app_name)");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = model.ApplicationID, app_name = model.ApplicationName }));
                
                
            System.Console.WriteLine("result: {0}", result);
            
        }
        
        public void Update(int id, ApplicationDataModel model)
        {
            var statement = _database.ActiveSession.Prepare("update seo.applications set app_name = :app_name where app_id = :app_id");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = id, 
                app_name = model.ApplicationName }));
        }
        
        public void Delete(int id)
        {
            var statement = _database.ActiveSession.Prepare("delete from seo.applications where app_id = :app_id");
            var result = _database.ActiveSession.Execute(statement.Bind(new { app_id = id}));
        }
    }
}