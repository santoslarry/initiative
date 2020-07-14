
using System;
using System.Data.Entity;
using initiative.sso.db.Model;

namespace initiative.sso.db.Context
{
    public interface IAuthContext : IDisposable
    {
        DbSet<Company> Company { get; }

        DbSet<Roles> Roles { get; }

        DbSet<Users> Users { get; }

        DbSet<UserRoles> UserRoles { get;  }

        DbSet<Tests> Tests { get; }

        int SaveChanges();
        void SetModified(object entity);
    }
}
