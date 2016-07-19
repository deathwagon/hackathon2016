using System;
using System.Collections.Generic;
using api_seo.Models;

namespace api_seo.Services
{
    public class ActivePagesService : IActivePagesService
    {
        private ICassandraData _database;

        public ActivePagesService(ICassandraData database)
        {
            _database = database;
        }

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
            var updateStatementFormat = _database.ActiveSession.Prepare("INSERT INTO seo.pages (id, app_id, path) VALUES (:PageId, :AppId, :EnglishPath)");
            var updateStatement = updateStatementFormat.Bind(model);
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