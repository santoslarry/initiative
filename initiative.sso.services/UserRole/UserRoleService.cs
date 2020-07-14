using initiative.sso.db.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using dbModel = initiative.sso.db.Model;
using System.Data.Entity;

namespace initiative.sso.services.UserRole
{
    public class UserRoleService: IUserRoleService
    {
        private readonly IAuthContext db;

        public UserRoleService()
        {
            this.db = new AuthContext();
        }

        public UserRoleService(IAuthContext dbContext)
        {
            this.db = dbContext;
        }

        public List<dbModel.UserRoles> GetAllUserRole()
        {
            List<dbModel.UserRoles> query = db.UserRoles
                                                .Include(x => x.Users.Company)
                                                .Include(x => x.Roles)
                                                .ToList();
            return query;
        }

        public dbModel.UserRoles GetUserRole(int id)
        {
            return db.UserRoles.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(dbModel.UserRoles model)
        {
            db.UserRoles.Add(model);
            db.SaveChanges();
        }

        public void Update(int Id, dbModel.UserRoles model)
        {
            model.Id = Id;

            db.SetModified(model);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var query = db.Company.Where(x => x.Id == Id);
            var item = query.SingleOrDefault();

            //item.IsDeleted = true;

            db.SaveChanges();
        }
    }
}
