using Data;
using Domain.DTO;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PL.Tests
{
    [TestFixture]
   public class EmployeeIntegrationTest
    {
        private HttpClient _client;
        private CustomWebApplicationFactory _factory;
        private const string RequestUri = "api/employee/";


        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task EmployeeController_GetById_ReturnsEmployeeDTO()
        {
            var httpResponse = await _client.GetAsync(RequestUri + 1);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeDTO>(stringResponse);

            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual("Ron", employee.Name);
            Assert.AreEqual("Viz", employee.Surname);
           
        }


        [Test]
        public async Task EmployeeController_Add_ReturnsEmployeeDTO()
        {
            var employee = new EmployeeDTO() { Id = 5, Name = "Minerva", Surname = "McGon" };
            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(RequestUri, content);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var employee_response = JsonConvert.DeserializeObject<EmployeeDTO>(stringResponse);
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<EmployeeContext>();
                var employee1 = await context.Employees.FindAsync(employee_response.Id);
                Assert.AreEqual(employee1.Id, employee_response.Id);
                Assert.AreEqual(employee1.Name, employee_response.Name);
                Assert.AreEqual(employee1.Surname, employee_response.Surname);
                Assert.AreEqual(5, context.Employees.Count());
            }



        }


    }
}
