using System;
using System.Collections.Generic;
using System.Text;
using initiative.sso.models;

namespace initiative.sso.services.UserRole
{
    public interface IUserRoleService
    {
        List<db.Model.UserRoles> GetAllUserRole();

        db.Model.UserRoles GetUserRole(int id);

        void Create(db.Model.UserRoles model);

        void Update(int Id, db.Model.UserRoles model);
        void Delete(int Id);
    }
}
