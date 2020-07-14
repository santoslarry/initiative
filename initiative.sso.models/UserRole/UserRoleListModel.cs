using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db = initiative.sso.db.Model;

namespace initiative.sso.models.UserRole
{
    public class UserRoleListModel
    {
        public UserRoleListModel()
        {

        }
        //public UserRoleListModel(db.Model.UserRoles model)
        //{
        //    Id = model.Id;
        //}

        public db.Model.UserRoles ToDBModel()
        {
            db.Model.UserRoles model = new db.Model.UserRoles
            {
                Id = Id,
                Roles = Roles,
                Users = Users,
            };
            return model;
        }
        public int Id { get; set; }

        public db.Model.Roles Roles { get; set; }

        public db.Model.Users Users { get; set; }
    }
}
