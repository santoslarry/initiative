using System;
using System.Collections.Generic;
using System.Text;
using initiative.sso.models;

namespace initiative.sso.services.Company
{
    public interface ICompanyService
    {
        List<db.Model.Company> GetAllCompany();

        db.Model.Company GetCompany(int id);

        void Create(db.Model.Company model);

        void Update(int Id, db.Model.Company model);
        void Delete(int Id);
    }
}
