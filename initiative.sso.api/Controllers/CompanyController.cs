using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using initiative.sso.db.Model;
using initiative.sso.models;
using initiative.sso.models.Company;
using initiative.sso.services.Company;

namespace initiative.sso.api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService companyService;

        public CompanyController()
        {
            this.companyService = new CompanyService();
        }

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        // GET: api/Company
        public List<CompanyListModel> Get()
        {
            List<CompanyListModel> result = companyService.GetAllCompany().Select(x => new CompanyListModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return result;
        }

        public CompanyListModel Get(int id)
        {
            Company company = companyService.GetCompany(id);
            CompanyListModel result = null;
            if (company != null)
            {
                result = new CompanyListModel(company);
            }
            else
            {
                result = new CompanyListModel();
            }
            return result;
        }

        public ActionResponseModel Post([FromBody]CompanyListModel value)
        {
            ActionResponseModel response = new ActionResponseModel();
            try
            {
                // Create News
                companyService.Create(value.ToDBModel());

                // Build Response
                response.Id = value.Id;
                response.Success = true;
                response.Error = null;
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.Success = false;
                response.Error = ex.Message;
            }
            return response;
        }

        [HttpPut]
        public ActionResponseModel Put(int id, [FromBody]CompanyListModel value)
        {
            ActionResponseModel response = new ActionResponseModel();

            try
            {
                // Update 
                companyService.Update(id, value.ToDBModel());

                // Build Response
                response.Id = id;
                response.Success = true;
                response.Error = null;
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.Success = false;
                response.Error = ex.Message;
            }

            return response;
        }

        [HttpDelete]
        public ActionResponseModel Delete(int id)
        {
            ActionResponseModel response = new ActionResponseModel();

            try
            {
                // Delete 
                companyService.Delete(id);

                // Build Response
                response.Id = id;
                response.Success = true;
                response.Error = null;
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.Success = false;
                response.Error = ex.Message;
            }

            return response;
        }
    }
}
