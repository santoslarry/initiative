using initiative.sso.api.tests.Model;
using initiative.sso.db.Context;
using initiative.sso.db.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace initiative.sso.api.tests.Context
{
    public class TestInitiativeContext : IAuthContext
    {
        public TestInitiativeContext()
        {
            this.Company = new TestDbSet<Company>(); 
        }
  
        public DbSet<Company> Company { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Tests> Tests { get; set; }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

       
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {

        }
    }
}
