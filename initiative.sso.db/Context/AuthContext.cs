using initiative.sso.db.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace initiative.sso.db.Context
{
    public class AuthContext : DbContext, IAuthContext
    {
        public AuthContext() : base("AuthContext")
        {
            Database.SetInitializer(new Initializer.Initializer());
        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public DbSet<Company> Company { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Tests> Tests { get; set; }

    }
}
