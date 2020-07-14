using initiative.sso.db.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using dbModel = initiative.sso.db.Model;

namespace initiative.sso.services.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly IAuthContext db;

        public CompanyService()
        {
            this.db = new AuthContext();
        }

        public CompanyService(IAuthContext dbContext)
        {
            this.db = dbContext;
        }

        public List<dbModel.Company> GetAllCompany()
        {
            List<dbModel.Company> query = db.Company.ToList();
            return query;
        }

        public dbModel.Company GetCompany(int id)
        {
            return db.Company.Where(x => x.Id == id).FirstOrDefault() ;
        }

        public void Create(dbModel.Company model)
        {
            db.Company.Add(model);
            db.SaveChanges();
        }

        public void Update(int Id, dbModel.Company model)
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
