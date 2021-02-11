using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BackendApp
{
    public class CreateController : ApiController
    {
        [BasicAuthentication]
        [Route("company/create")]
        public void Post(List<Person> people)
        {
            try
            {
                NHibernateProfiler.Initialize();
                var mappingconfig = new Configuration();
                mappingconfig.Configure();
                var sefact = mappingconfig.BuildSessionFactory();
                string query;
                foreach (Person p in people)
                {
                    query = string.Format("Insert INTO Employee (FirstName, LastName, DateOfBirth, JobTitle, CompanyId) VALUES ( {0}, {1}, {2} )", p.FirstName, p.LastName, p.DateOfBirth);
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
            catch (MissingFieldException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
