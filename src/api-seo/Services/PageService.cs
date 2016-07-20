using System;
using System.Linq;
using System.Collections.Generic;
using api_seo.Models;

namespace api_seo.Services
{
    public class PageService : IPageService
    {
        private ICassandraData _database;

        public PageService(ICassandraData database)
        {
            _database = database;
        }

        public IEnumerable<PageModel> GetAll()
        {
            var pages = new List<PageModel>();
            var results = _database.ActiveSession.Execute("select * from seo.pages");

            foreach(var result in results)
            {
                var model = HydrateModel(result);
                pages.Add(model);
            }

            return pages;
        }

        public PageModel Get(string id)
        {
            var pages = new List<PageModel>();

            var statementFormat = _database.ActiveSession.Prepare("select * from seo.pages WHERE ID = ? limit 1");
            var statement = statementFormat.Bind(id);
            var results = _database.ActiveSession.Execute(statement);
            return HydrateModel(results.FirstOrDefault());
        }

        public void Create(PageModel model)
        {
            // TODO: Make this work
            // var updateStatementFormat = _database.ActiveSession.Prepare("INSERT INTO seo.pages (id, app_id, path) VALUES (:Id, :AppId, :Path)");
            // var updateStatement = updateStatementFormat.Bind(model);
            
            var updateStatementFormat = _database.ActiveSession.Prepare("INSERT INTO seo.pages (id, app_id, path) VALUES (?, ?, ?)");
            var updateStatement = updateStatementFormat.Bind(model.Id, model.AppId, model.Path);
            _database.ActiveSession.Execute(updateStatement);
        }

        public void Update(string id, PageModel model)
        {
            var existing = Get(id);
            if (existing == null)
            {
                throw new Exception($"Cannot find page with id = '{id}'");
            }
            else if (id != model.Id)
            {
                // Assume user wants to update id, which must be a delete/create.
                Delete(id);
                Create(model);
            }
            else
            {
                var updateStatementFormat = _database.ActiveSession.Prepare("UPDATE seo.pages SET app_id = ?, path = ? WHERE id = ?");
                var updateStatement = updateStatementFormat.Bind(model.AppId, model.Path, id);
                _database.ActiveSession.Execute(updateStatement);
            }
        }

        public void Delete(string id)
        {
            var statementFormat = _database.ActiveSession.Prepare("delete from seo.pages WHERE ID = ?");
            var statement = statementFormat.Bind(id);
            var results = _database.ActiveSession.Execute(statement);
            // TODO: Check result count.
        }

        private PageModel HydrateModel(Cassandra.Row result)
        {
            if (result == null)
            {
                return null;
            }
            var pageId = result.GetValue<string>("id");
            var appId = result.GetValue<int>("app_id");
            var path = result.GetValue<string>("path");
            return new PageModel { Id = pageId, AppId = appId, Path = path };
        }
    }
}