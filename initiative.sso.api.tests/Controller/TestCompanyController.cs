using initiative.sso.api.Controllers;
using initiative.sso.db.Model;
using initiative.sso.models.Company;
using initiative.sso.services.Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace initiative.sso.api.tests.Controller
{
    [TestClass]
    public class TestCompanyController
    {
        [TestMethod]
        public void TestCompanyController_GetAllCompany()
        {
            var testInputData = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Accenture"
                },
                new Company
                {
                    Id = 2,
                    Name = "IBM"
                }
            };

            var mockCompanyService = new Mock<ICompanyService>(MockBehavior.Strict);
            mockCompanyService.Setup(x => x.GetAllCompany(
                    //* Parameter here *//
                ))
                .Returns(testInputData)
                .Verifiable();

            var controller = new CompanyController(mockCompanyService.Object);
            controller.Request = new HttpRequestMessage();
            var actual = controller.Get();

            Assert.AreEqual(testInputData.Count, actual.Count);

            foreach(var data in testInputData)
            {
                var expected_item = new CompanyListModel(data);
                var actual_item = actual.Where(x => x.Id == expected_item.Id).SingleOrDefault();
                Assert.IsNotNull(actual_item);
                Assert.AreEqual(expected_item.Name, actual_item.Name);
            }

        }
    }
}
