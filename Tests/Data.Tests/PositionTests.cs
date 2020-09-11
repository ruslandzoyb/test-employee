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


           [Test]
           public async Task Get()
        {
            int expectedId = 2;
            string title = "Senior DEV";

            using (var context = new EmployeeContext(Helper.GetContextInMemory()))
            {
                //act
                var repos = GetRepository(context);
                var entity = await repos.Get(expectedId);

                //assert
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expectedId,entity.Id);
                    Assert.AreEqual(title, entity.Title);
                });

            }
        }


        [Test]
        public async Task GetList()
        {
            using (var context = new EmployeeContext(Helper.GetContextInMemory()))
            {
                //arrange
                var repos = GetRepository(context);
                var expected_list = GetPositions().ToList();

                //act
                var actual_list = (await repos.GetList()).ToList();

                //assert
                for (int i = 0; i < expected_list.Count(); i++)
                {
                    Assert.AreEqual(expected_list[i].Id, actual_list[i].Id);
                    Assert.AreEqual(expected_list[i].Title, actual_list[i].Title);

                }

            }

        }


        [Test]
        public async Task Update()
        {
            //arrange 
            int id = 2;
            string title = "Senior DEV";
            string expected_title = "update";

            using (var context = new EmployeeContext(Helper.GetContextInMemory()))
            {
                //act
                var repos = GetRepository(context);
                var entity = await repos.Get(id);
                entity.Title = expected_title;
                repos.Update(entity);

                var actual_model = await repos.Get(id);

                //assert
                Assert.AreEqual(expected_title, actual_model.Title);
            }
        }
        


        
        private IPositionRepository GetRepository(EmployeeContext context)
        {
            return new PositionRepository(context);
        }

        private IEnumerable<Position> GetPositions()
        {
            return new Position[]
              {
                  new Position()
                  {
                      Id = 1,
                      Title = "Junior DEV"
                  },
                  new Position()
                  {
                      Id = 2,
                      Title = "Senior DEV"
                  },
                  new Position()
                  {
                      Id = 3,
                      Title = "Junior QA"
                  }
              };
        }

    }
}
