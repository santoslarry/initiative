using initiative.sso.api.tests.Context;
using initiative.sso.db.Model;
using initiative.sso.services.Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace initiative.sso.api.tests.Services
{
    [TestClass]
    public class TestCompanyService
    {
     
        [TestMethod]
        public void TestCompanyService_GetAllCompany()
        {
            //Setup Environment
            var context = new TestInitiativeContext();
            LoadData(context);

            //Run Test
            var service = new CompanyService(context);
            var actual = service.GetAllCompany();
            var expected = companies.ToList();

            //Evaluate Result
            Assert.AreEqual(actual.Count(), expected.Count());

            var actual_item = actual.Where(x => x.Id == 1).FirstOrDefault();
            var expected_item = expected.Where(x => x.Id == 1).FirstOrDefault();

            Assert.AreEqual(actual_item.Name, expected_item.Name);
        }

        private void LoadData(TestInitiativeContext context)
        {
            context.Company.AddRange(companies);
        }

        private static readonly List<Company> companies = new List<Company>
        {
            new Company
            {
                Id = 1,
                Name = "Accenture"
            }
        };
    }
}
