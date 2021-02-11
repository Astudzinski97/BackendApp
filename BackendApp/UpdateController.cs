using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using System.Web.Http;

namespace BackendApp
{
    public class UpdateController : ApiController
    {
        [BasicAuthentication]
        [Route("company/update/<id>")]
        public void Put(Person p)
        {
            NHibernateProfiler.Initialize();
            var mappingconfig = new Configuration();
            mappingconfig.Configure();
            var sefact = mappingconfig.BuildSessionFactory();
            string query = string.Format("UPDATE Person SET FirstName={0}, LastName={1}, DateOfBirth={2} WHERE ID={2}", p.FirstName, p.LastName, p.DateOfBirth, p.Id);
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
