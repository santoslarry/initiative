

namespace initiative.sso.db.Initializer
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using initiative.sso.db.Context;
    using initiative.sso.db.Migrations;
    using initiative.sso.db.Model;

    public class Initializer : CreateDatabaseIfNotExists<AuthContext>
    {
        protected override void Seed(AuthContext db)
        {
            List<Company> defaultCompany = new List<Company>
            {
                new Company{    Id = 1, Name = "Accenture" },
                new Company{    Id = 2,  Name = "IBM" },
                new Company{    Id = 3,  Name = "Microsoft" },

            };

            List<Roles> defaultRoles = new List<Roles>
            {
                new Roles{Id = 1, Name = "Admin"},
                new Roles{Id = 2, Name = "User"}
            };

            List<Users> defaultUser = new List<Users>
            {
                new Users{Id = 1, FirstName = "Rey", LastName = "Besmonte", UserName = "reynorbert", UserEmail = "rey.norbert.besmonte@accenture.com", Company = defaultCompany[0]}
            };

            List<UserRoles> defaultUserRole = new List<UserRoles>
            {
                new UserRoles { Id = 1, Users = defaultUser[0], Roles = defaultRoles[0] },
                new UserRoles { Id = 2, Users = defaultUser[0], Roles = defaultRoles[1] }
            };

            db.Company.AddRange(defaultCompany);
            db.Roles.AddRange(defaultRoles);
            db.Users.AddRange(defaultUser);
            db.UserRoles.AddRange(defaultUserRole);
            db.SaveChanges();
        }
    }
}
