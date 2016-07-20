using System;
using System.Collections.Generic;
using api_seo.Models;
using Newtonsoft.Json;

namespace api_seo.Services
{
    public class ActivePagesService : IActivePagesService
    {
        private ICassandraData _database;

        public ActivePagesService(ICassandraData database)
        {
            _database = database;
        }

        public IEnumerable<PageDataModel> GetAll(string appId, string market)
        {
            var stmt = "SELECT * FROM seo.pages_data_active";
            if (!string.IsNullOrEmpty(appId))
            {
                stmt = stmt + " WHERE app_id = " + appId;
            }
            
            if (!string.IsNullOrEmpty(market))
            {
                if (!string.IsNullOrEmpty(appId))
                {   
                    stmt = stmt + " AND market = " + market;
                }
                else
                {
                    stmt = stmt + " WHERE market = " + market;
                }
            }
            stmt = stmt + ";";
            
            var rs = _database.ActiveSession.Execute(stmt);
 
            var lst = new List<PageDataModel>();

            if (rs != null)
            {
                foreach (var row in rs)
                {
                    var pageDataModel = new PageDataModel();
                    pageDataModel.AppId = row.GetValue<int>("app_id");
                    pageDataModel.PageId = row.GetValue<string>("page_id");
                    pageDataModel.Market = row.GetValue<string>("market");
                    pageDataModel.Version = row.GetValue<int>("version");

                    var data = row.GetValue<SortedDictionary<string, string>>("data");
                    pageDataModel.Data = new Dictionary<string,string>(data);

                    pageDataModel.MarketPath = row.GetValue<string>("market_path");

                    lst.Add(pageDataModel);
                }   
            }        

            return lst;
        }

        public PageData Get(Guid id)
        {
            return new PageData();
        }

        public void Create(PageDataModel model)
        {
            //var updateStatementFormat = _database.ActiveSession.Prepare("INSERT INTO seo.pages (id, app_id, path) VALUES (:PageId, :AppId, :EnglishPath)");
            //var updateStatement = updateStatementFormat.Bind(model);
            // var updateStatementFormat = _database.ActiveSession.Prepare("INSERT INTO seo.pages (id, app_id, path) VALUES (?, ?, ?)");
            var updateStatementFormat = "INSERT INTO seo.pages (id, app_id, path) VALUES ('{0}', '{1}', '{2}')";
            var updateStatement = string.Format(updateStatementFormat, model.PageId, model.AppId, model.MarketPath);
            _database.ActiveSession.Execute(updateStatement);
        }

        public void Update(Guid id, PageDataModel model)
        {
        }

        public void Delete(Guid id)
        {
        }
    }
}