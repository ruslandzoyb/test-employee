using Data.Entities;
using Data.Interfaces;
using Domain.DTO;
using Domain.Services;
using Domain.Validation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain.Tests
{
    [TestFixture]
   public class EmployeeTests
    {
        [Test]
        public async Task Add()
        {
            var employee = new EmployeeDTO()
            {
                Id = 1,
                Name = "Igor",
                Surname = "Honchar"
            };
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(x => x.EmployeeRepository
            .Add(It.IsAny<Employee>())).ReturnsAsync(GetTestEmployees().First());
                
            var employeeService = new EmployeeService(mockUOW.Object, Helper.GetMapper());

           
           var model=  await employeeService.Add(employee);

            mockUOW.Verify(x => x.EmployeeRepository
            .Add(It.Is<Employee>(x => x.Id == employee.Id && x.Name == employee.Name && x.Surname == employee.Surname)), Times.Once);
            mockUOW.Verify(x => x.Save(), Times.Once);



        }


        [TestCase(1)]
        [TestCase(5)]
        [TestCase(15)]

        public async Task Delete(int id)
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(x => x.EmployeeRepository.Delete(It.IsAny<int>()));

            var employeeService = new EmployeeService(mockUOW.Object, Helper.GetMapper());

            await employeeService.Remove(id);

            mockUOW.Verify(x =>x.EmployeeRepository.Delete(id),Times.Once);
            mockUOW.Verify(x => x.Save(), Times.Once);

        }

        [Test]
        public async Task Get()
        {

            var expected = GetTestEmployees().First();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(m => m.EmployeeRepository.Get(It.IsAny<int>()))
                .ReturnsAsync(GetTestEmployees().First);
            var bookService = new EmployeeService(mockUnitOfWork.Object, Helper.GetMapper());

            var actual = await bookService.Get(1);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Surname, actual.Surname);

        }



        [Test]
        public async Task Update()
        {
            //Arrange
            var employee = new EmployeeDTO { Id = 1, Name="Rusl",Surname="Drizzy" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.EmployeeRepository.Update(It.IsAny<Employee>()));
            var empService = new EmployeeService(mockUnitOfWork.Object, Helper.GetMapper());

            //Act
            await empService.Update(employee);

            //Assert
            mockUnitOfWork.Verify(x => x.EmployeeRepository
            .Update(It.Is<Employee>(x=>x.Id==employee.Id&&x.Name==employee.Name&&x.Surname==employee.Surname)), Times.Once);
            mockUnitOfWork.Verify(x => x.Save(), Times.Once);
        }


        [Test]
        public async Task GetAll()
        {
            var expected = GetTestEmployees().ToList();
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(x => x.EmployeeRepository.GetList()).ReturnsAsync(GetTestEmployees());

            var service = new EmployeeService( mockUOW.Object, Helper.GetMapper());

            var actual = (await service.GetList()).ToList();

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Surname, actual[i].Surname);
            }

        }


        [Test]
        public void Add_ThrowCustomException_EmployeeIsNull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            EmployeeDTO employee = null;

            mockUOW.Setup(x => x.EmployeeRepository.Add(It.IsAny<Employee>()));

            var service = new EmployeeService(mockUOW.Object, Helper.GetMapper());

            Assert.ThrowsAsync<CustomException>(() =>  service.Add(employee));

        }


        [Test]
        public void Add_ThrowCustomException_EmployeeNameisNull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            EmployeeDTO employee = new EmployeeDTO() { 
            Id=1,
            Name=null,
            Surname="surname"
            };

            mockUOW.Setup(x => x.EmployeeRepository.Add(It.IsAny<Employee>()));

            var service = new EmployeeService(mockUOW.Object, Helper.GetMapper());

            Assert.ThrowsAsync<CustomException>(() => service.Add(employee));

        }

        [Test]
        public void Add_ThrowCustomException_EmployeeNameLengthZero()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            EmployeeDTO employee = new EmployeeDTO()
            {
                Id = 1,
                Name = "",
                Surname = "surname"
            };

            mockUOW.Setup(x => x.EmployeeRepository.Add(It.IsAny<Employee>()));

            var service = new EmployeeService(mockUOW.Object, Helper.GetMapper());

            Assert.ThrowsAsync<CustomException>(() => service.Add(employee));

        }

        [Test]
        public void Add_ThrowCustomException_EmployeeSurnameisNull()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            EmployeeDTO employee = new EmployeeDTO()
            {
                Id = 1,
                Name = "name",
                Surname = null
            };

            mockUOW.Setup(x => x.EmployeeRepository.Add(It.IsAny<Employee>()));

            var service = new EmployeeService(mockUOW.Object, Helper.GetMapper());

            Assert.ThrowsAsync<CustomException>(() => service.Add(employee));

        }



        private IEnumerable<Employee> GetTestEmployees()
        {
            return new List<Employee>() {
                new Employee()
                {
                    Id=1,
                    Name="John",
                    Surname="Wick"
                },
                 new Employee()
                {
                    Id=2,
                    Name="Rick",
                    Surname="Rich"
                },
                  new Employee()
                {
                    Id=3,
                    Name="Mars",
                    Surname="Bad"
                },
                   new Employee()
                {
                    Id=4,
                    Name="Nick",
                    Surname="Cannon"
                },
            };
        }

    }
}
