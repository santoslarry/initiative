using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using initiative.sso.db.Model;
using initiative.sso.models;
using initiative.sso.models.UserRole;
using initiative.sso.services.UserRole;

namespace initiative.sso.api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/userrole")]
    public class UserRoleController : ApiController
    
    {
        private readonly IUserRoleService userRoleService;

        public UserRoleController()
        {
            this.userRoleService = new UserRoleService();
        }

        public UserRoleController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService ?? throw new ArgumentNullException(nameof(userRoleService));
        }

        // GET: api/UserRole
        public List<UserRoleListModel> Get()
        {
            List<UserRoleListModel> result = userRoleService.GetAllUserRole().Select(x => new UserRoleListModel
            {
                Id = x.Id,
                Users = x.Users,
                Roles = x.Roles,
            }).ToList();
            return result;
        }

    }
}
