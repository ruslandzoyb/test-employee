using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data.Tests
{
    [TestFixture]
  public  class PositionTests
    {

        [Test]
        public async Task AddAsync_AddToDb()
        {
            //arrange
            int expectedId = 4;
            string title = "New position";
            var position = new Position()
            {
                Title = title
            };
            using (var context = new EmployeeContext(Helper.GetContextInMemory()))
            {
                var repos = GetRepository(context);
                //act 
                var actual = await repos.Add(position);
                await context.SaveChangesAsync();
                var actual_length= (await repos.GetList()).Count();
                //asseet 
                Assert.Multiple(() => {
                    Assert.AreEqual(expectedId, actual.Id);
                    Assert.AreEqual(title, actual.Title);
                    Assert.AreEqual(4, actual_length);
                });
            } ;


        }

        [Test]
        public async Task RemoveEntity_WorkCorrect()
        {
            //arrange
            int id = 2;
            int expected_length = 2;

            using (var context = new EmployeeContext(Helper.GetContextInMemory()))
            {
                var repos = GetRepository(context);
                // act 
               await repos.Delete(id);
                await context.SaveChangesAsync();
                var actual_length = (await repos.GetList()).Count();
                var entity = await repos.Get(id);

                //assert 
                Assert.AreEqual(expected_length, actual_length);
                Assert.AreEqual(null,entity);
            };
        }




        
        private IPositionRepository GetRepository(EmployeeContext context)
        {
            return new PositionRepository(context);
        }

    }
}
