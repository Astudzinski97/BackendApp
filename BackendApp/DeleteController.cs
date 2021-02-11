using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using System.Web.Http;

namespace BackendApp
{
    public class DeleteController : ApiController
    {
        [BasicAuthentication]
        [Route("company/delete/<id>")]
        public void Delete(long id)
        {
            NHibernateProfiler.Initialize();
            var mappingconfig = new Configuration();
            mappingconfig.Configure();
            var sefact = mappingconfig.BuildSessionFactory();
            string query = string.Format("DELETE Person WHERE ID={0}", id);
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
