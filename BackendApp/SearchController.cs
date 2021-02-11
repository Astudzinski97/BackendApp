using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BackendApp
{
    public class SearchController : ApiController
    {
        [BasicAuthentication]
        [Route("company/search")]
        public void Post(SearchQuery squery)
        {
            NHibernateProfiler.Initialize();
            var mappingconfig = new Configuration();
            mappingconfig.Configure();
            var sefact = mappingconfig.BuildSessionFactory();
            string query = string.Format("SELECT * FROM Person WHERE FirstName LIKE {0}", squery.Keyword);
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery(query);
                    q.List();
                    tx.Commit();
                }
            }
            query = string.Format("SELECT * FROM Person WHERE LastName LIKE {0}", squery.Keyword);
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery(query);
                    q.List();
                    tx.Commit();
                }
            }
            query = string.Format("SELECT * FROM Person WHERE DateOfBirth>={0}", squery.DateOfBirthFrom);
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery(query);
                    q.List();
                    tx.Commit();
                }
            }
            query = string.Format("SELECT * FROM Person WHERE DateOfBirth<={0}", squery.DateOfBirthTo);
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    IQuery q = session.CreateQuery(query);
                    q.List();
                    tx.Commit();
                }
            }
        }
    }
}
