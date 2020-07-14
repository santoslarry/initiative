using System;
using System.Collections.Generic;
using System.Text;
using initiative.sso.db.Model;

namespace initiative.sso.models.Company
{
    public class CompanyListModel
    {
        public CompanyListModel()
        {

        }
        public CompanyListModel(db.Model.Company model)
        {
            Id = model.Id;
            Name = model.Name;
        }

        public db.Model.Company ToDBModel()
        {
            db.Model.Company model = new db.Model.Company
            {
                Id = Id,
                Name = Name
            };
            return model;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
