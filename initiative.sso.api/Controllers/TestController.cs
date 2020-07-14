using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using initiative.sso.db.Context;

namespace initiative.sso.api.Controllers
{
  
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
       
        // GET: api/Test
        public string Get()
        {
            using (AuthContext db = new AuthContext())
            {
                var x = db.Tests.FirstOrDefault();
                return "Successful";
            }
 
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

    }
}
